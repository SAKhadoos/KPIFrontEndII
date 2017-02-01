/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for the common element, it handles the header and footer.
 *
 * Changes in 1.1:
 *  -Added new functions 'isApproverUser', 'goBackByLastMenu'
 *
 *  Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - Modified 'getCounts' to only check awaiting & approved count if logged in user has permission for such action/menu
 *
 * Changes in 1.3 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 1
 * Changes in 1.4 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.5 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 * Changes in 1.6 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER, TCSASSEMBLER
 * @version 1.6
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('masterCtrl', ['$rootScope', '$scope', '$location', 'storage', 'util', 'config', 'SecurityService',
            'LookupService', 'KPILookupService', 'AssessmentService',
            function ($rootScope, $scope, $location, storage, util, config, SecurityService, LookupService, KPILookupService, AssessmentService) {

                $scope.draftCount = 0;  // The count of draft assessments. It's only available for owners.
                $scope.awaitingApprovalCount = 0;  // The count of awaiting approval assessment
                $scope.approvedCount = 0;  // The count of approved assessments.
                $scope.rejectedCount = 0;  // The count of rejected assessments. It's only available for owners.
                $scope.pendingAddOnsCount = 0; // the count of pending addons
                $scope.pendingAddOns = []; // the pending add ons

                // watch menu changes and update app selector accordingly
                $rootScope.$watch('currentMenu', function (newValue) {
                    if (newValue) {
                        if (newValue === config.MENUS.HOME ||
                            newValue === config.MENUS.ADD_ASSESSMENT ||
                            newValue === config.MENUS.DRAFT_ASSESSMENT ||
                            newValue === config.MENUS.AWAITING_ASSESSMENT ||
                            newValue === config.MENUS.APPROVED_ASSESSMENT ||
                            newValue === config.MENUS.REJECTED_ASSESSMENT ||
                            newValue === config.MENUS.USER ||
                            newValue === config.MENUS.EDIT_FIELDS)
                        {
                            $rootScope.appSelector.selectedItem = [config.COEUS_APP_NAME];
                        }
                        else {
                            $rootScope.appSelector.selectedItem = [config.KPI_APP_NAME];
                        }
                        util.setAppSelectorEnabled();
                    }
                });

                /**
                 * Switches Apps and navigates to home page of selected app.
                 */
                $scope.switchApp = function (selectedValue) {
                    if (selectedValue === config.COEUS_APP_NAME) {
                        $rootScope.goto('/home');
                    }
                    else {
                        $rootScope.goto('/kpi/home');
                    }
                };

                $scope.adminLookups = {};

                // holds the global checkbox selection
                $scope.globalOptions = {};

                /**
                 * Gets the count of assessments in different status
                 */
                $scope.getCounts = function () {
                    if ($rootScope.appSelector.selectedItem && $rootScope.appSelector.selectedItem[0] === config.KPI_APP_NAME) {
                        return;
                    }

                    // call if user is logged in only
                    if (util.isLoggedIn()) {
                        if ($scope.checkPermission('awaitingAssessments')) {
                            // Get count of awaiting approval assessment
                            AssessmentService.getAwaitingApprovalCount().then(function (result) {
                                $scope.awaitingApprovalCount = result;
                            }, util.handleHttpError);
                        }
                        if ($scope.checkPermission('approvedAssessments')) {
                            // Get count of approved assessments
                            AssessmentService.getApprovedCount().then(function (result) {
                                $scope.approvedCount = result;
                            }, util.handleHttpError);
                        }

                        if (util.isUserInRole(config.ROLES.OWNER_ROLE_NAME) ||
                            util.isUserInRole(config.ROLES.ADMIN_ROLE_NAME)) {
                            // Get the count of rejected assessments. It's only available for owners and admin.
                            AssessmentService.getRejectedCount().then(function (result) {
                                $scope.rejectedCount = result;
                            }, util.handleHttpError);

                            // Get count of draft assessments
                            AssessmentService.getDraftCount().then(function (result) {
                                $scope.draftCount = result;
                            }, util.handleHttpError);

                        }
                        // only for admin
                        if (util.isUserInRole(config.ROLES.ADMIN_ROLE_NAME)) {
                            LookupService.countPendingAddOns().then(function (result) {
                                $scope.pendingAddOnsCount = result;
                            }, util.handleHttpError);

                            $scope.getPendingAddOns();
                        }
                    }
                };
                $rootScope.getCounts = $scope.getCounts;
                /**
                 * Handles the logout request
                 */
                $scope.logout = function () {
                    SecurityService.revokeToken();
                    // don't wait to response either the method success or fail user should be
                    // logout
                    util.logout();
                };

                /**
                 * Checks the current user permission to given action
                 * @param {String} action the action to check
                 * @returns {Boolean} true if user has permission else false
                 */
                $scope.checkPermission = function (action) {
                    if (!$rootScope.user || (!$rootScope.user.role && !$rootScope.user.kpiRole)) {
                        return false;
                    }
                    var permission = _.findWhere(config.PERMISSIONS, { action: action });
                    if (permission) {
                        return _.contains(permission.roles, $rootScope.user.role) ||
                            _.contains(permission.roles, $rootScope.user.kpiRole);
                    }
                    return false;
                };

                /**
                 * Gets current user's role name
                 * @returns {String} the role name
                 */
                $scope.getMyRole = function () {
                    if (util.isLoggedIn()) {
                        return $rootScope.user.role;
                    } else {
                        util.logout();
                    }
                };

                /**
                 * Sets the isApprover flag true if logged in user is approver
                 */
                $scope.isApproverUser = function () {
                    if ($rootScope.user && ($rootScope.user.role === config.ROLES.BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME ||
                        $rootScope.user.role === config.ROLES.BU_FUNCTIONAL_APPROVER_ROLE_NAME ||
                        $rootScope.user.role === config.ROLES.DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME)) {
                        $rootScope.isApprover = true;
                    } else {
                        $rootScope.isApprover = false;
                    }
                };
                $scope.isApproverUser();

                /**
                 * Redirect to last page
                 */
                $scope.goBackByLastMenu = function () {
                    var lastName = storage.getLastMenu();
                    var path = '/home';
                    switch (lastName) {
                        case config.MENUS.HOME:
                            path = '/home';
                            break;
                        case config.MENUS.ADD_ASSESSMENT:
                            path = '/addAssessment';
                            break;
                        case config.MENUS.DRAFT_ASSESSMENT:
                            path = '/assessments/' + config.ASSESSMENT_STATUS.DRAFT;
                            break;
                        case config.MENUS.AWAITING_ASSESSMENT:
                            path = '/assessments/' + config.ASSESSMENT_STATUS.AWAITING;
                            break;
                        case config.MENUS.APPROVED_ASSESSMENT:
                            path = '/assessments/' + config.ASSESSMENT_STATUS.APPROVED;
                            break;
                        case config.MENUS.REJECTED_ASSESSMENT:
                            path = '/assessments/' + config.ASSESSMENT_STATUS.REJECTED;
                            break;
                    }
                    $location.path(path);
                };
                /**
                 * This method handles action to get pending add-ons.
                 */
                $scope.getPendingAddOns = function () {
                    LookupService.getPendingAddOns().then(function (result) {
                        $scope.pendingAddOns = result;
                    });
                };

                //endswith checks
                $scope.endsWith = function (newPath, onlyLast) {
                    newPath = newPath.toLowerCase();
                    var path = $scope.path ? $scope.path.toLowerCase() : '';
                    path = path.split('/');
                    var len = path.length;
                    if (onlyLast) {
                        if (len > 0 && (path[len - 1] === newPath)) {
                            return true;
                        }
                    } else {
                        if (len > 0 && (path[len - 1] === newPath || (path[len - 2] === newPath && path[len - 2] !== 'add') && path[len - 2] !== 'edit')) {
                            return true;
                        }
                    }
                    return false;
                };

                /**
                 * Creates the lookup entity and broad cast created event on success.
                 * @param type  the entity type
                 * @param entity the entity to create
                 */
                $scope.createLookupEntity = function (type, entity) {
                    LookupService.createLookupEntity(type, entity).then(function (result) {
                        $scope.adminLookups[type].push(result);
                        $scope.$broadcast("addedNewRecord");
                    }, util.handleHttpError);
                };

                /**
                 * Approves the pending add on
                 * @param addOn the add on detail
                 */
                $scope.approvePendingAddOn = function (addOn) {
                    addOn.addOnStatus = config.ADD_ON_STATUS.APPROVED;
                    _updateLookupEntity(addOn);
                };

                /**
                 * Rejects the pending add on
                 * @param addOn the add on detail
                 */
                $scope.rejectPendingAddOn = function (addOn) {
                    addOn.addOnStatus = config.ADD_ON_STATUS.REJECTED;
                    _updateLookupEntity(addOn);
                };

                /**
                 * Starts the editing add on
                 * @param addOn the add on detail
                 * @param isNotificationEdit the flag whether add on is editing on notification or not
                 */
                $scope.startEditingAddOn = function (addOn, isNotificationEdit) {
                    addOn.oldName = angular.copy(addOn.name);
                    if (isNotificationEdit) {
                        addOn.notificationEditing = true;
                    } else {
                        addOn.editing = true;
                    }

                };

                /**
                 * Cancels the editing add on
                 * @param addOn the add on detail
                 * @param isNotificationEdit the flag whether add on is editing on notification or not
                 */
                $scope.cancelEditingAddOn = function (addOn, isNotificationEdit) {
                    addOn.name = angular.copy(addOn.oldName);
                    if (isNotificationEdit) {
                        addOn.notificationEditing = false;
                    } else {
                        addOn.editing = false;
                    }
                };

                /**
                 * Updates the pending add on
                 * @param addOn the add on detail
                 * @param isNotificationEdit the flag whether add on is editing on notification or not
                 */
                $scope.updatePendingAddOn = function (addOn, isNotificationEdit) {
                    var entityType = 'SLA';
                    if (addOn.category) {
                        entityType = 'ControlType';
                    }
                    if (addOn.name) {
                        LookupService.updateLookupEntity(entityType, addOn.id, addOn).then(function (result) {
                            addOn.name = result.name;
                            if (isNotificationEdit) {
                                addOn.notificationEditing = false;
                            } else {
                                addOn.editing = false;
                            }
                        }, util.handleHttpError);
                    }
                };

                /**
                 * Updates the pending add on
                 * @param addOn the add on detail
                 */
                function _updateLookupEntity(addOn) {
                    var entityType = 'SLA';
                    if (addOn.category) {
                        entityType = 'ControlType';
                    }
                    LookupService.updateLookupEntity(entityType, addOn.id, addOn).then(function (result) {
                        angular.forEach($scope.pendingAddOns, function (item, index) {
                            if (item.id === result.id) {
                                $scope.pendingAddOns.splice(index, 1);
                                if ($scope.pendingAddOnsCount > 0) {
                                    $scope.pendingAddOnsCount--;
                                }
                            }
                        });
                    }, util.handleHttpError);
                }
            }
        ]);
})();