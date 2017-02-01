/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for login page.
 *
 * Changes in 1.1:
 *  - Restrict admin user from login
 *
 * Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - removed the restriction for admin user from login
 *
 * @author veshu
 * @version 1.1
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginCtrl', ['$rootScope', '$scope', '$log', 'SecurityService', 'util',
            function ($rootScope, $scope, $log, SecurityService, util) {
                $scope.username = '';
                $scope.password = '';
                $scope.loginError = false;
                $scope.rememberMe = false;
                $rootScope.bodyClass = 'login-page';
                /**
                 * Handles the login request
                 */
                $scope.login = function () {
                    if ($scope.username === '' || $scope.password === '') {
                        $scope.loginError = true;
                        $scope.errorMessage = "Please enter username and password.";
                    } else {
                        SecurityService.login($scope.username, $scope.password).then(function (data) {
                            util.loginHandler(data, $scope.rememberMe);
                        }, function (error) {
                            $scope.loginError = true;
                            $scope.errorMessage = "Wrong username or password, please try again";
                            $log.error(error);
                        });
                    }
                };
            }]);
})();