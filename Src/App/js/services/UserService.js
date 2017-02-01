/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is user service. This is wrapper for the corresponding back end REST API.
 *
 * @author veshu
 * @version 1.0
 */
(function () {
    'use strict';

    angular
        .module("app")
        .factory('UserService', ['common', function (common) {
            var service = {};

            /**
             * Updates the user
             * @param {String} username the username of user to update
             * @param {Object} entity the user detail
             * @returns {promise} the promise with result
             */
            service.update = function (username, entity) {
                var req = {
                    method: 'PUT',
                    url: '/api/v1/users/' + username,
                    data: entity
                };
                return common.makeRequestWithStatus(req);
            };

            /**
             * Deletes the user
             * @param {String} username the username of user to delete
             * @returns {promise} the promise with result
             */
            service.delete = function (username) {
                var req = {
                    method: 'DELETE',
                    url: '/api/v1/users/',
                    params: {
                        username: username
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Searches the users
             * @param {Object} criteria the search criteria
             * @returns {promise} the promise with result
             */
            service.search = function (criteria) {
                var req = {
                    method: 'GET',
                    url: '/api/v1/users',
                    params: criteria
                };
                return common.makeRequest(req);
            };

            return service;
        }]);
})();