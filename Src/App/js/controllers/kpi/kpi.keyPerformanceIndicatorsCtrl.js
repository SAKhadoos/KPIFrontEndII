/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for Key Performance Indicators page.
 * 
 * @author TCSASSEMBLER
 * @version 1.0
 */

(function () {
    'use strict';

    angular
      .module('app')
      .controller('keyPerformanceIndicatorsCtrl', ['$rootScope', '$scope', '$timeout', '$window', '$filter', 'config', 'storage',
          'util', 'KPIScorecardConfigurationService', 'KPIScorecardService', 'KPILookupService',
        function ($rootScope, $scope, $timeout, $window, $filter, config, storage,
            util, KPIScorecardConfigurationService, KPIScorecardService, KPILookupService) {

            //sets the navigation menu as active
            $rootScope.currentMenu = config.MENUS.KPI.KPIs;
            $scope.showFilter = true;
            $scope.editMode = true;
            $scope.filter = {};
            $scope.existing = {};

            // load Business Unit configuration
            KPIScorecardConfigurationService.getBusinessUnitConfiguration().then(function (data) {
                $scope.config = data;

                // auto-select year and month from saved preferences
                var userPrefs = storage.getCurrentUserPreferences($rootScope.user.username);
                if (userPrefs) {
                    if (userPrefs.yearId) {
                        var year = getById($scope.config.yearConfig, { id: userPrefs.yearId });
                        if (year) {
                            $scope.filter.years = [year];
                        }
                    }
                    if (userPrefs.monthId) {
                        var month = getById($scope.config.monthConfig, { id: userPrefs.monthId });
                        if (month) {
                            $scope.filter.months = [month];
                        }
                    }
                }
            }, function (message) {
                showHttpErrorMessage('Failed to retrieve Business Unit configuration: ' + message);
            });

            // get allowed input days
            KPIScorecardService.getInputAllowedDays().then(function (data) {
                $scope.inputAllowedDays = data;
            }, function (message) {
                showHttpErrorMessage('Failed to retrieve input allowed days: ' + message);
            });

            // get Low Performance Reasons
            KPILookupService.getLookupEntities('LowPerformanceReason').then(function (data) {
                $scope.lowPerformanceReasons = data;
            }, function (message) {
                showHttpErrorMessage('Failed to retrieve Low Performance Reason lookups: ' + message);
            });

            // gets a value indicating whether current user is Admin
            $scope.isAdmin = function () {
                return $rootScope.user && $rootScope.user.role === config.ROLES.ADMIN_ROLE_NAME;
            };

            // gets a value indicating whether a new scorecard will be created if Submit button is clicked
            $scope.isNewScorecard = function () {
                var businessUnit = getSelectValue($scope.filter.businessUnits);
                var year = getSelectValue($scope.filter.years);
                var month = getSelectValue($scope.filter.months);

                return !$scope.existing.id ||
                    businessUnit !== $scope.existing.businessUnit ||
                    year !== $scope.existing.year ||
                    month !== $scope.existing.month;
            };

            // gets number of days between two dates
            function dateDiffInDays(fromDate, toDate) {
                var _MS_PER_DAY = 1000 * 60 * 60 * 24;
                // Discard the time and time-zone information.
                var utc1 = Date.UTC(fromDate.getFullYear(), fromDate.getMonth(), fromDate.getDate());
                var utc2 = Date.UTC(toDate.getFullYear(), toDate.getMonth(), toDate.getDate());
                return Math.floor((utc2 - utc1) / _MS_PER_DAY);
            }

            // gets number of days left allowed to modify scorecard
            $scope.getInputDaysLeft = function() {
                var year = getSelectValue($scope.filter.years);
                var month = getSelectValue($scope.filter.months);
                if (year && month) {
                    var date = new Date(Date.parse(month.value + " 1, " + year.value));
                    var today = new Date();
                    var daysPassed = dateDiffInDays(date, today);
                    var daysLeft = $scope.inputAllowedDays - daysPassed + 1;
                    return daysLeft > 0 ? daysLeft : 0;
                }
                else {
                    return $scope.inputAllowedDays;
                }
            };

            // toggles edit/read-only mode based on input data
            $scope.updateEditMode = function () {
                $scope.editMode = $scope.isNewScorecard() ||
                    $scope.existing.isDraft ||
                    ($scope.isAdmin() && $scope.getInputDaysLeft() > 0);
            };

            // saves user preferences (select Month and Year)
            $scope.savePreferences = function () {
                var year = getSelectValue($scope.filter.years);
                var month = getSelectValue($scope.filter.months);
                var prefs = {};
                if (year) {
                    prefs.yearId = year.id;
                }
                if (month) {
                    prefs.monthId = month.id;
                }
                storage.saveCurrentUserPreferences($rootScope.user.username, prefs);
            };

            // gets score value of the given KPI item
            $scope.getScoreValue = function (item) {
                if (!item.score) {
                    return null;
                }
                if (item.score == item.threshold.value) {
                    return 'normal';
                }
                if ((item.score < item.threshold.value && item.targetHigh) ||
                    (item.score > item.threshold.value && !item.targetHigh)) {
                    return 'bad';
                }
                return 'good';
            };

            // checks whether score of a given KPI is good/green
            $scope.isGoodScore = function (item) {
                return $scope.getScoreValue(item) === 'good';
            };

            // checks whether score of a given KPI is bad/red
            $scope.isBadScore = function (item) {
                return $scope.getScoreValue(item) === 'bad';
            };

            // checks whether score of a given KPI exactly matches threshold
            $scope.isNormalScore = function (item) {
                return $scope.getScoreValue(item) === 'normal';
            };

            // searches for a Scorecard
            $scope.search = function () {
                var businessUnit = getSelectValue($scope.filter.businessUnits);
                var year = getSelectValue($scope.filter.years);
                var month = getSelectValue($scope.filter.months);

                var errorMessage;
                if (!businessUnit) {
                    errorMessage = "Please select Business Unit.";
                }
                else if (!year) {
                    errorMessage = "Please select Reporting Year.";
                }
                else if (!month) {
                    errorMessage = "Please select Reporting Month.";
                }

                if (errorMessage) {
                    showMessage(errorMessage);
                    return;
                }

                var criteria = {
                    businessUnitId: businessUnit.id,
                    yearId: year.id,
                    monthId: month.id
                };

                KPIScorecardService.search(criteria).then(function (data) {
                    if (data.items.length) {
                        loadScorecard(data.items[0]);
                    }
                    else {
                        loadScorecard({});
                    }
                }, function (message) {
                    showHttpErrorMessage('Failed to search KPI Scorecards: ' + message);
                });
            };

            // loads Scorecard to reflect in UI
            function loadScorecard(entity) {
                $scope.existing.id = entity.id;
                $scope.existing.businessUnit = getById($scope.config.businessUnits, entity.businessUnit);
                $scope.existing.year = getById($scope.config.yearConfig, entity.year);
                $scope.existing.month = getById($scope.config.monthConfig, entity.month);
                $scope.existing.isDraft = entity.completionType === 'Draft';

                if (entity.id) {
                    $scope.filter.businessUnits = [$scope.existing.businessUnit];
                    $scope.filter.years = [$scope.existing.year];
                    $scope.filter.months = [$scope.existing.month];
                    $scope.filter.statuses = [getById($scope.config.statusConfig, entity.status)];
                    $scope.filter.dueDate = entity.dueDate;
                }

                loadKPIScores('operationPerformanceConfig', entity.operationPerformanceScores);
                loadKPIScores('financialIndicatorsConfig', entity.financialIndicatorScores);
                loadKPIScores('businessContinuityPlanningConfig', entity.businessContinuityPlanningScores);
                loadKPIScores('securityConfig', entity.securityScores);
                loadKPIScores('concentrationRiskConfig', entity.concentrationRiskScores);
                $scope.updateEditMode();
            };

            // gets selected value in single-select drop-down
            function getSelectValue(selectModel) {
                if (selectModel && selectModel.length) {
                    return selectModel[0];
                }
                return null;
            };

            // gets entity from values matching entity.id
            function getById(values, entity) {
                if (!entity) {
                    return null;
                }
                var filtered = $filter('filter')(values, { id: entity.id });
                if (filtered.length) {
                    return filtered[0];
                }
                return null;
            };

            // gets entities from values matching entities[].id
            function getByIds(values, entities) {
                if (!entities) {
                    return null;
                }
                var result = [];
                for (var index in entities) {
                    var resolved = getById(values, entities[index]);
                    if (resolved) {
                        result.push(resolved);
                    }
                }
                return result;
            };

            // submits the Scorecard
            $scope.submit = function (completionType) {
                // require business unit, month, year
                var entity = {
                    id: $scope.existing.id,
                    businessUnit: getSelectValue($scope.filter.businessUnits),
                    status: getSelectValue($scope.filter.statuses),
                    year: getSelectValue($scope.filter.years),
                    month: getSelectValue($scope.filter.months),
                    dueDate: $scope.filter.dueDate,
                    completionType: completionType
                };

                var errorMessage;
                if (!entity.businessUnit) {
                    errorMessage = "Please select Business Unit.";
                }
                else if (!entity.status) {
                    errorMessage = "Please select Status.";
                }
                else if (!entity.year) {
                    errorMessage = "Please select Reporting Year.";
                }
                else if (!entity.month) {
                    errorMessage = "Please select Reporting Month.";
                }
                else if (!entity.dueDate) {
                    errorMessage = "Please select Due Date.";
                }
                else if ($('.input-error').length) {
                    errorMessage = "Please fill Scores and Volumes for all Key Performance Indicators.";
                }
                else if ($('.select-input-error').length) {
                    errorMessage = "Please select Volume Types for all Key Performance Indicators.";
                }
                else if ($scope.getInputDaysLeft() === 0) {
                    errorMessage = "Cannot submit due to restriction of input allowed days.";
                }
                if (errorMessage) {
                    showMessage(errorMessage);
                    return;
                }

                entity.operationPerformanceScores = getKPIScores('operationPerformanceConfig');
                entity.financialIndicatorScores = getKPIScores('financialIndicatorsConfig');
                entity.businessContinuityPlanningScores = getKPIScores('businessContinuityPlanningConfig');
                entity.securityScores = getKPIScores('securityConfig');
                entity.concentrationRiskScores = getKPIScores('concentrationRiskConfig');

                // construct entity
                var isDraft = completionType === 'Draft';
                if ($scope.isNewScorecard()) {
                    KPIScorecardService.create(entity).then(function (data) {
                        entity.id = data;
                        loadScorecard(entity);
                        showPopupSubmitPerformance(isDraft);
                    }, function (message) {
                        showHttpErrorMessage('Failed to create new KPI Scorecard: ' + message);
                    });
                }
                else {
                    KPIScorecardService.update(entity).then(function (data) {
                        entity = data;
                        loadScorecard(entity);
                        showPopupSubmitPerformance(isDraft);
                    }, function (message) {
                        showHttpErrorMessage('Failed to update KPI Scorecard: ' + message);
                    });
                }
            };

            // gets KPI scores for a given config type
            function getKPIScores(configType) {
                var scores = $scope.config[configType];
                var kpiScores = [];
                for (var index in scores) {
                    var item = scores[index];
                    var kpiScore = {
                        scorecardItem: item,
                        score: item.score,
                        lowPerformanceReasons: item.lowPerformanceReasons,
                        volume: item.volume,
                        volumeType: getSelectValue(item.volumeTypes)
                    };
                    // lowPerformanceReasons should only be saved for bad(red) scores
                    if (!$scope.isBadScore(item)) {
                        kpiScore.lowPerformanceReasons = [];
                    }
                    kpiScores.push(kpiScore);
                }

                return kpiScores;
            };

            // loads KPI scores for a given config type
            function loadKPIScores(configType, kpiScores) {
                var scores = $scope.config[configType];

                // clear scores, if nothing provided
                if (!kpiScores) {
                    for (var index in scores) {
                        var item = scores[index];
                        item.score = null;
                        item.lowPerformanceReasons = null;
                        item.volume = null;
                        item.volumeTypes = null;
                    }
                    return;
                }

                for (var index in kpiScores) {
                    var kpiScore = kpiScores[index];
                    var filtered = $filter('filter')(scores, { id: kpiScore.scorecardItem.id });
                    if (filtered.length) {
                        var score = filtered[0];
                        score.score = kpiScore.score;
                        score.lowPerformanceReasons = getByIds($scope.lowPerformanceReasons, kpiScore.lowPerformanceReasons);
                        score.volume = kpiScore.volume;
                        score.volumeTypes = [getById($scope.config.volumeTypeConfig, kpiScore.volumeType)];
                    }
                }
            };

            // shows error occurred while accessing server
            function showHttpErrorMessage(message) {
                if (!util.handleHttpError(message, true)) {
                    showMessage(message);
                }
            }

            // shows pop-up with a given message
            function showMessage(text) {
                $scope.messageText = text;
                $scope.showMessage = true;
                $timeout(function () {
                    if (angular.element(document.querySelectorAll('#wrapper'))[0].offsetHeight > $window.innerHeight) {
                        angular.element(document.querySelectorAll('.dark-overlay')).css("height", angular.element(document.querySelectorAll('#wrapper'))[0].offsetHeight + "px");
                    } else {
                        angular.element(document.querySelectorAll('.dark-overlay')).css("height", $window.innerHeight + "px");
                    }
                }, 50);
            };

            // shows/hides submit Scorecard pop-up 
            function showPopupSubmitPerformance(isDraft) {
                if (isDraft) {
                    showMessage('Your monthly Key Performance Indicators has been saved.');
                }
                else {
                    showMessage('Your monthly Key Performance Indicators has been submitted.');
                }
            };
        }]);
})();