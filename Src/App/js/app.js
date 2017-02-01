/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * The main application entry
 *
 * * Changes in 1.1:
 *  - added new dependency
 *
 * Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - added a check when route is changed to check if any dialog is opened or not if yes then close
 *
 * Changes in 1.3 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 1
 * Changes in 1.4 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.5 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER
 * @version 1.5
 */

(function () {
    'use strict';

    var app = angular.module('app', ['ngAnimate', 'ngRoute', 'ngSanitize', 'ngFileSaver',
        'angularMoment', 'ngMultiSelect.directive', 'angularUtils.directives.dirPagination',
        'ui.sortable', 'ngDragDrop', 'angularFileUpload','ngFileUpload']);

    // Initialize the main module
    app.run(['$rootScope', '$location', '$window', '$log', 'storage', 'config', 'util',
        function ($rootScope, $location, $window, $log, storage, config, util) {

            //keep temporary data between controllers
            $rootScope.appSelector = {
                choices: [config.KPI_APP_NAME, config.COEUS_APP_NAME]
            };

            $rootScope.tmp = {};
            $rootScope.location = $location;
            $rootScope.config = config;
            $rootScope.goto = function (path) {
                if (path === 'back') { // Allow a 'back' keyword to go to previous page
                    $window.history.back();
                } else { // Go to the specified path
                    $location.path(path);
                }
            };

            /**
             * Get homepage URL based on role
             * @return {String} the URL
             */
            $rootScope.getHome = function () {
                if (!util.isLoggedIn()) {
                    return "/login";
                }
                else {
                    if ($rootScope.user.role) {
                        return '/home';
                    }
                    else {
                        return '/kpi/home'
                    }
                }
            };

            $rootScope.$on('$routeChangeStart', function (e, target) {
                var route = target.$$route;
                if (!route) {
                    return;
                }
                if (!$rootScope.tmp) {
                    $rootScope.tmp = {};
                }
                if (route.originalPath !== '/login') {
                    $rootScope.tmp.redirectUrl = route.originalPath;
                }

                if (route.originalPath === '/login' && util.isLoggedIn()) {
                    $location.path($rootScope.getHome());
                }
                if (route.isPublic) {
                    return;
                }

                if (!util.isLoggedIn()) {
                    $location.path('/login');
                    return;
                }

                if (!route.roles) {
                    return;
                }
                var hasAccess = _.any(route.roles, util.isUserInRole);
                if (!hasAccess) {
                    $rootScope.tmp.redirectUrl = null;
                    $location.path($rootScope.getHome());
                }
            });
            $rootScope.$on('$routeChangeSuccess', function () {
                $rootScope.path = $location.path();
                $rootScope.bodyClass = $rootScope.path === '/login' ? 'login-page' : '';
                $rootScope.getCounts();
            });
            if (!util.isLoggedIn()) {
                storage.clear();
            } else {
                $rootScope.user = storage.getCurrentUserProfile();
            }
        }]);
    app.config(function ($compileProvider) {
        $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|file|javascript|blob):/);
        $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|ftp|file|blob|content):|data:image\//);
    });
    app.config(['$httpProvider', "config", function ($httpProvider, config) {
        //disable IE ajax request caching
        $httpProvider.interceptors.push(function () {
            return {
                request: function (reqConfig) {
                    if (reqConfig.url.indexOf(config.REST_SERVICE_BASE_URL) === 0) {
                        reqConfig.headers['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
                    }
                    return reqConfig;
                }
            };
        });
    }]);
    app.config(["$routeProvider", 'config',
        function ($routeProvider, config) {
            var urlBase = "partials/";
            $routeProvider.when('/login', {
                templateUrl: urlBase + 'login.html',
                controller: 'loginCtrl',
                isPublic: true
            }).when('/home', {
                templateUrl: urlBase + 'home.html',
                controller: 'homeCtrl',
                roles: [config.ROLES.OWNER_ROLE_NAME, config.ROLES.BU_FUNCTIONAL_APPROVER_ROLE_NAME,
                config.ROLES.BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME,
                config.ROLES.DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME, config.ROLES.ADMIN_ROLE_NAME]
            }).when('/addAssessment', {
                templateUrl: urlBase + 'addAssessment.html',
                controller: 'addAssessmentCtrl',
                roles: [config.ROLES.OWNER_ROLE_NAME, config.ROLES.ADMIN_ROLE_NAME]
            }).when('/editAssessment/:id', {
                templateUrl: urlBase + 'editAssessment.html',
                controller: 'editAssessmentCtrl',
                roles: [config.ROLES.OWNER_ROLE_NAME, config.ROLES.BU_FUNCTIONAL_APPROVER_ROLE_NAME,
                config.ROLES.BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME, config.ROLES.ADMIN_ROLE_NAME,
                config.ROLES.DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME]
            }).when('/assessments/:type', {
                templateUrl: urlBase + 'assessments.html',
                controller: 'assessmentsCtrl',
                roles: [config.ROLES.OWNER_ROLE_NAME, config.ROLES.BU_FUNCTIONAL_APPROVER_ROLE_NAME,
                config.ROLES.BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME, config.ROLES.ADMIN_ROLE_NAME,
                config.ROLES.DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME]
            }).when('/assessmentDetails/:id', {
                templateUrl: urlBase + 'assessmentDetail.html',
                controller: 'assessmentDetailsCtrl',
                roles: [config.ROLES.OWNER_ROLE_NAME, config.ROLES.BU_FUNCTIONAL_APPROVER_ROLE_NAME,
                config.ROLES.BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME, config.ROLES.ADMIN_ROLE_NAME,
                config.ROLES.DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME]
            }).when('/users', {
                templateUrl: urlBase + 'users.html',
                controller: 'userCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit', {
                templateUrl: urlBase + 'admin/bu-info.html',
                controller: 'editFieldsBUInfoCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit/processes/:categoryId?', {
                templateUrl: urlBase + 'admin/processes.html',
                controller: 'editFieldsProcessesCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit/globalFields', {
                templateUrl: urlBase + 'admin/globalFields.html',
                controller: 'editFieldsGlobalCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit/riskCalculation', {
                templateUrl: urlBase + 'admin/riskCalculation.html',
                controller: 'editFieldsRiskCalculationCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit/addon', {
                templateUrl: urlBase + 'admin/addon.html',
                controller: 'editFieldsAddOnCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/admin/edit/bulkdata', {
                templateUrl: urlBase + 'admin/bulkdata.html',
                controller: 'editFieldsBulkImportCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/kpi/editFields', {
                templateUrl: urlBase + 'kpi/editFields.html',
                controller: 'kpiEditFieldsCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME]
            }).when('/kpi/home', {
                templateUrl: urlBase + 'kpi/keyPerformanceIndicators.html',
                controller: 'keyPerformanceIndicatorsCtrl',
                roles: [config.ROLES.ADMIN_ROLE_NAME, config.ROLES.KPI_USER_ROLE_NAME]
            }).otherwise({
                redirectTo: '/login'
            });
        }]);
    app.run(function ($rootScope) {
        $rootScope.$on('$routeChangeSuccess', function () {
            // checks if any dialog is opened and close if true
            // fixes the issue of pressing back button when dialog is opened
            if ($('.ui-dialog:visible').length) {
                $('.ui-dialog-content').dialog("close");
            }
        });
    });
})();
