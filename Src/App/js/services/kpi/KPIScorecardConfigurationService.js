/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is KPI Scorecard Configuration service. This is wrapper for the corresponding back end REST API.
 *
 * @author TCSDEVELOPER
 * @version 1.0
 */
(function () {
    'use strict';
    angular.module("app")
        .factory('KPIScorecardConfigurationService', ['common', function (common) {
            var service = {};

            /**
             * Gets KPI Scorecard configuration.
             * @returns {promise} the promise with result.
             */
            service.get = function () {
                var req = {
                    method: 'GET',
                    url: '/api/v1/kpiScorecardConfiguration'
                };
                return common.makeRequest(req);
            };

            /**
             * Gets KPI Business Unit configuration.
             * @returns {promise} the promise with result.
             */
            service.getBusinessUnitConfiguration = function () {
                var req = {
                    method: 'GET',
                    url: '/api/v1/businessUnitConfiguration'
                };
                return common.makeRequest(req);
            };

            /**
             * Updates the KPI Scorecard configuration.
             * @param {object} config - the KPI Scorecard configuration.
             * @returns {promise} the promise with result.
             */
            service.set = function (config) {
                var req = {
                    method: 'PUT',
                    url: '/api/v1/kpiScorecardConfiguration',
                    data: config
                };
                return common.makeRequest(req);
            };

            return service;
        }]);
})();