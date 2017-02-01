/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for process and control assessment edit page.
 *
 * Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 *
 * @author veshu, TCSASSEMBLER
 * @version 1.2
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('editFieldsProcessesCtrl', ['$rootScope', '$scope', '$routeParams', '$location', 'LookupService', 'util', 'config',
            function ($rootScope, $scope, $routeParams, $location, LookupService, util, config) {
                //sets the navigation menu as active
                $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;

                $scope.lookups = {};

                // holds the state representing the current tab
                $scope.current = {
                    tabIndex: 0,
                    showPrev: true
                };

                // holds the currently selected items
                $scope.selected = {
                    slAs: [],
                    controlTypes: []
                };
                // holds the items that will be created
                $scope.new = {};

                // get all categories
                LookupService.getAllCategories().then(function (result) {
                    $scope.lookups.categories = result;
                    if ($routeParams.categoryId > 0 && _.contains(_.pluck(result, 'id'), parseInt($routeParams.categoryId))) {
                        $scope.selectCategoryTab(parseInt($routeParams.categoryId));
                    } else {
                        $scope.selectCategoryTab(result[0].id);
                    }
                }, util.handleHttpError);

                /**
                 * Resolves the child entity of business unit
                 * @param id the business unit id.
                 */
                $scope.resolveBusinessUnitLookups = function (id) {
                    LookupService.getFunctionalAreasWithCategory(id, $scope.selected.categoryType, false).then(function (result) {
                        $scope.adminLookups.FunctionalArea = result;
                        if (result.length > 0) {
                            $scope.selected.functionalArea = result[0];
                        } else {
                            _resolveCoreProcesses();
                        }
                    }, util.handleHttpError);
                };

                /**
                 * Adds the business unit related entity such as functional area.
                 */
                $scope.addBusinessUnitRelated = function (type, entity) {
                    if ($scope.selected.businessUnit && $scope.selected.businessUnit.id > 0) {
                        entity = _.extend(entity, {
                            BusinessUnitId: $scope.selected.businessUnit.id
                        });
                        $scope.createLookupEntity(type, entity);
                    }
                };

                /**
                 * Defines the row sorting handler
                 */
                $scope.rowSortOptions = {
                    handle: '.move-handel-row',
                    stop: function (e, ui) {
                        var lists = ui.item.parent();
                        var ids = lists.sortable("toArray");
                        var rowEntityType = 'ProcessRisk';
                        if ($scope.selected.categoryType === config.KPISLA_ASSESSMENT_CATEGORY_ID) {
                            rowEntityType = 'KPICategory';
                        } else if ($scope.selected.categoryType === config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID) {
                            rowEntityType = 'CoreProcess';
                        }
                        LookupService.reorderLookupEntities(rowEntityType, ids, _.range(1, ids.length + 1))
                            .catch(function () {
                                lists.sortable("cancel");
                                util.handleHttpError("An error occurred while reordering the items.");
                            });
                    }
                };

                /**
                 * To create controlTypes or SLAs, business unit and functional area
                 * @param type the entity type
                 * @param entity the entity detail
                 */
                $scope.createCategoryLookupEntity = function (type, entity) {
                    if ($scope.selected.categoryType && $scope.selected.categoryType > 0) {
                        entity = _.extend(entity, {
                            Category: {
                                id: $scope.selected.categoryType
                            }
                        });
                        if (type === 'FunctionalArea' && $scope.selected.businessUnit) {
                            entity = _.extend(entity, {
                                BusinessUnitId: {
                                    id: $scope.selected.businessUnit
                                }
                            });
                        }

                        $scope.createLookupEntity(type, entity);
                    }
                };

                /**
                 * Handles the selecting category tab event
                 * @param categoryId the category id
                 */
                $scope.selectCategoryTab = function (categoryId) {
                    if (categoryId) {
                        $scope.selected.categoryType = categoryId;
                        _resolveMasterLists(categoryId);
                        $scope.current.tabIndex = _.findIndex($scope.lookups.categories, function (item) {
                            return item.id === categoryId;
                        });
                        $scope.setCurrentNav(false);
                        if (!$scope.globalOptions[categoryId]) {
                            $scope.globalOptions[categoryId] = {};
                            $scope.globalOptions[categoryId].global = false;
                            $scope.globalOptions[categoryId].businessUnitWiseGlobal = false;
                        }
                        // get all business unit
                        LookupService.getAllBusinessUnitsByCategory(categoryId, false).then(function (result) {
                            $scope.adminLookups.BusinessUnit = result;
                            $scope.selected.businessUnit = result[0];
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Handles the add KPI Category event
                 */
                $scope.addKPICategory = function () {
                    if ($scope.new.categoryTitle.length) {
                        var businessUnitId = $scope.globalOptions[$scope.selected.categoryType].global == false ? $scope.selected.businessUnit.id : null;
                        var functionalAreaId = $scope.globalOptions[$scope.selected.categoryType].businessUnitWiseGlobal == false ? $scope.selected.functionalArea.id : null;

                        if ($scope.globalOptions[$scope.selected.categoryType].global == true) {
                            functionalAreaId = null;
                        }

                        var order = _.max(_.pluck($scope.adminLookups.KPICategory, "displayOrder")) + 1;
                        var entity = {
                            name: $scope.new.categoryTitle,
                            category: {
                                id: config.KPISLA_ASSESSMENT_CATEGORY_ID
                            },
                            functionalAreaId: functionalAreaId,
                            businessUnitId: businessUnitId,
                            displayOrder: order,
                            enabled: true,
                            addOnStatus: config.ADD_ON_STATUS.APPROVED
                        };
                        LookupService.createLookupEntity('KPICategory', entity).then(function (result) {
                            $scope.adminLookups['KPICategory'].push(result);
                            $scope.new.categoryTitle = '';
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Creates the KPI entity
                 * @param type the type of entity
                 * @param entity the entity detail
                 */
                $scope.createKPIEntity = function (type, entity) {
                    LookupService.createLookupEntity(type, entity).then(function (result) {
                        angular.forEach($scope.adminLookups.KPICategory, function (item) {
                            if (item.id === result.kpiCategory.id) {
                                item.kpIs.push(result);
                            }
                        });
                        $scope.$broadcast("addedNewRecord");
                    }, util.handleHttpError);
                };

                /**
                 * Adds the core process
                 */
                $scope.addCoreProcess = function () {
                    if ($scope.new.coreProcess.length) {
                        var businessUnitId = $scope.globalOptions[$scope.selected.categoryType].global == false ? $scope.selected.businessUnit.id : null;
                        var functionalAreaId = $scope.globalOptions[$scope.selected.categoryType].businessUnitWiseGlobal == false ? $scope.selected.functionalArea.id : null;

                        if ($scope.globalOptions[$scope.selected.categoryType].global == true) {
                            functionalAreaId = null;
                        }


                        var order = _.max(_.pluck($scope.adminLookups.CoreProcess, "displayOrder")) + 1;
                        var coreProcess = {
                            name: $scope.new.coreProcess,
                            category: {
                                id: config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID
                            },
                            functionalAreaId: functionalAreaId,
                            businessUnitId: businessUnitId,
                            displayOrder: order,
                            enabled: true,
                            addOnStatus: config.ADD_ON_STATUS.APPROVED
                        };
                        LookupService.createLookupEntity('CoreProcess', coreProcess).then(function (result) {
                            $scope.adminLookups['CoreProcess'].push(result);
                            $scope.new.coreProcess = '';
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Adds the sub process
                 * @param coreProcess the core process detail
                 */
                $scope.addSubProcess = function (coreProcess) {
                    if (coreProcess.newSubProcess.length) {
                        var order = _.max(_.pluck(coreProcess.subProcessRisks, "displayOrder")) + 1;
                        var entity = {
                            name: coreProcess.newSubProcess,
                            coreProcess: {
                                id: coreProcess.id
                            },
                            displayOrder: order,
                            enabled: true,
                            addOnStatus: config.ADD_ON_STATUS.APPROVED
                        };
                        LookupService.createLookupEntity('SubProcessRisk', entity).then(function (result) {
                            coreProcess.subProcessRisks.push(result);
                            coreProcess.newSubProcess = '';
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Adds the sub process  risk
                 * @param coreProcess the core process detail
                 */
                $scope.addCoreProcessRisk = function (coreProcess) {
                    if (coreProcess.newRiskTitle.length) {
                        var entity = _.last(coreProcess.subProcessRisks);
                        var entityToUpdate = angular.copy(entity);
                        entityToUpdate.risk = coreProcess.newRiskTitle;
                        entityToUpdate.coreProcess = { id: coreProcess.id };
                        LookupService.updateLookupEntity('SubProcessRisk', entityToUpdate.id, entityToUpdate).then(function (result) {
                            angular.forEach(coreProcess.subProcessRisks, function (item, index) {
                                if (item.id === result.id) {
                                    coreProcess.subProcessRisks[index] = result;
                                }
                            });
                            coreProcess.newRiskTitle = '';
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Adds the process
                 */
                $scope.addProcess = function () {
                    if ($scope.new.processTitle.length) {
                        var businessUnitId = $scope.globalOptions[$scope.selected.categoryType].global == false ? $scope.selected.businessUnit.id : null;
                        var functionalAreaId = $scope.globalOptions[$scope.selected.categoryType].businessUnitWiseGlobal == false ? $scope.selected.functionalArea.id : null;

                        if ($scope.globalOptions[$scope.selected.categoryType].global == true) {
                            functionalAreaId = null;
                        }

                        var order = _.max(_.pluck($scope.adminLookups.ProcessRisk, "displayOrder")) + 1;
                        var coreProcess = {
                            name: $scope.new.processTitle,
                            category: {
                                id: $scope.selected.categoryType
                            },
                            functionalAreaId: functionalAreaId,
                            businessUnitId: businessUnitId,
                            displayOrder: order,
                            enabled: true,
                            addOnStatus: config.ADD_ON_STATUS.APPROVED
                        };
                        LookupService.createLookupEntity('ProcessRisk', coreProcess).then(function (result) {
                            $scope.adminLookups['ProcessRisk'].push(result);
                            $scope.new.processTitle = '';
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Adds the process risks
                 */
                $scope.addProcessRisk = function () {
                    if ($scope.new.processRisk.length) {
                        var entity = _.last($scope.adminLookups.ProcessRisk);
                        if (entity) {
                            var entityToUpdate = angular.copy(entity);
                            entityToUpdate.risk = $scope.new.processRisk;
                            LookupService.updateLookupEntity('ProcessRisk', entityToUpdate.id, entityToUpdate).then(function (result) {
                                angular.forEach($scope.adminLookups.ProcessRisk, function (item, index) {
                                    if (item.id === result.id) {
                                        $scope.adminLookups.ProcessRisk[index] = result;
                                    }
                                });
                                $scope.new.processRisk = '';
                            }, util.handleHttpError);
                        }
                    }
                };

                /**
                 * Delets the child entities
                 * @param type the entity type
                 * @param parentItem the parent item whose child entities will be deleted
                 */
                $scope.deleteChildItems = function (type, parentItem) {
                    var entityToUpdate = angular.copy(parentItem);
                    if (type === 'CoreProcess' || type === 'ProcessRisk') {
                        delete entityToUpdate.controlTypes;
                    } else if (type === 'KPICategory') {
                        delete entityToUpdate.slAs;
                    }

                    _updateParentLookupEntity(type, entityToUpdate);
                };

                //change child data on selected business unit item change
                $scope.$watch('selected.businessUnit', function (selected) {
                    if (selected) {
                        $scope.resolveBusinessUnitLookups(selected.id);
                        $scope.$broadcast("addedNewRecord");
                    }
                });

                //change child data on selected functional area id item change
                $scope.$watch('selected.functionalArea', function (selected) {
                    if (selected) {
                        _resolveCoreProcesses();
                    }
                });

                // catches the child item added event. eg. while adding control types or SLAs
                $scope.$on('child-item-added', function (event, parentItem, childItems, type) {
                    if (type === 'CoreProcess' || type === 'ProcessRisk') {
                        parentItem.controlTypes = childItems;
                    } else if (type === 'KPICategory') {
                        parentItem.slAs = childItems;
                    }
                    _updateParentLookupEntity(type, parentItem);
                });

                /**
                 * Sets the current bottom navigation based on the categories
                 * @param go flag whether to navigate the tab or not
                 */
                $scope.setCurrentNav = function (go) {
                    if ($scope.current.tabIndex === $scope.lookups.categories.length - 1) {
                        $scope.current.showNext = true;
                    } else {
                        $scope.current.showNext = false
                    }
                    if ($scope.current.tabIndex === 0) {
                        $scope.current.showPrev = true;
                    } else {
                        $scope.current.showPrev = false
                    }
                    if (go && $scope.current.tabIndex >= 0 && $scope.current.tabIndex < $scope.lookups.categories.length) {
                        var categoryId = $scope.lookups.categories[$scope.current.tabIndex].id;
                        $location.path("/admin/edit/processes/" + categoryId);
                    }
                };

                $scope.editGlobal = function () {
                    $scope.globalOptions[$scope.selected.categoryType].global = !$scope.globalOptions[$scope.selected.categoryType].global;
                    _resolveCoreProcesses();
                };

                $scope.editBusinessUnitWiseGlobal = function () {
                    $scope.globalOptions[$scope.selected.categoryType].businessUnitWiseGlobal = !$scope.globalOptions[$scope.selected.categoryType].businessUnitWiseGlobal;
                    _resolveCoreProcesses();
                };

                /**
                 * Resolves the core process based on current selection
                 */
                function _resolveCoreProcesses() {
                    var categoryId = $scope.selected.categoryType;
                    var businessUnitId = $scope.globalOptions[categoryId].global == false ?
                        $scope.selected.businessUnit.id : null;
                    var functionalAreaId = $scope.globalOptions[categoryId].businessUnitWiseGlobal == false ?
                        $scope.selected.functionalArea ? $scope.selected.functionalArea.id : null : null;

                    if ($scope.globalOptions[categoryId].global) {
                        businessUnitId = null;
                        functionalAreaId = null;
                    } else if ($scope.globalOptions[categoryId].businessUnitWiseGlobal) {
                        functionalAreaId = null;
                    }
                    if (categoryId === config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID) {
                        LookupService.getCoreProcesses(businessUnitId, functionalAreaId, false, false).then(function (result) {
                            $scope.adminLookups.CoreProcess = result;
                        }, util.handleHttpError);
                    } else if (categoryId === config.KPISLA_ASSESSMENT_CATEGORY_ID) {
                        LookupService.getKPICategories(businessUnitId, functionalAreaId, false, false).then(function (result) {
                            $scope.adminLookups.KPICategory = result;
                            angular.forEach($scope.adminLookups.KPICategory, function (item) {
                                item.kpIs = _.sortBy(item.kpIs, 'displayOrder');
                            });
                        }, util.handleHttpError);
                    } else {
                        LookupService.getAllProcessRisks(businessUnitId, functionalAreaId, false, false).then(function (result) {
                            $scope.adminLookups.ProcessRisk = _.filter(result, function (item) {
                                return item.category.id == categoryId;
                            });
                        }, util.handleHttpError);
                    }
                }

                /**
                 * Resolves the other properties for the tab based on the selected category
                 *
                 * @param categoryId the category id
                 */
                function _resolveMasterLists(categoryId) {
                    if (categoryId === config.KPISLA_ASSESSMENT_CATEGORY_ID) {
                        LookupService.getAllSLAs(false).then(function (result) {
                            $scope.adminLookups.SLA = result;
                        }, util.handleHttpError);

                    } else {
                        LookupService.getAllControlTypes(categoryId, false).then(function (result) {
                            $scope.adminLookups.ControlType = result;
                        }, util.handleHttpError);

                    }
                }

                /**
                 * Updates the lookup entity
                 *
                 * @param type the lookup entity type
                 * @param entity the entity
                 */
                function _updateParentLookupEntity(type, entity) {
                    LookupService.updateLookupEntity(type, entity.id, entity).then(function (result) {
                        angular.forEach($scope.adminLookups[type], function (item, index) {
                            if (item.id == result.id) {
                                $scope.adminLookups[type][index] = result;
                            }
                        });
                    }, util.handleHttpError);
                }
            }
        ]);
})();
