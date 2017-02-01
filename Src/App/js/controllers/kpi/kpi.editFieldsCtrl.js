/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for KPI edit fields page.
 * 
 * @author TCSASSEMBLER
 * @version 1.0
 */

(function () {
    'use strict';

    angular
      .module('app')
      .controller('kpiEditFieldsCtrl', ['$rootScope', '$scope', '$routeParams', '$location', '$anchorScroll', 'KPIScorecardConfigurationService', 'config', 'util',
        function ($rootScope, $scope, $routeParams, $location, $anchorScroll, KPIScorecardConfigurationService, config, util) {
            //sets the navigation menu as active
            $rootScope.currentMenu = config.MENUS.KPI.EDIT_FIELDS;
            if ($routeParams.section) {
                if ($routeParams.section == 'businessUnit') {
                    $scope.operationalIncidentClosed = true;
                    $scope.privacyIncidentClosed = true;
                    $scope.auditFindingClosed = true;
                }
                $location.hash('section-' + $routeParams.section);
                $anchorScroll();
            }

            $scope.config = {
                businessUnit: {
                    businessUnits: [],
                    monthConfig: [],
                    yearConfig: [],
                    volumeTypeConfig: [],
                    statusConfig: [],
                    operationPerformanceConfig: [],
                    financialIndicatorsConfig: [],
                    businessContinuityPlanningConfig: [],
                    securityConfig: [],
                    concentrationRiskConfig: []
                }
            };

            // load KPI Scorecard configuration
            KPIScorecardConfigurationService.get().then(function (data) {
                $scope.config = data;
            }, util.handleHttpError);
        }]);
})();