/*
 * Copyright (C) 2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is KPI lookup service. This is wrapper for the corresponding back end REST API.
 *
 * @author TCSDEVELOPER
 * @version 1.0
 */
(function () {
    'use strict';
    angular.module("app")
        .factory('KPILookupService', ['common', function (common) {
            var service = {};

            /**
             * Gets all lookups of the given type
             * @param {string} type - the type of the lookups to retrieve
             * @returns {promise} the promise with result
             */
            service.getLookupEntities = function (type) {
                var req = {
                    method: 'GET',
                    url: '/api/v1/lookups',
                    params: {
                        type: type
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all value entities of the given type
             * @param {string} type - the type of the value entities to retrieve
             * @returns {promise} the promise with result
             */
            service.getValueEntities = function (type) {
                var req = {
                    method: 'GET',
                    url: '/api/v1/values',
                    params: {
                        type: type
                    }
                };
                return common.makeRequest(req);
            };

            return service;
        }]);
})();