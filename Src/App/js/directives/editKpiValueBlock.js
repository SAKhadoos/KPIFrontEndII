/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Edit KPI value entities block directive.
 */
(function () {
    'use strict';

    var app = angular.module('app');

    /**
     * Edit KPI value entities block directive, which performs creating , updating and deleting of block item.
     */
    app.directive('editKpiValueBlock', ['KPIScorecardConfigurationService', 'util', 'config',
        function (KPIScorecardConfigurationService, util, config) {
        //editBlock
        return {
            restrict: 'A',
            require: '?list',
            scope: {
                list: '=editKpiValueBlock',
                selected: '=',
                category: '@',
                childCategory: '@',
                onlyInteger: '@'
            },
            templateUrl: 'partials/blocks/editKPIValueBlock.template.html',
            controller: function ($scope) {
                $scope.isProcessingNewRecord = false;

                /** 
                 * Adds new record.
                 */
                $scope.addRecord = function () {
                    if ($scope.newRecord && !$scope.isProcessingNewRecord) {
                        // check whether such value already exists
                        for (var index in $scope.list) {
                            var item = $scope.list[index];
                            if (item.value == $scope.newRecord) {
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
                                $('#value-already-exists-dialog').dialog(options).dialog('open');
                                return;
                            }
                        }

                        $scope.isProcessingNewRecord = true;
                        var entity = {
                            id: _.max(_.pluck($scope.list, "id")) + 1,
                            value: $scope.newRecord,
                            enabled: true
                        };
                        if (entity.id <= 0) {
                            entity.id = 1;
                        }
                        $scope.list.push(entity);
                        updateConfig();
                    }
                };

                /** 
                 * Listens for API error occurrence during API operation.
                 */
                $scope.$on('apiErrorOccurred', function () {
                    $scope.isProcessingNewRecord = false;
                });

                /** 
                 * Updates the record.
                 */
                $scope.updateRecord = function () {
                    if ($scope.updatingRecord && $scope.updatingRecord.value.length) {
                        // var record = $scope.updatingRecord;
                        $scope.list[$scope.editingIndex] = $scope.updatingRecord;
                        updateConfig();
                        $scope.cancelEditingMode();
                    }
                };

                /** 
                 * Sets the edit mode for lookup entity.
                 */
                $scope.setEditingMode = function ($index) {
                    $scope.editingIndex = $index;
                    $scope.updatingRecord = $scope.list[$index];
                };

                /** 
                 * Cancels editing mode.
                 */
                $scope.cancelEditingMode = function () {
                    $scope.editingIndex = null;
                    $scope.updatingRecord = null;
                }
                // deleting entity
                $scope.deleting = {};

                /** 
                 * Shows the delete confirmation.
                 * @param {String} index the index
                 * @param {String} value the value of entity
                 */
                $scope.showDeleteConfirm = function (index, value) {
                    $scope.deleting = {
                        index: index,
                        value: value
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
                 * Remove the record.
                 */
                $scope.removeRecord = function () {
                    if ($scope.deleting && $scope.deleting.index >= 0) {
                        $scope.list.splice($scope.deleting.index, 1);
                        updateConfig();
                    }
                };

                /** 
                 * Listens for 'Enabled' check box changes.
                 */
                $scope.enableOrDisabled = function () {
                    updateConfig();
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
                        $scope.newRecord = '';
                        $scope.isProcessingNewRecord = false;
                    }, util.handleHttpError);
                };
            },
            link: function (scope, el) {
                var _ = $(el);
                //select item
                scope.select = function (item) {
                    if (_.hasClass('can-select')) {
                        scope.selected = item;
                    }
                };
            }
        };
    }]);
})();
