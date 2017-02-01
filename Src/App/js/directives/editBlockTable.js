/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Edit Key Performance Indicators block directive.
 * 
 * @author TCSASSEMBLER
 * @version 1.0
 */
(function () {
    'use strict';

    var app = angular.module('app');

    /**
     * Edit Key Performance Indicators block directive, which performs creating , updating and deleting of Key Performance Indicator items.
     */
    app.directive('editBlockTable', ['KPIScorecardConfigurationService', 'util', 'config',
        function (KPIScorecardConfigurationService, util, config) {
        //editBlock
        return {
            restrict: 'A',
            require: '?list',
            scope: {
                list: '=editBlockTable',
                category: '@',
                childCategory: '@'
            },
            templateUrl: 'partials/blocks/editBlockTable.template.html',
            controller: function ($scope) {
                $scope.editingIndex = -1;
                $scope.isProcessingNewRecord = false;
                $scope.targetHighToStr = function (arg) {
                    return arg ? 'High' : 'Low'
                };

                /** 
                 * Creates new record template.
                 */
                function createNewRecord() {
                    return {
                        targetHigh: true,
                        serviceLevel: {},
                        threshold: {}
                    }
                };
                $scope.newRecord = createNewRecord();

                /** 
                 * Adds new record.
                 */
                $scope.addRecord = function () {
                    if (!$scope.isProcessingNewRecord
                        && $scope.isValidDecimalOrPercentage($scope.newRecord.threshold.value)
                        && $scope.isValidDecimalOrPercentage($scope.newRecord.serviceLevel.value)) {

                        $scope.isProcessingNewRecord = true;
                        var nextId = _.max(_.pluck($scope.list, "id")) + 1;
                        if (nextId <= 0) {
                            nextId = 1;
                        }
                        $scope.newRecord.id = nextId;
                        resolveRecordPercentage($scope.newRecord);
                        $scope.list.push($scope.newRecord);
                        updateConfig();
                        $scope.newRecord = createNewRecord();
                    }
                };

                /** 
                 * Remove the record.
                 */
                $scope.removeRecord = function () {
                    if ($scope.deleting && $scope.deleting.index >= 0) {
                        $scope.list.splice($scope.deleting.index, 1);
                        updateConfig();
                    }
                };

                /** 
                 * Checks whether value is valid decimal or percentage value.
                 */
                $scope.isValidDecimalOrPercentage = function (value) {
                    var percentage = getPercentage(value);
                    if (percentage === false) {
                        var decimal = getDecimal(value);
                        return decimal !== false;
                    }
                    return true;
                };

                /** 
                 * Checks whether value is valid percentage value.
                 * @value - the value to check.
                 */
                $scope.isPercentage = function (value) {
                    return getPercentage(value) !== false;
                };

                /** 
                 * Checks whether value is valid percentage value.
                 * @value - a value indicating whether service level and threshold are percentage.
                 */
                $scope.adjustCreatingPercentage = function (value) {
                    if ($scope.newRecord.serviceLevel) {
                        $scope.newRecord.serviceLevel.percentage = value;
                    }
                    if ($scope.newRecord.threshold) {
                        $scope.newRecord.threshold.percentage = value;
                    }
                };

                /** 
                 * Parses percentage.
                 * @value - the value to parse.
                 */
                function getPercentage(value) {
                    if (!value) {
                        return false;
                    }
                    value = value.toString().trim();
                    if (value[value.length - 1] !== '%') {
                        return false;
                    }
                    value = value.substring(0, value.length - 1).trim();
                    return getDecimal(value);
                };

                /** 
                 * Parses decimal value.
                 * @value - the value to parse.
                 */
                function getDecimal(value) {
                    if (!value) {
                        return false;
                    }

                    if (isNaN(value)) {
                        return false;
                    }
                    return parseFloat(value);
                };

                /** 
                 * Sets the edit mode for KPI entity.
                 * @index - the index of the record in the list.
                 * @editingField - the field being edited.
                 */
                $scope.setEditingMode = function (index, editingField) {
                    $scope.editingIndex = index;
                    $scope.editingField = editingField;
                    var record = angular.copy($scope.list[index]);
                    record.serviceLevel.value = record.serviceLevel.value.toString();
                    if (record.serviceLevel.percentage) {
                        record.serviceLevel.value += '%';
                    }
                    record.threshold.value = record.threshold.value.toString();
                    if (record.threshold.percentage) {
                        record.threshold.value += '%';
                    }

                    $scope.updatingRecord = record;
                };

                /** 
                 * Cancels editing mode.
                 */
                $scope.cancelEditingMode = function () {
                    $scope.editingIndex = null;
                    $scope.updatingRecord = null;
                };

                /** 
                 * Listens to target dropdown changes.
                 */
                $scope.targetChanged = function (index) {
                    updateConfig();
                };

                // deleting entity
                $scope.deleting = {};

                /** 
                 * Updates the record.
                 */
                $scope.updateRecord = function () {
                    var record = $scope.list[$scope.editingIndex];
                    var updated = $scope.updatingRecord;

                    // make sure 'percentage' flag matches for both properties
                    var newPercentage = $scope.isPercentage(updated.serviceLevel.value);
                    if (record.serviceLevel.percentage !== newPercentage) {
                        updated.threshold.percentage = newPercentage;
                        updated.serviceLevel.percentage = newPercentage;
                    }
                    newPercentage = $scope.isPercentage(updated.threshold.value);
                    if (record.threshold.percentage !== newPercentage) {
                        updated.threshold.percentage = newPercentage;
                        updated.serviceLevel.percentage = newPercentage;
                    }

                    resolveRecordPercentage(updated);

                    $scope.list[$scope.editingIndex] = updated;
                    updateConfig();
                    $scope.cancelEditingMode();
                };

                /** 
                 * Resolves record percentage.
                 * @record - the record being edited.
                 */
                function resolveRecordPercentage(record) {
                    var serviceLevelPercentage = getPercentage(record.serviceLevel.value);
                    if (serviceLevelPercentage !== false) {
                        record.serviceLevel.value = serviceLevelPercentage;
                    } else {
                        record.serviceLevel.value = getDecimal(record.serviceLevel.value);
                    }

                    // resolve Threshold
                    var thresholdPercentage = getPercentage(record.threshold.value);
                    if (thresholdPercentage !== false) {
                        record.threshold.value = thresholdPercentage;
                    } else {
                        record.threshold.value = getDecimal(record.threshold.value);
                    }
                }

                /** 
                 * Listens for API error occurrence during API operation.
                 */
                $scope.$on('apiErrorOccurred', function () {
                    $scope.isProcessingNewRecord = false;
                });

                /** 
                 * Listens for 'Enabled' check box changes.
                 */
                $scope.changeChk = function () {
                    updateConfig();
                }

                /** 
                 * Shows the delete confirmation.
                 * @index - the index of the record to delete.
                 */
                $scope.showDeleteConfirm = function (index) {
                    var record = $scope.list[index];
                    $scope.deleting = {
                        index: index,
                        name: !!record.keyPerformanceIndicator ? record.keyPerformanceIndicator : 'Key Performance Indicator'
                    };
                    var elementId = '#modal-delete-' + $scope.category + '-record-' + $scope.childCategory;
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
                    $(elementId).dialog(options).dialog('open');
                };

                /** 
                 * Saves the config.
                 */
                function updateConfig() {
                    var config = {};
                    config[$scope.category] = {};
                    config[$scope.category][$scope.childCategory] = $scope.list;

                    $scope.isProcessingNewRecord = true;
                    KPIScorecardConfigurationService.set(config).then(function () {
                        $scope.newRecord = {
                            targetHigh: true
                        };
                        $scope.isProcessingNewRecord = false;
                    }, util.handleHttpError);
                };
            }
        };
    }]);
})();
