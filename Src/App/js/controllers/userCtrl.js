/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */

/**
 * This is controller for user management page.
 *
 * Changes in 1.1 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER
 * @version 1.1
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('userCtrl', ['$rootScope', '$scope', 'config', 'util', 'UserService', 'LookupService',
            function ($rootScope, $scope, config, util, UserService, LookupService) {
                //sets the navigation menu as active
                $rootScope.currentMenu = config.MENUS.USER;

                $scope.edit = {
                    isProcessing: false
                };

                $scope.searchResult = {
                    totalRecords: 0
                };   // searchResult:SearchResult<User>

                $scope.userToEdit = {};   // userToEdit:User

                $scope.data = {
                    businessUnits: [],
                    statuses: [
                        {
                            value: true,
                            name: 'Active'
                        },
                        {
                            value: false,
                            name: 'Inactive'
                        }
                    ]
                };
                // criteria:UserSearchCriteria
                $scope.criteria = {};

                // pagination parameters
                $scope.pageNumber = 1;
                $scope.pageSize = config.DEFAULT_PAGE_SIZE;
                $scope.sortBy = "Username";
                $scope.sortAscending = true;

                // deleting entity
                $scope.deleting = {};

                $scope.userValidation = {
                    errors: []
                };

                LookupService.getAllBusinessUnits().then(function (result) {
                    $scope.data.businessUnits = result;
                }, util.handleHttpError);

                /**
                 * Searches the users based on criteria
                 * @param {Boolean} resetPage flag whether to reset to page or not
                 */
                $scope.search = function (resetPage) {
                    $scope.isSearching = true;
                    if (resetPage) {
                        $scope.pageNumber = 1;
                    }
                    var criteria = _getCriteria();
                    if (criteria) {
                        UserService.search(criteria).then(function (searchResult) {
                            $scope.searchResult = searchResult;
                            $scope.isSearching = false;
                            $scope.isSearched = true;
                        }, function (error) {
                            $scope.isSearching = false;
                            util.handleHttpError(error);
                        });
                    }
                };


                /**
                 * Update the user
                 */
                $scope.update = function () {
                    var coeusRole;
                    if ($scope.userToEdit.role && $scope.userToEdit.role.length) {
                        coeusRole = $scope.userToEdit.role[0].value;
                    }
                    var kpiRole;
                    if ($scope.userToEdit.kpiRole && $scope.userToEdit.kpiRole.length) {
                        kpiRole = $scope.userToEdit.kpiRole[0].value
                    }
                    if (!coeusRole && !kpiRole) {
                        $scope.userValidation.errors.push("Please select user role.");
                    }
                    if (!$scope.userToEdit.businessUnits.length && !kpiRole) {
                        $scope.userValidation.errors.push("Please select at least one business unit.");
                    }
                    if ($scope.userValidation.errors.length === 0) {
                        $scope.edit.isProcessing = true;
                        var userToUpdate = angular.copy($scope.userToEdit);
                        userToUpdate.role = coeusRole;
                        userToUpdate.kpiRole = kpiRole;
                        UserService.update($scope.userToEdit.username, userToUpdate).then(function () {
                            $scope.edit.isProcessing = false;
                            $('#modal-edit-user').dialog('close');
                            $scope.search(false);
                        }, function (error) {
                            $scope.edit.isProcessing = false;
                            if (error.status === 404) {
                                $('#modal-edit-user').dialog('close');
                                _showPopupDialog("#user-delete-no-exists");
                            } else {
                                util.handleHttpError(error.error || "An error occurred while updating user.");
                            }
                        });
                    }
                };

                /**
                 * Deletes the user
                 */
                $scope.delete = function () {
                    if ($scope.deleting.username) {
                        $scope.edit.isProcessing = true;
                        var username = angular.copy($scope.deleting.username);
                        UserService.delete(username).then(function () {
                            $scope.edit.isProcessing = false;
                            delete $scope.deleting.username;
                            $scope.search(false);
                        }, function (error) {
                            delete $scope.deleting.username;
                            $scope.edit.isProcessing = false;
                            util.handleHttpError(error || "An error occurred while deleting user.");
                        });
                    }
                };

                /**
                 * Prepares the editing mode for edit
                 * @param {Object} user the user detail
                 */
                $scope.setEditMode = function (user) {
                   $scope.userValidation.errors = [];
                    $scope.userToEdit = angular.copy(user);
                    $scope.userToEdit.role = [{ value: user.role }];
                    $scope.userToEdit.kpiRole = [{ value: user.kpiRole }];
                    _showPopupDialog("#modal-edit-user");
                };

                /**
                 * Handles the page changed event
                 * @param {Number} newPage the new page number
                 */
                $scope.pageChanged = function (newPage) {
                    $scope.pageNumber = newPage;
                    $scope.search(false);
                };

                /**
                 * Resets the add/edit form
                 */
                $scope.resetForm = function () {
                    $scope.userToEdit = {};
                    $scope.edit.isProcessing = false;
                };

                /**
                 * cancels the edit
                 */
                $scope.cancelEdit = function () {
                    $("#modal-edit-user").dialog('close');
                    $scope.resetForm();
                };

                /** 
                 * Shows the delete confirmation.
                 * @param {String} username the username
                 */
                $scope.showDeleteConfirm = function (username) {
                    $scope.deleting.username = username;
                    _showPopupDialog("#modal-delete-user");
                };

                /**
                 * Handles the sorting event on column header
                 * @param {String} newSortingOrder the column name to sort by
                 */
                $scope.sort_by = function (newSortingOrder) {
                    if ($scope.sortBy === newSortingOrder) {
                        $scope.sortAscending = !$scope.sortAscending;
                    }
                    $scope.sortBy = newSortingOrder;
                    $scope.search(false);
                };

                /**
                 * Gets the search criteria
                 * @returns {Object} the user search criteria
                 * @private
                 */
                function _getCriteria() {
                    $scope.resetForm();
                    var criteria = {
                        PageNumber: $scope.pageNumber,
                        PageSize: $scope.pageSize,
                        SortBy: $scope.sortBy,
                        SortType: $scope.sortAscending ? config.SORT_DIR.ASC : config.SORT_DIR.DESC
                    };
                    if ($scope.criteria.username && $scope.criteria.username.length) {
                        criteria.Username = $scope.criteria.username;
                    }
                    if ($scope.criteria.realName && $scope.criteria.realName.length) {
                        criteria.RealName = $scope.criteria.realName;
                    }
                    if ($scope.criteria.businessUnits && $scope.criteria.businessUnits.length > 0) {
                        criteria.BusinessUnitIds = _.pluck($scope.criteria.businessUnits, 'id');
                    }
                    if ($scope.criteria.roles && $scope.criteria.roles.length > 0) {
                        criteria.roles = $scope.criteria.roles;
                    }
                    if ($scope.criteria.statuses && $scope.criteria.statuses.length === 1) {
                        criteria.Status = $scope.criteria.statuses[0];
                    }
                    return criteria;
                }

                // Shows the popup dialog
                function _showPopupDialog(id) {
                    var options = {
                        resizable: false,
                        modal: true,
                        dialogClass: "no-close",
                        closeOnEscape: false,
                        open: function () {
                            angular.element("body").css("overflow", "hidden");
                            $('.ui-widget-overlay').on('click', function () {
                                $(id).dialog('close');
                            });
                        },
                        close: function () {
                            angular.element("body").css("overflow", "auto");
                            $(this).dialog('destroy');
                        }
                    };
                    if (id === "#modal-edit-user") {
                        options.width = 470;
                    }

                    $(id).dialog(options).dialog('open');
                }

                // load the page with default criteria
                $scope.search(true);

            }
        ]);
})();
