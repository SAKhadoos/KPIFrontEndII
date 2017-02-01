/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for risk calculation edit page.
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
        .controller('editFieldsRiskCalculationCtrl', ['$rootScope', '$scope', 'LookupService', 'util', 'config',
            function ($rootScope, $scope, LookupService, util, config) {
                //sets the navigation menu as active
                $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;

                $scope.riskCalculation = {};

                // holds the currently updating risk category information
                $scope.updatingRiskCategory = {};

                LookupService.getAllCategories().then(function (result) {
                    $scope.riskCalculation.categories = [];
                    _.each(result, function (item) {
                        if (item.id !== config.KPISLA_ASSESSMENT_CATEGORY_ID) {
                            $scope.riskCalculation.categories.push(item);
                        }
                    });
                }, util.handleHttpError);


                LookupService.getAllLikelihoodOfOccurrences().then(function (result) {
                    $scope.riskCalculation.LikelihoodOfOccurrence = result;
                }, util.handleHttpError);

                LookupService.getAllRiskExposures().then(function (result) {
                    $scope.riskCalculation.riskExposures = result;
                }, util.handleHttpError);

                LookupService.getAllKeyControlsMaturities().then(function (result) {
                    $scope.riskCalculation.keyControlsMaturities = result;
                }, util.handleHttpError);

                LookupService.getAllRiskScoreRanges().then(function (result) {
                    $scope.riskCalculation.riskScoreRanges = result;
                }, util.handleHttpError);

                /**
                 * Updates the lookup entity during edit
                 * @param item the item to update
                 * @param type the entity type
                 * @param property the property to update
                 */
                $scope.update = function (item, type, property) {
                    if (item[property] && item[property] >= 0) {
                        LookupService.updateLookupEntity(type, item.id, item).then(function (result) {
                            $scope.oldValue[property] = result[property];
                            $scope.updatingRiskCategory.editedItem = null;
                        }, function (err) {
                            item[property] = $scope.oldValue[property];
                            util.handleHttpError(err);
                        });
                    }
                };

                /**
                 * Starts the editing the item
                 * @param item the lookup entity to start edit
                 */
                $scope.startEditing = function (item) {
                    if (!$scope.updatingRiskCategory.editedItem) {
                        $scope.oldValue = angular.copy(item);
                    }
                };

                /**
                 * Cancels the risk category editing mode
                 */
                $scope.cancelRiskCategoryEditing = function () {
                    _.each($scope.riskCalculation.categories, function (item, index) {
                        if (item.id == $scope.oldValue.id) {
                            $scope.riskCalculation.categories[index] = $scope.oldValue;
                        }
                    });
                    $scope.updatingRiskCategory.editedItem = null;
                };

                /**
                 * Validates the edited risk category
                 * @param editedItem the edited item
                 * @param type the type of entity
                 * @param property the property of item that is edited
                 */
                $scope.validateRiskCategory = function (editedItem, type, property) {
                    if (parseInt(editedItem.weight) < 1 || parseInt(editedItem.weight) > 100) {
                        _.each($scope.riskCalculation.categories, function (item, index) {
                            if (item.id == editedItem.id) {
                                $scope.riskCalculation.categories[index] = $scope.oldValue;
                            }
                        });
                        util.showInfo("The weight of category must be within 1 and 100");
                    } else if (
                        _.reduce($scope.riskCalculation.categories, function (sum, item) {
                            return sum + parseInt(item.weight);
                        }, 0) !== 100) {
                        $scope.updatingRiskCategory.editedItem = editedItem;
                        $scope.updatingRiskCategory.type = type;
                        $scope.updatingRiskCategory.property = property;
                        _showUpdateConfirm();
                    } else {
                        $scope.update(editedItem, type, property);
                    }
                };

                // Updates the risk category
                $scope.updateRiskCategory = function () {
                    if ($scope.updatingRiskCategory.editedItem) {
                        $scope.update($scope.updatingRiskCategory.editedItem,
                            $scope.updatingRiskCategory.type,
                            $scope.updatingRiskCategory.property);
                    }
                };

                /** 
                * Shows the delete confirmation.
                * @param editedItem the edited item
                * @param type the type of entity
                * @param property the property of item that is edited
                */
                function _showUpdateConfirm(editedItem, type, property) {
                    var id = '#modal-risk-update-confirm';
                    var options = {
                        resizable: false,
                        modal: true,
                        dialogClass: "no-close",
                        closeOnEscape: false,
                        open: function () {
                            angular.element("body").css("overflow", "hidden");
                        },
                        close: function () {
                            angular.element("body").css("overflow", "auto");
                            $(this).dialog('destroy');
                        }
                    };
                    $(id).dialog(options).dialog('open');
                };

            }]);
})();