/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is Business Unit KPI Scorecard service. This is wrapper for the corresponding back end REST API.
 *
 * @author TCSDEVELOPER
 * @version 1.0
 */
(function () {
    'use strict';
    angular.module("app")
        .factory('KPIScorecardService', ['common', function (common) {
            var service = {};

            /**
             * Gets KPI Scorecard input allowed days.
             * @returns {promise} the promise with result.
             */
            service.getInputAllowedDays = function () {
                var req = {
                    method: 'GET',
                    url: '/api/v1/businessUnitKPIScorecards/inputAllowedDays'
                };
                return common.makeRequest(req);
            };

            /**
             * Gets KPI Scorecard configuration.
             * @param {object} criteria - the KPI Scorecard search criteria.
             * @returns {promise} the promise with result.
             */
            service.search = function (criteria) {
                var req = {
                    method: 'GET',
                    url: '/api/v1/businessUnitKPIScorecards',
                    params: criteria
                };
                return common.makeRequest(req);
            };

            /**
             * Creates the KPI Scorecard.
             * @param {object} entity - the KPI Scorecard entity.
             * @returns {promise} the promise with result.
             */
            service.create = function (entity) {
                var req = {
                    method: 'POST',
                    url: '/api/v1/businessUnitKPIScorecards',
                    data: entity
                };
                return common.makeRequest(req);
            };

            /**
             * Updates the KPI Scorecard.
             * @param {object} entity - the KPI Scorecard entity.
             * @returns {promise} the promise with result.
             */
            service.update = function (entity) {
                var req = {
                    method: 'PUT',
                    url: '/api/v1/businessUnitKPIScorecards/' + entity.id,
                    data: entity
                };
                return common.makeRequest(req);
            };

            return service;
        }]);
})();