/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Application utility service
 *
 * Changes in 1.3:
 * - Added new methods
 * Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 * Changes in 1.3 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER, TCSASSEMBLER
 * @version 1.3
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('util', ['$rootScope', '$injector', 'storage', '$location', '$timeout', 'config', '$window',
            function ($rootScope, $injector, storage, $location, $timeout, config, $window) {
                var alertTimeout, errorAlertTimeout;
                var service = {};

                /**
                 * Checks the string if it is empty or not.
                 * @param {String} str the string to check
                 * @returns {String|Object} the trimmed string or null.
                 */
                service.getNullWhenEmpty = function (str) {
                    if (!str) {
                        return null;
                    }
                    else if (0 === str.trim().length) {
                        return null;
                    } else {
                        return str.trim();
                    }
                };

                /**
                 * Function to check if any user is currently logged in
                 */
                service.isLoggedIn = function () {
                    var profile = storage.getCurrentUserProfile();
                    var token = storage.getSessionToken();
                    if (token && moment(token.expirationDate) < moment()) {
                        token = undefined;
                    }
                    return !!(profile && token);
                };

                /**
                 * Checks if user has given role.
                 * @param {String} role the role
                 * @returns {Boolean} the check result.
                 */
                service.isUserInRole = function (role) {
                    var user = storage.getCurrentUserProfile();
                    if (!user) {
                        return false;
                    }
                    return user.role === role || user.kpiRole === role;
                };

                /**
                 * Login result handler
                 * @param {Object} data the login result
                 * @param {Boolean} rememberMe the flag if remember login
                 */
                service.loginHandler = function (data, rememberMe) {
                    storage.storeSessionToken(data.token, rememberMe);
                    $rootScope.user = data.user;

                    storage.storeCurrentUserProfile(data.user, rememberMe);
                    if ($rootScope.tmp && $rootScope.tmp.redirectUrl) {
                        $location.url($rootScope.tmp.redirectUrl);
                        $rootScope.tmp.redirectUrl = null;
                        return;
                    }
                    if ($rootScope.user.role !== config.ROLES.ADMIN_ROLE_NAME &&
                        (!$rootScope.user.role || !$rootScope.user.kpiRole)) {
                        $timeout(function () {
                            service.setAppSelectorEnabled();
                        }, 500);
                    }

                    $location.path($rootScope.getHome());
                };

                service.setAppSelectorEnabled = function () {
                    if ($rootScope.user.role !== config.ROLES.ADMIN_ROLE_NAME &&
                        (!$rootScope.user.role || !$rootScope.user.kpiRole)) {
                        $('.section-select-app .ms-parent button.ms-choice').prop('disabled', 'disabled');
                    }
                };

                /**
                 * Logout user and clear the data
                 */
                service.logout = function () {
                    if ($rootScope.tmp) {
                        delete $rootScope.tmp;
                    }
                    storage.clear();
                    $rootScope.user = null;
                    $location.path('/login');
                };

                /**
                 * Handles the Http request errors
                 * @param {String} response the error message from api.
                 */
                service.handleHttpError = function (response, doNotShowErrorMessage) {

                    if (response === "Token was not found or has been expired.") {
                        $injector.get('util').logout();
                        //it won't alert multiple times if there were parallel requests
                        if (alertTimeout) {
                            return;
                        }
                        setTimeout(function () {
                            alertTimeout = false;
                        }, 5000);
                        alertTimeout = true;
                        setTimeout(function () {
                            alert("Your session has expired. Please log in.");
                        }, 100);
                        return true;
                    } else {
                        var error = response || "An error occurred while processing your request.";
                        //it won't alert multiple times if there were parallel requests
                        if (errorAlertTimeout) {
                            return;
                        }
                        setTimeout(function () {
                            errorAlertTimeout = false;
                        }, 500);
                        errorAlertTimeout = true;
                        if (!doNotShowErrorMessage) {
                            service.showError(error);
                        }
                        $rootScope.$broadcast("apiErrorOccurred");
                    }
                };

                /**
                 * Shows the error message.
                 * @param message
                 */
                service.showError = function (message) {
                    $window.alert(message);
                };

                /**
                 * Shows the error message.
                 * @param message
                 */
                service.showInfo = function (message) {
                    $window.alert(message);
                };

                /**
                 * Apply base search criteria
                 * @param criteria the critria to update
                 * @param pageNumber the page number
                 * @param sortBy the sort by expression
                 * @param sortAscending the bool whether to sort by ascending or not
                 */
                service.applyBaseSearchCriteria = function (criteria, pageNumber, sortBy, sortAscending) {
                    criteria.PageNumber = pageNumber;
                    criteria.SortBy = sortBy;
                    criteria.SortType = sortAscending ? config.SORT_DIR.ASC : config.SORT_DIR.DESC;
                    criteria.pageSize = config.DEFAULT_PAGE_SIZE;
                    return criteria;
                };

                /**
                 * Gets the selected value of single dropdown
                 * @param model the ng-model
                 * @returns {Object} the object with id
                 */
                service.getSingleSelectValue = function (model) {
                    if (model && model[0]) {
                        return model[0];
                    } else {
                        return null;
                    }
                };

                /**
                 * Convert the object to array
                 * @param object the object to convert.
                 * @returns {Array}
                 */
                service.convertToArray = function (object) {
                    if (!object) {
                        return null;
                    } else {
                        return [object];
                    }
                };

                /**
                 * Converts the full date for view
                 * @param value the date
                 * @returns {*}
                 */
                service.convertDate = function (value) {
                    return value;
                };

                /**
                 * Creates the list of control assessments from process control assessment
                 * @param {Object} pca the process control assessment
                 * @returns {*} the assessment
                 */
                service.getControlAssessments = function (pca) {
                    var assessment = {};
                    assessment.riskExposure = pca.riskExposure;
                    if (pca.controlTypes) {
                        assessment.controlAssessments = [];
                        _.each(pca.controlTypes, function (controlType, index) {
                            var controlAssessment = {
                                controlType: {id: controlType.id, name: controlType.name}
                            };
                            if (typeof controlType.id === 'string') {
                                delete controlAssessment.controlType;
                                controlAssessment.otherControlType = pca.otherNames[controlType.id];
                            }
                            if (pca.inputs && pca.inputs && pca.inputs[index]) {
                                controlAssessment.controlFrequency = service.getSingleSelectValue(pca.inputs[index].controlFrequency);
                                controlAssessment.controlDesigns = pca.inputs[index].controlDesigns;
                                controlAssessment.testingFrequencies = pca.inputs[index].testingFrequencies;
                                controlAssessment.keyControlsMaturity = service.getSingleSelectValue(pca.inputs[index].keyControlsMaturity);
                                if (controlAssessment.testingFrequencies, {id: config.USER_DEFINED_TESTING_FREQUENCY_ID}) {
                                    controlAssessment.otherTestingFrequency = pca.inputs[index].otherTestingFrequency;
                                }
                                if (controlAssessment.keyControlsMaturity && controlAssessment.keyControlsMaturity.id === config.USER_DEFINED_KEY_CONTROLS_MATURITY_ID) {
                                    controlAssessment.otherKeyControlMaturity = pca.inputs[index].otherKeyControlMaturity;
                                }
                            }

                            assessment.controlAssessments.push(controlAssessment);
                        });
                    }
                    return assessment;
                };

                /**
                 * Creates the list of control assessments from functional area process assessment
                 * @param {Object} pca the functional control assessment
                 * @returns {*} the assessment
                 * @private
                 */
                service.getFunctionalAreaProcessControlAssessments = function (pca) {
                    var assessment = {};
                    assessment.likelihoodOfOccurrence = service.getSingleSelectValue(pca.likelihoodOfOccurrence);
                    if (assessment.likelihoodOfOccurrence && assessment.likelihoodOfOccurrence.id === config.USER_DEFINED_KEY_LIKELIHOOD_OF_OCCURRENCE_ID) {
                        assessment.otherLikelihoodOfOccurrence = pca.otherLikelihoodOfOccurrence;
                    }
                    assessment.riskImpacts = pca.riskImpacts;
                    assessment.riskExposure = pca.riskExposure;
                    if (pca.controlTypes) {
                        assessment.controlAssessments = [];
                        _.each(pca.controlTypes, function (controlType, index) {
                            var controlAssessment = {
                                controlType: {id: controlType.id, name: controlType.name}
                            };
                            if (typeof controlType.id === 'string') {
                                delete controlAssessment.controlType;
                                controlAssessment.otherControlType = pca.otherNames[controlType.id];
                            }
                            if (pca.inputs && pca.inputs && pca.inputs[index]) {
                                controlAssessment.controlObjective = pca.inputs[index].controlObjective;
                                controlAssessment.controlFrequency = service.getSingleSelectValue(pca.inputs[index].controlFrequency);
                                controlAssessment.controlDesigns = pca.inputs[index].controlDesigns;
                                controlAssessment.testingFrequencies = pca.inputs[index].testingFrequencies;
                                controlAssessment.controlTriggers = pca.inputs[index].controlTriggers;
                                controlAssessment.keyControlsMaturity = service.getSingleSelectValue(pca.inputs[index].keyControlsMaturity);

                                if (_.findWhere(controlAssessment.testingFrequencies, {id: config.USER_DEFINED_TESTING_FREQUENCY_ID})) {
                                    controlAssessment.otherTestingFrequency = pca.inputs[index].otherTestingFrequency;
                                }
                                if (controlAssessment.keyControlsMaturity && controlAssessment.keyControlsMaturity.id === config.USER_DEFINED_KEY_CONTROLS_MATURITY_ID) {
                                    controlAssessment.otherKeyControlMaturity = pca.inputs[index].otherKeyControlMaturity;
                                }
                            }

                            assessment.controlAssessments.push(controlAssessment);
                        });
                    }
                    return assessment;
                };

                /**
                 * Prepares the assessments to create
                 * @returns {Object} the assessment detail
                 */
                service.prepareAssessment = function (scope, rawAssessment) {
                    var assessment = {};
                    assessment.id = rawAssessment.id;
                    // required in export
                    assessment.submitter = {
                        firstName: $rootScope.user.firstName,
                        lastName: $rootScope.user.lastName
                    };
                    assessment.submitterUsername = $rootScope.user.username;

                    // first tab
                    assessment.title = rawAssessment.title;
                    assessment.businessUnit = service.getSingleSelectValue(rawAssessment.businessUnit);
                    assessment.products = rawAssessment.products;
                    assessment.department = service.getSingleSelectValue(rawAssessment.department);
                    assessment.departmentHead = service.getSingleSelectValue(rawAssessment.departmentHead);
                    assessment.functionalAreaOwner = service.getSingleSelectValue(rawAssessment.functionalAreaOwner);
                    assessment.functionalArea = service.getSingleSelectValue(rawAssessment.functionalArea);
                    assessment.functionalAreaDescription = rawAssessment.functionalAreaDescription;

                    // set function performed sites
                    assessment.functionPerformedSites = [];
                    _.each(rawAssessment.selectedSites, function (item) {
                        assessment.functionPerformedSites.push({
                            site: {id: item.id, name: item.name},
                            percentage: item.percentage
                        });
                    });
                    assessment.assessmentType = service.getSingleSelectValue(rawAssessment.assessmentType);
                    assessment.assessmentStatus = service.getSingleSelectValue(rawAssessment.assessmentStatus);
                    assessment.assessmentDueDate = rawAssessment.dueDate;

                    // second tab
                    if (scope.functionChanges.isPriorChanges) {
                        var priorFunctionChanges = [];
                        _.each(scope.functionChanges.priorChanges, function (change) {
                            if (change.changeType && change.changeTime && change.changeDescription) {
                                var changeItem = {
                                    changeType: service.getSingleSelectValue(change.changeType),
                                    changeTime: change.changeTime,
                                    changeDescription: change.changeDescription
                                };
                                priorFunctionChanges.push(changeItem);
                            }
                        });
                        if (priorFunctionChanges.length > 0) {
                            assessment.priorFunctionChanges = priorFunctionChanges;
                        }
                    }
                    if (scope.functionChanges.isFutureChanges) {
                        var futureFunctionChanges = [];
                        _.each(scope.functionChanges.futureChanges, function (change) {
                            if (change.changeType && change.changeTime && change.changeDescription) {
                                var changeItem = {
                                    changeType: service.getSingleSelectValue(change.changeType),
                                    changeTime: change.changeTime,
                                    changeDescription: change.changeDescription
                                };
                                futureFunctionChanges.push(changeItem);
                            }
                        });
                        if (futureFunctionChanges.length > 0) {
                            assessment.futureFunctionChanges = futureFunctionChanges;
                        }
                    }

                    // third tab
                    var kPISLAAssessments = service.prepareKPIAssessments(scope);
                    if (kPISLAAssessments.length > 0) {
                        assessment.kPISLAAssessments = kPISLAAssessments;
                    }
                    var functionalAreaProcessAssessments = service.prepareFunctionalProcessAssessment(scope);
                    if (functionalAreaProcessAssessments.length > 0) {
                        assessment.functionalAreaProcessAssessments = functionalAreaProcessAssessments;
                    }
                    var processRiskAssessments = service.prepareProcessRiskAssessment(scope);
                    if (processRiskAssessments) {
                        assessment.processRiskAssessments = processRiskAssessments;
                    }
                    // fourth tab
                    assessment.overallRiskRatingCommentary = rawAssessment.overallRiskRatingCommentary;
                    return assessment;
                };

                /**
                 * Prepares the KPI & SLA's assessments
                 * @private
                 */
                service.prepareKPIAssessments = function (scope) {
                    var kPISLAAssessments = [];
                    // get KPI SLA Assessments
                    var category = _.findWhere(scope.lookups.categories, {id: config.KPISLA_ASSESSMENT_CATEGORY_ID});
                    _.each(scope.assessments.kPISLAAssessments, function (groupAssessment) {
                        _.each(groupAssessment.KPIs, function (item) {
                            if (item.id > 0 || item.additionalKPI) {
                                var kpiSLAAssessment = {};
                                kpiSLAAssessment.selectedSLA = service.getSingleSelectValue(item.selectedSLA);
                                kpiSLAAssessment.category = category;
                                kpiSLAAssessment.KPICategory = {
                                    id: groupAssessment.KPICategory.id,
                                    name: groupAssessment.KPICategory.name
                                };
                                if (item.id > 0) {
                                    kpiSLAAssessment.KPI = {id: item.id, name: item.name};
                                } else {
                                    kpiSLAAssessment.additionalKPI = item.additionalKPI;
                                    kpiSLAAssessment.KPI = null;
                                }
                                if (kpiSLAAssessment.selectedSLA && typeof kpiSLAAssessment.selectedSLA.id === 'string') {
                                    delete kpiSLAAssessment.selectedSLA;
                                    kpiSLAAssessment.additionalSLA = item.additionalSLA;
                                }
                                if (kpiSLAAssessment) {
                                    kPISLAAssessments.push(kpiSLAAssessment);
                                }
                            }
                        });
                    });
                    // get additional KPI SLA Assessments
                    _.each(scope.additional.kPISLAAssessments, function (groupAssessment) {
                        groupAssessment.additionalKPICategory = groupAssessment.KPIs[0].additionalKPICategory;
                        _.each(groupAssessment.KPIs, function (item, index) {
                            if (groupAssessment.additionalKPICategory && (index === 0 || (index > 0 && item.additionalKPI))) {
                                var kpiSLAAssessment = {};
                                kpiSLAAssessment.selectedSLA = service.getSingleSelectValue(item.selectedSLA);
                                kpiSLAAssessment.category = category;
                                kpiSLAAssessment.additionalKPICategory = groupAssessment.additionalKPICategory;
                                kpiSLAAssessment.additionalKPI = item.additionalKPI;
                                kpiSLAAssessment.KPICategory = null;
                                kpiSLAAssessment.KPI = null;
                                if (kpiSLAAssessment.selectedSLA && typeof kpiSLAAssessment.selectedSLA.id === 'string') {
                                    delete kpiSLAAssessment.selectedSLA;
                                    kpiSLAAssessment.additionalSLA = item.additionalSLA;
                                }
                                if (kpiSLAAssessment) {
                                    kPISLAAssessments.push(kpiSLAAssessment);
                                }
                            }
                        });
                    });
                    return kPISLAAssessments;
                };

                /**
                 * Prepares the functional area process assesments
                 * @private
                 */
                service.prepareFunctionalProcessAssessment = function (scope) {
                    var functionalAreaProcessAssessments = [];
                    var category = _.findWhere(scope.lookups.categories, {id: config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID});
                    _.each(scope.assessments.functionalAssessments, function (groupAssessment) {
                        if (groupAssessment) {
                            _.each(groupAssessment.subProcessRisks, function (item) {
                                if (item.id > 0 || item.additionalSubProcess) {
                                    var functionalAreaProcessAssessment = service.getFunctionalAreaProcessControlAssessments(item);
                                    functionalAreaProcessAssessment.coreProcess = {
                                        id: groupAssessment.coreProcess.id,
                                        name: groupAssessment.coreProcess.name
                                    };
                                    functionalAreaProcessAssessment.category = category;
                                    if (item.id > 0) {
                                        functionalAreaProcessAssessment.subProcessRisk = {
                                            id: item.id,
                                            name: item.name,
                                            risk: item.risk
                                        };
                                    } else {
                                        functionalAreaProcessAssessment.additionalSubProcess = item.additionalSubProcess;
                                        functionalAreaProcessAssessment.additionalRisk = item.additionalRisk;
                                        functionalAreaProcessAssessment.subProcessRisk = null;
                                    }
                                    if (functionalAreaProcessAssessment) {
                                        functionalAreaProcessAssessments.push(functionalAreaProcessAssessment);
                                    }
                                }
                            });
                        }
                    });
                    // get additional functional area process Assessments
                    _.each(scope.additional.functionalAssessments, function (groupAssessment) {
                        if (groupAssessment) {
                            groupAssessment.additionalCoreProcess = groupAssessment.subProcessRisks[0].additionalCoreProcess;
                            _.each(groupAssessment.subProcessRisks, function (item, index) {
                                if (groupAssessment.additionalCoreProcess && (index === 0 || (index > 0 && item.additionalSubProcess))) {
                                    var functionalAreaProcessAssessment = service.getFunctionalAreaProcessControlAssessments(item);
                                    functionalAreaProcessAssessment.category = category;
                                    functionalAreaProcessAssessment.additionalCoreProcess = groupAssessment.additionalCoreProcess;
                                    functionalAreaProcessAssessment.additionalSubProcess = item.additionalSubProcess;
                                    functionalAreaProcessAssessment.additionalRisk = item.additionalRisk;
                                    functionalAreaProcessAssessment.coreProcess = null;
                                    functionalAreaProcessAssessment.subProcessRisk = null;
                                    if (functionalAreaProcessAssessment) {
                                        functionalAreaProcessAssessments.push(functionalAreaProcessAssessment);
                                    }
                                }
                            });
                        }
                    });
                    return functionalAreaProcessAssessments;
                };

                /**
                 * Prepares the process risk assessments
                 * @param scope
                 * @returns {Array}
                 */
                service.prepareProcessRiskAssessment = function (scope) {
                    var processRiskAssessments = [];
                    // get process risk Assessments
                    _.each(scope.assessments.processRiskAssessments, function (processRiskAssessmentContainer) {
                        if (processRiskAssessmentContainer) {
                            var categoryType = processRiskAssessmentContainer.categoryType;
                            _.each(processRiskAssessmentContainer.assessments, function (item) {
                                var riskAssessment = service.getControlAssessments(item);

                                riskAssessment.processRisk = item.processRisk;
                                riskAssessment.category = categoryType;

                                if (riskAssessment) {
                                    processRiskAssessments.push(riskAssessment);
                                }
                            });
                        }
                    });
                    // get additional process risk Assessments
                    _.each(scope.additional.processRiskAssessments, function (processRiskAssessmentContainer) {
                        if (processRiskAssessmentContainer) {
                            var categoryType = processRiskAssessmentContainer.categoryType;
                            _.each(processRiskAssessmentContainer.assessments, function (item) {
                                if (item.additionalProcess) {
                                    var riskAssessment = service.getControlAssessments(item);
                                    riskAssessment.processRisk = null;
                                    riskAssessment.additionalProcess = item.additionalProcess;
                                    riskAssessment.additionalRisk = item.additionalRisk;
                                    riskAssessment.category = categoryType;

                                    if (riskAssessment) {
                                        processRiskAssessments.push(riskAssessment);
                                    }
                                }
                            });
                        }
                    });
                    return processRiskAssessments;
                };

                /**
                 * Validates the assessment for submit
                 * @param assessment
                 * @returns {boolean}
                 */
                service.validateFailed = function (assessment, scope) {
                    var failed = false;
                    if (!assessment.businessUnit) {
                        return true;
                    }
                    if (!assessment.products || !assessment.products.length) {
                        return true;
                    }
                    if (!assessment.department) {
                        return true;
                    }
                    if (!assessment.departmentHead) {
                        return true;
                    }
                    if (!assessment.functionalAreaOwner) {
                        return true;
                    }
                    if (!assessment.functionalArea) {
                        return true;
                    }
                    if (!assessment.functionalAreaDescription) {
                        return true;
                    }
                    if (scope.totalPercentageSum !== 100) {
                        return true;
                    }
                    if (!assessment.assessmentType) {
                        return true;
                    }
                    if (!assessment.assessmentStatus) {
                        return true;
                    }
                    if (!assessment.assessmentDueDate) {
                        return true;
                    }

                    if (scope.functionChanges.isPriorChanges) {
                        _.each(scope.functionChanges.priorChanges, function (change) {
                            if (!change.changeType || !change.changeTime || !change.changeDescription) {
                                failed = true;
                            }
                        });
                        if (failed) {
                            return failed;
                        }
                    }

                    if (scope.functionChanges.isFutureChanges) {
                        _.each(scope.functionChanges.futureChanges, function (change) {
                            if (!change.changeType || !change.changeTime || !change.changeDescription) {
                                failed = true;
                            }
                        });
                        if (failed) {
                            return failed;
                        }
                    }

                    if (assessment.kPISLAAssessments) {
                        var kpiError = false;
                        angular.forEach(assessment.kPISLAAssessments, function (kpislaAssessment) {
                            if (kpislaAssessment.KPICategory === null) {
                                if (!kpislaAssessment.additionalKPICategory) {
                                    kpiError = true;
                                }
                            }
                            if (kpislaAssessment.KPI === null) {
                                if (!kpislaAssessment.additionalKPI) {
                                    kpiError = true;
                                }
                            }
                            if (!kpislaAssessment.selectedSLA) {
                                kpiError = true;
                            }
                        });

                        if (kpiError) {
                            // to focus correct tab
                            scope.pca.categoryType = config.KPISLA_ASSESSMENT_CATEGORY_ID;
                            return kpiError;
                        }
                    }
                    if (assessment.functionalAreaProcessAssessments) {
                        var functionalAreaError = false;
                        angular.forEach(assessment.functionalAreaProcessAssessments, function (functionalAssessment) {
                            if (!functionalAreaError) {
                                if (functionalAssessment.coreProcess === null) {
                                    if (!functionalAssessment.additionalCoreProcess) {
                                        functionalAreaError = true;
                                    }
                                }
                                if (functionalAssessment.processRisk === null) {
                                    if (!functionalAssessment.additionalSubProcess || !functionalAssessment.additionalRisk) {
                                        functionalAreaError = true;
                                    }
                                }
                                if (!functionalAssessment.likelihoodOfOccurrence) {
                                    functionalAreaError = true;
                                }
                                if (!functionalAssessment.riskImpacts || !functionalAssessment.riskImpacts.length) {
                                    functionalAreaError = true;
                                }
                                if (!functionalAssessment.riskExposure) {
                                    functionalAreaError = true;
                                }
                                if (functionalAssessment.controlAssessments && functionalAreaError === false) {
                                    angular.forEach(functionalAssessment.controlAssessments, function (controlAssessment) {
                                        if (!controlAssessment.controlType || (controlAssessment.controlType && controlAssessment.controlType.id !== config.NO_CONTROLS_IN_PLACE_CONTROL_TYPE_ID)) {
                                            if (!controlAssessment.controlObjective) {
                                                functionalAreaError = true;
                                            }
                                            if (!controlAssessment.controlFrequency) {
                                                functionalAreaError = true;
                                            }
                                            if (!controlAssessment.controlDesigns || !controlAssessment.controlDesigns.length) {
                                                functionalAreaError = true;
                                            }
                                            if (!controlAssessment.testingFrequencies || !controlAssessment.testingFrequencies.length) {
                                                functionalAreaError = true;
                                            }
                                            if (!controlAssessment.controlTriggers || !controlAssessment.controlTriggers.length) {
                                                functionalAreaError = true;
                                            }
                                            if (!controlAssessment.keyControlsMaturity) {
                                                functionalAreaError = true;
                                            }
                                        }
                                    });
                                } else {
                                    // no control is selected
                                    functionalAreaError = true;
                                }
                            }
                        });

                        if (functionalAreaError) {
                            // to focus correct tab
                            scope.pca.categoryType = config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID;
                            return functionalAreaError;
                        }
                    }
                    if (assessment.processRiskAssessments) {
                        var processRiskError = false;
                        var currentCategory = 0;
                        angular.forEach(scope.lookups.categories, function (category) {
                            if (category.id !== config.KPISLA_ASSESSMENT_CATEGORY_ID &&
                                category.id !== config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID && !processRiskError) {
                                currentCategory = category.id;
                                var result = [];
                                angular.forEach(assessment.processRiskAssessments, function (item) {
                                    if (item && item.category && item.category.id === category.id) {
                                        result.push(item);
                                    }
                                });

                                angular.forEach(result, function (processRiskAssessment) {
                                    if (processRiskAssessment.processRisk === null) {
                                        if (!processRiskAssessment.additionalProcess || !processRiskAssessment.additionalRisk) {
                                            processRiskError = true;
                                        }
                                    }
                                    if (!processRiskAssessment.riskExposure) {
                                        processRiskError = true;
                                    }

                                    if (processRiskAssessment.controlAssessments) {
                                        angular.forEach(processRiskAssessment.controlAssessments, function (controlAssessment) {
                                            if (!controlAssessment.controlType || (controlAssessment.controlType && controlAssessment.controlType.id !== config.NO_CONTROLS_IN_PLACE_CONTROL_TYPE_ID)) {
                                                if (!controlAssessment.controlFrequency) {
                                                    processRiskError = true;
                                                }
                                                if (!controlAssessment.controlDesigns || !controlAssessment.controlDesigns.length) {
                                                    processRiskError = true;
                                                }
                                                if (!controlAssessment.testingFrequencies || !controlAssessment.testingFrequencies.length) {
                                                    processRiskError = true;
                                                }
                                                if (!controlAssessment.keyControlsMaturity) {
                                                    processRiskError = true;
                                                }
                                            }
                                        });
                                    } else {
                                        // no control is selected
                                        processRiskError = true;
                                    }
                                });
                            }
                        });
                        if (processRiskError) {
                            // to focus correct tab
                            scope.pca.categoryType = currentCategory;
                            return processRiskError;
                        }
                    }
                    return false;
                };

                /**
                 * Gets the lookup values required
                 */
                service.getLookupValues = function (scope, LookupService) {
                    LookupService.getAllCategories().then(function (result) {
                        scope.lookups.categories = result;
                        //set first tab as selected
                        scope.pca.categoryType = result[0].id;
                    }, service.handleHttpError);

                    LookupService.getAllBusinessUnits().then(function (result) {
                        scope.lookups.businessUnits = result;
                    }, service.handleHttpError);

                    LookupService.getAllRiskExposures().then(function (result) {
                        scope.lookups.riskExposures = result;
                    }, service.handleHttpError);

                    LookupService.getAllPercentages().then(function (result) {
                        scope.lookups.percentages = result;
                    }, service.handleHttpError);

                    LookupService.getAllAssessmentTypes().then(function (result) {
                        scope.lookups.assessmentTypes = result;
                    }, service.handleHttpError);

                    LookupService.getAllAssessmentStatuses().then(function (result) {
                        scope.lookups.assessmentStatuses = result;
                    }, service.handleHttpError);

                    LookupService.getAllChangeTypes().then(function (result) {
                        scope.lookups.changeTypes = result;
                    }, service.handleHttpError);

                    LookupService.getAllSites().then(function (result) {
                        scope.lookups.sites = result;
                    }, service.handleHttpError);

                    LookupService.getAllLikelihoodOfOccurrences().then(function (result) {
                        scope.lookups.likelihoodOfOccurrences = result;
                    }, service.handleHttpError);

                    LookupService.getAllControlFrequencies().then(function (result) {
                        scope.lookups.controlFrequencys = result;
                    }, service.handleHttpError);
                    LookupService.getAllControlDesigns().then(function (result) {
                        scope.lookups.controlDesigns = result;
                    }, service.handleHttpError);
                    LookupService.getAllTestingFrequencies().then(function (result) {
                        scope.lookups.testingFrequencies = result;
                    }, service.handleHttpError);
                    LookupService.getAllControlTriggers().then(function (result) {
                        scope.lookups.controlTriggers = result;
                    }, service.handleHttpError);
                    LookupService.getAllKeyControlsMaturities().then(function (result) {
                        scope.lookups.keyControlsMaturities = result;
                    }, service.handleHttpError);
                };

                /**
                 * Prepares the additional sls
                 * @param kpiCategories
                 * @returns {Array}
                 * @private
                 */
                service.prepareAdditionalSLAsAssessments = function (kpiCategories) {
                    var result = [];
                    _.each(kpiCategories, function (kpiCategory) {
                        _.each(kpiCategory.slAs, function (sla) {
                            result.push(sla);
                        });
                    });
                    result = _.sortBy(_.uniq(result, function (i) {
                        return i.name.toLowerCase();
                    }), function (i) {
                        return i.displayOrder;
                    });
                    return result;
                };

                /**
                 * Prepares the control types for additional core process
                 * @param kpiCategories
                 * @returns {Array}
                 * @private
                 */
                service.prepareAdditionalFunctionalControlTypes = function (coreProcesses) {
                    var result = [];
                    _.each(coreProcesses, function (coreProcess) {
                        _.each(coreProcess.controlTypes, function (controlType) {
                            result.push(controlType);
                        });
                    });
                    result = _.sortBy(_.uniq(result, function (i) {
                        return i.name.toLowerCase();
                    }), function (i) {
                        return i.displayOrder;
                    });
                    return result;
                };

                /**
                 * Prepares the control types for additional process risk
                 * @param processRisks
                 * @param categoryId
                 * @returns {Array}
                 * @private
                 */
                service.prepareAdditionalProcessRiskControlTypes = function (processRisks, categoryId) {
                    processRisks = _.filter(processRisks, function (item) {
                        return item.category.id === parseInt(categoryId);
                    });
                    var result = [];
                    _.each(processRisks, function (coreProcess) {
                        _.each(coreProcess.controlTypes, function (controlType) {
                            result.push(controlType);
                        });
                    });
                    result = _.sortBy(_.uniq(result, function (i) {
                        return i.name.toLowerCase();
                    }), function (i) {
                        return i.displayOrder;
                    });
                    return result;
                };

                /**
                 * Get the donut chart options
                 * @param {Array} colors the colors used in chart
                 * @returns {Object} the chart option
                 */
                service.getDonutChartOption = function (colors) {
                    var options = {
                        seriesDefaults: {
                            // use the donut chart renderer
                            renderer: jQuery.jqplot.DonutRenderer,
                            rendererOptions: {
                                totalLabel: true,
                                highlightMouseOver: true,
                                shadowAlpha: 0
                            }
                        },
                        legend: {
                            show: false
                        },
                        grid: {
                            drawGridlines: true,
                            background: "transparent",
                            shadow: false,
                            borderWidth: 0
                        }
                    };
                    if (colors) {
                        options.seriesColors = colors;
                        options.seriesDefaults.rendererOptions.varyBarColor = true;
                    }
                    return options;
                };

                /**
                 * Gets the chart option
                 * @param {Array} ticks the ticks
                 * @param {Array} colors the colors used in chart
                 * @returns {Object} the chart option.
                 */
                service.getBarChartOption = function (ticks, colors) {
                    var options = {
                        animate: true,
                        seriesDefaults: {
                            renderer: $.jqplot.BarRenderer,
                            pointLabels: {
                                show: true,
                                formatString: "%#.2f"
                            },
                            rendererOptions: {
                                highlightMouseOver: true,
                                shadowAlpha: 0
                            }
                        },
                        axes: {
                            xaxis: {
                                renderer: $.jqplot.CategoryAxisRenderer,
                                rendererOptions: {drawBaseline: true},
                                tickOptions: {
                                    fontSize: '8pt',
                                    showGridline: false
                                }
                            },
                            yaxis: {
                                tickOptions: {
                                    show: true
                                },
                                rendererOptions: {
                                    drawBaseline: true
                                }
                            }
                        },
                        grid: {
                            drawGridlines: true,
                            background: "transparent",
                            shadow: false,
                            borderWidth: 0
                        },
                        legend: {
                            show: false,
                        }
                    };
                    if (ticks) {
                        options.axes.xaxis.ticks = ticks;
                    }
                    if (colors) {
                        options.seriesColors = colors;
                        options.seriesDefaults.rendererOptions.varyBarColor = true;
                    }
                    return options;
                };

                /**
                 * Prepares the data for risk rating table
                 * @param data the risk score data
                 * @param scope the current scope
                 * @param riskScoreRange the risk score range detail
                 */
                service.prepareRiskScoreTableData = function (data, scope, riskScoreRange) {
                    var sortedRange = _.sortBy(riskScoreRange, function (item) {
                        return -item.lowerBound;
                    });
                    var categoryRiskScores = _.map(data.categoryInherentRiskScores, function (item) {
                        return {
                            inherent: {
                                score: item.score,
                                color: service.getColor(sortedRange, item.score)
                            },
                            name: item.category.name,
                            id: item.category.id,
                            weight: item.category.weight
                        }
                    });
                    categoryRiskScores = _.map(categoryRiskScores, function (item) {
                        var residual = _.find(data.categoryResidualRiskScores, function (rs) {
                            return rs.category.id === item.id;
                        });
                        if (residual) {
                            item.residual = {
                                score: residual.score,
                                color: service.getColor(sortedRange, residual.score)
                            }
                        }
                        return item;
                    });
                    var result = {
                        overallInherentRiskScore: data.overallInherentRiskScore,
                        overallInherentColor: service.getColor(sortedRange, data.overallInherentRiskScore),
                        overallResidualRiskScore: data.overallResidualRiskScore,
                        overallResidualColor: service.getColor(sortedRange, data.overallResidualRiskScore),
                        categoryRiskScores: categoryRiskScores
                    };
                    scope.chartData.riskScoreTableData = result;
                };

                /**
                 * Prepares the risk exposure graph
                 * @param data the risk score data
                 * @param scope the current scope
                 * @param riskScoreRange the risk score range detail
                 */
                service.prepareRiskExposureGraph = function (data, scope, riskScoreRange) {
                    var charts = ['overallInherentRiskScore', 'overallResidualRiskScore'];
                    _.each(charts, function (chartType) {
                        var value = parseFloat(data[chartType].toFixed(2));
                        var colors = service.getColorSeries([value], riskScoreRange);
                        scope.chartOptions[chartType] = service.getDonutChartOption(colors);
                        scope.chartData[chartType] = [[value]];
                    });
                };

                /**
                 * Prepares the category bars charts
                 * @param data the risk score data
                 * @param scope the current scope
                 * @param riskScoreRange the risk score range detail
                 */
                service.prepareCategoryBarCharts = function (data, scope, riskScoreRange) {
                    var charts = ['categoryInherentRiskScores', 'categoryResidualRiskScores'];
                    _.each(charts, function (chartType) {
                        var keyValue = _.map(data[chartType], function (item) {
                            return {
                                score: parseFloat(item.score.toFixed(2)),
                                name: item.category.name.split(' ').join('<br/>')
                            };
                        });
                        var axes = _.pluck(keyValue, 'score');
                        var ticks = _.pluck(keyValue, 'name');
                        var colors = service.getColorSeries(axes, riskScoreRange);
                        scope.chartOptions[chartType] = service.getBarChartOption(ticks, colors);
                        scope.chartData[chartType] = [axes];
                    });
                };

                /**
                 * Gets the color series for given data series using risk score range
                 * @param series the risk score series data
                 * @param riskScoreRange the risk score range detail
                 * @returns {Array|*} the color series
                 */
                service.getColorSeries = function (series, riskScoreRange) {
                    var sortedRange = _.sortBy(riskScoreRange, function (item) {
                        return -item.lowerBound;
                    });
                    return _.map(series, function (dataValue) {
                        return service.getColor(sortedRange, dataValue);
                    });
                };

                /**
                 * Gets the color value for a given risk score value
                 * @param sortedRange the risk score range detail sorted by lower bound in descending
                 * @param dataValue the risk score value for which range color is needed
                 * @returns {string} the color code for given data value
                 */
                service.getColor = function (sortedRange, dataValue) {
                    var range = _.find(sortedRange, function (item) {
                        return dataValue >= item.lowerBound
                    });
                    if (range) {
                        return range.color;
                    }
                };

                return service;
            }
        ]);
})();

