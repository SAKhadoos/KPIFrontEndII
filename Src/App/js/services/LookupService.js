/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is lookup service. This is wrapper for the corresponding back end REST API.
 *
 * Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 1
 *
 * @author veshu
 * @version 1.1
 */
(function () {
    'use strict';
    angular.module("app")
        .factory('LookupService', ['common', function (common) {
            var service = {};

            /**
             * Gets all assessment status
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllAssessmentStatuses = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/assessmentStatuses',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all change types
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllChangeTypes = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/changeTypes',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all sites
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllSites = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/sites',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all business units
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllBusinessUnits = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/businessUnits',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all department heads
             * @params {Number} businessUnitId the business unit id
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllDepartmentHeads = function (businessUnitId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/departmentHeads',
                    params: {
                        businessUnitId: businessUnitId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all Products
             * @params {Number} businessUnitId the business unit id
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllProducts = function (businessUnitId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/products',
                    params: {
                        businessUnitId: businessUnitId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all departments
             * @params {Number} businessUnitId the business unit id
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllDepartments = function (businessUnitId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/departments',
                    params: {
                        businessUnitId: businessUnitId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all assessment types
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllAssessmentTypes = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/assessmentTypes',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all risk exposures
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllRiskExposures = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/riskExposures',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all categories
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllCategories = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/categories',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all likelihood of occurrences
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllLikelihoodOfOccurrences = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/likelihoodOfOccurrences',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all risk impacts
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllRiskImpacts = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/riskImpacts',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all KPI Categories
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getKPICategories = function (businessUnitId, functionalAreaId, includeDisabled, includeGlobal) {
                includeDisabled = includeDisabled || false;
                if (typeof includeGlobal === 'undefined') {
                    includeGlobal = true;
                }
                var req = {
                    method: 'GET',
                    url: '/api/v1/KPICategories',
                    params: {
                        businessUnitId: businessUnitId,
                        functionalAreaId: functionalAreaId,
                        includeDisabled: includeDisabled,
                        includeGlobal: includeGlobal
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all process risks
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllProcessRisks = function (businessUnitId, functionalAreaId, includeDisabled, includeGlobal) {
                includeDisabled = includeDisabled || false;
                if (typeof includeGlobal === 'undefined') {
                    includeGlobal = true;
                }
                var req = {
                    method: 'GET',
                    url: '/api/v1/processRisks',
                    params: {
                        businessUnitId: businessUnitId,
                        functionalAreaId: functionalAreaId,
                        includeDisabled: includeDisabled,
                        includeGlobal: includeGlobal
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all control frequencies
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllControlFrequencies = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/controlFrequencies',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all control triggers
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllControlTriggers = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/controlTriggers',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all key controls maturities
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllKeyControlsMaturities = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/keyControlsMaturities',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all control designs
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllControlDesigns = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/controlDesigns',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all testing frequencies
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllTestingFrequencies = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/testingFrequencies',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all percentages
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllPercentages = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/percentages',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets the functional area owners by business unit id
             * @params {Number} businessUnitId the business unit id
             * @params {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getFunctionalAreaOwners = function (businessUnitId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/functionalAreaOwners',
                    params: {
                        businessUnitId: businessUnitId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets the functional areas by business unit id
             * @params {Number} businessUnitId the business unit id
             * @returns {promise} the promise with result
             */
            service.getFunctionalAreas = function (businessUnitId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/functionalAreas',
                    params: {
                        businessUnitId: businessUnitId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets the core processes by functional area id
             * @params {Number} functionalAreaId the functional area id
             * @params {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getCoreProcesses = function (businessUnitId, functionalAreaId, includeDisabled, includeGlobal) {
                includeDisabled = includeDisabled || false;
                if (typeof includeGlobal === 'undefined') {
                    includeGlobal = true;
                }
                var req = {
                    method: 'GET',
                    url: '/api/v1/coreProcesses',
                    params: {
                        businessUnitId: businessUnitId,
                        functionalAreaId: functionalAreaId,
                        includeDisabled: includeDisabled,
                        includeGlobal: includeGlobal
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to create a lookup entity.
             * @params {String} type the entity type, e.g. "Category".
             * @params {Object} entity the entity values
             * @returns {promise} the promise with result
             */
            service.createLookupEntity = function (type, entity) {
                var basePath = _getBasePath(type);
                var path = '/api/v1/' + basePath;
                var req = {
                    method: 'POST',
                    url: path,
                    data: entity
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to update a lookup entity.
             * @params {String} type the entity type, e.g. "Category".
             * @params {Number} id the entity id
             * @params {Object} entity the entity values
             * @returns {promise} the promise with result
             */
            service.updateLookupEntity = function (type, id, entity) {
                var basePath = _getBasePath(type);
                var path = '/api/v1/' + basePath + '/' + id;
                var req = {
                    method: 'PUT',
                    url: path,
                    data: entity
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to delete a lookup entity.
             * @params {String} type the entity type, e.g. "Category".
             * @params {Number} id the entity id
             * @returns {promise} the promise with result
             */
            service.deleteLookupEntity = function (type, id, entity) {
                var basePath = _getBasePath(type);
                var path = '/api/v1/' + basePath + '/' + id;

                var req = {
                    method: 'DELETE',
                    url: path,
                    data: entity
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to reorder lookup entity.
             * @params {String} type the entity type, e.g. "Category".
             * @params {Array} ids the entity ids
             * @params {Array} orders the display orders
             * @returns {promise} the promise with result
             */
            service.reorderLookupEntities = function (type, ids, orders) {
                var basePath = _getBasePath(type);
                var path = '/api/v1/' + basePath + '/reorder';
                var req = {
                    method: 'PUT',
                    url: path,
                    data: {
                        ids: ids,
                        displayOrders: orders
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to get pending add-ons.
             * @returns {promise} the promise with result
             */
            service.getPendingAddOns = function () {
                var req = {
                    method: 'GET',
                    url: '/api/v1/pendingAddOns'
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to get count of pending add-ons.
             * @returns {promise} the promise with result
             */
            service.countPendingAddOns = function () {
                var req = {
                    method: 'GET',
                    url: '/api/v1/countOfPendingAddOns'
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to import lookup entities.
             * @params {Object} file the file
             * @returns {promise} the promise with result
             */
            service.importLookupEntities = function (file) {
                var formData = new FormData();
                formData.append('file', file);

                var req = {
                    method: 'POST',
                    url: '/api/v1//importLookupEntities/',
                    headers: {
                        'Content-Type': undefined
                    },
                    transformRequest: angular.identity,
                    data: formData
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to get functional areas by business unit and category.
             * @params {Number} businessUnitId the business unit it
             * @params {Number} categoryId the category id
             * @params {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getFunctionalAreasWithCategory = function (businessUnitId, categoryId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/functionalAreas',
                    params: {
                        businessUnitId: businessUnitId,
                        categoryId: categoryId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to get business units by category.
             * @param {Number} categoryId the category id
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllBusinessUnitsByCategory = function (categoryId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/businessUnits',
                    params: {
                        categoryId: categoryId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * This method is used to get risk score ranges.
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllRiskScoreRanges = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/riskScoreRanges',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all Control types for given category
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllControlTypes = function (categoryId, includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/controlTypes',
                    params: {
                        categoryId: categoryId,
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets all SLAs
             * @param {Boolean} includeDisabled the flag whether to include the disabled or not
             * @returns {promise} the promise with result
             */
            service.getAllSLAs = function (includeDisabled) {
                includeDisabled = includeDisabled || false;
                var req = {
                    method: 'GET',
                    url: '/api/v1/slas',
                    params: {
                        includeDisabled: includeDisabled
                    }
                };
                return common.makeRequest(req);
            };

            /**
             * Gets the base path for a lookup type
             * @param {String} type the lookup entity type
             * @returns {String} the url path of api for respective entity type.
             */
            function _getBasePath(type) {
                var mapping = {
                    AssessmentStatus: 'assessmentStatuses',
                    AssessmentType: 'assessmentTypes',
                    BusinessUnit: 'businessUnits',
                    Department: 'departments',
                    DepartmentHead: 'departmentHeads',
                    FunctionalArea: 'functionalAreas',
                    FunctionalAreaOwner: 'functionalAreaOwners',
                    Product: 'products',
                    Category: 'categories',
                    ChangeType: 'changeTypes',
                    ControlDesign: 'controlDesigns',
                    ControlFrequency: 'controlFrequencies',
                    ControlTrigger: 'controlTriggers',
                    ControlType: 'controlTypes',
                    CoreProcess: 'coreProcesses',
                    KeyControlsMaturity: 'keyControlsMaturities',
                    KPI: 'kpis',
                    KPICategory: 'kpiCategories',
                    LikelihoodOfOccurrence: 'likelihoodOfOccurrences',
                    Percentage: 'percentages',
                    ProcessRisk: 'processRisks',
                    SubProcessRisk: 'subProcessRisks',
                    RiskExposure: 'riskExposures',
                    RiskImpact: 'riskImpacts',
                    Site: 'sites',
                    SLA: 'slas',
                    TestingFrequency: 'testingFrequencies',
                    RiskScoreRange: 'riskScoreRanges'
                };
                return mapping[type];
            }

            return service;
        }]);
})();