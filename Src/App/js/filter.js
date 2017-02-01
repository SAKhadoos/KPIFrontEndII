/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Application filters.
 *
 * Changes 1.1:
 * - added new filters
 *
 * Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - added 'roleName' and 'activeInactive' filter
 *
 * Changes in 1.3 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.4 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 * 
 * @author veshu, TCSASSEMBLER
 * @version 1.4
 */
(function () {
    'use strict';

    var app = angular.module("app");

    // if dropdown value is not selected then return select word
    app.filter('isSelected', function () {
        return function (value) {
            if (!value || value.length <= 0) {
                return '-';
            } else {
                return value;
            }
        };
    });

    // if dropdown value is not selected then return select word
    app.filter('enabledOnly', function () {
        return function (items) {
            if (!items || !items.length) {
                return items;
            }
            return items.filter(function (element) {
                return element.enabled;
            });
        };
    });

    // display yes/no or comment if available when not tested
    app.filter('testComment', function () {
        return function (input) {
            if (!input) {
                return null;
            } else if (input.tested === 'true' || input.tested === true) {
                return 'Yes';
            } else if (input.tested === 'false' || input.tested === false) {
                if (input.testedComment) {
                    return input.testedComment;
                } else {
                    return 'No';
                }
            }
            else {
                return null;
            }
        };
    });

    // filter to join array of lookup by comma
    app.filter('joinByComma', function () {
        return function (input) {
            return (_.pluck(input, 'name')).join(', ');
        };
    });

    // filter to display yes/no
    app.filter('decimalOrPercent', function () {
        return function (input) {
            if (!input) {
                return input;
            }
            return input.value + (input.percentage ? '%' : '');
        };
    });

    // filter to display yes/no
    app.filter('yesNo', function () {
        return function (input) {
            if (input === 'true') {
                return 'Yes';
            } else if (input === 'false') {
                return 'No';
            } else {
                return null;
            }
        };
    });

    // process risk category
    app.filter('processCategories', ['config', function (config) {
        return function (categories) {
            var result = [];
            angular.forEach(categories, function (category) {
                if (category && category.id !== config.KPISLA_ASSESSMENT_CATEGORY_ID &&
                    category.id !== config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID) {
                    result.push(category);
                }
            });
            return result;
        };
    }]);

    // gets the approver name from latest approver/rejecter of the assessment
    app.filter('approverName', function () {
        return function (assessment) {
            if (!assessment) {
                return '';
            }
            var approver;
            if (assessment.rejecter) {
                approver = assessment.rejecter;
            } else if (assessment.divisionalRiskManagementApprover) {
                approver = assessment.divisionalRiskManagementApprover;
            } else if (assessment.buRiskManagementApprover) {
                approver = assessment.buRiskManagementApprover;
            } else if (assessment.buFunctionalApprover) {
                approver = assessment.buFunctionalApprover;
            }

            if (approver) {
                return approver.firstName + " " + approver.lastName;
            }
        };
    });

    // returns display name of approval status
    app.filter('approvalStatus', ['config', function (config) {
        return function (status) {
            var map = _.findWhere(config.APPROVAL_STATUS, {value: status});
            if (map) {
                return map.displayName;
            } else {
                return status;
            }
        };
    }]);

    // returns display name of user
    app.filter('fullName', function () {
        return function (user) {
            if (user) {
                return user.firstName + " " + user.lastName;
            } else {
                return '';
            }
        };
    });

    // returns the count of control assessments selected
    app.filter('controlAssessmentCount', function () {
        return function (controlAssessments) {
            if (controlAssessments && controlAssessments.length > 0) {
                if (controlAssessments.length === 1) {
                    return '1 Control';
                } else {
                    return controlAssessments.length + ' Controls';
                }
            } else {
                return null;
            }
        };
    });

    /**
     * Shows the key control maturity in edit page
     */
    app.filter('keyControlMaturity', ['config', function (config) {
        return function (controlAssessment) {
            if (controlAssessment && controlAssessment.keyControlsMaturity && controlAssessment.keyControlsMaturity[0]) {
                if (controlAssessment.keyControlsMaturity[0].id === config.USER_DEFINED_KEY_CONTROLS_MATURITY_ID) {
                    return controlAssessment.otherKeyControlMaturity || controlAssessment.keyControlsMaturity[0].name;
                } else {
                    return controlAssessment.keyControlsMaturity[0].name;
                }
            } else {
                return null;
            }
        };
    }]);

    /**
     * Shows the key control maturity in detail page
     */
    app.filter('keyControlMaturityDetail', ['config', function (config) {
        return function (controlAssessment) {
            if (controlAssessment && controlAssessment.keyControlsMaturity) {
                if (controlAssessment.keyControlsMaturity.id === config.USER_DEFINED_KEY_CONTROLS_MATURITY_ID) {
                    return controlAssessment.otherKeyControlMaturity || controlAssessment.keyControlsMaturity.name;
                } else {
                    return controlAssessment.keyControlsMaturity.name;
                }
            } else {
                return null;
            }
        };
    }]);

    /**
     * Shows the testing frequencies
     */
    app.filter('testingFrequencies', ['config', function (config) {
        return function (controlAssessment) {
            if (controlAssessment && controlAssessment.testingFrequencies) {
                var names = _.pluck(controlAssessment.testingFrequencies, 'name');
                var notTestingFrequency = _.findWhere(controlAssessment.testingFrequencies, {id: config.USER_DEFINED_TESTING_FREQUENCY_ID});
                if (notTestingFrequency && controlAssessment.otherTestingFrequency) {
                    //remove not testing name and add user defined frequency
                    names = _.without(names, notTestingFrequency.name);
                    names.push(controlAssessment.otherTestingFrequency);
                }
                if (names.length > 0) {
                    return names.join(', ');
                } else {
                    return null;
                }
            } else {
                return null;
            }
        };
    }]);

    /**
     * Shows the likelihood of occurrence in edit page
     */
    app.filter('likelihoodOfOccurrence', ['config', function (config) {
        return function (assessment) {
            if (assessment && assessment.likelihoodOfOccurrence && assessment.likelihoodOfOccurrence[0]) {
                if (assessment.likelihoodOfOccurrence[0].id === config.USER_DEFINED_KEY_LIKELIHOOD_OF_OCCURRENCE_ID) {
                    return assessment.otherLikelihoodOfOccurrence || assessment.likelihoodOfOccurrence[0].name;
                } else {
                    return assessment.likelihoodOfOccurrence[0].name;
                }
            } else {
                return null;
            }
        };
    }]);

    /**
     * Shows the likelihood of occurrence in detail page
     */
    app.filter('likelihoodOfOccurrenceDetail', ['config', function (config) {
        return function (assessment) {
            if (assessment && assessment.likelihoodOfOccurrence) {
                if (assessment.likelihoodOfOccurrence.id === config.USER_DEFINED_KEY_LIKELIHOOD_OF_OCCURRENCE_ID) {
                    return assessment.otherLikelihoodOfOccurrence || assessment.likelihoodOfOccurrence.name;
                } else {
                    return assessment.likelihoodOfOccurrence.name;
                }
            } else {
                return null;
            }
        };
    }]);

    /**
     * Shows the role name based on role value
     */
    app.filter('roleName', ['config', function (config) {
        return function (role) {
            var map = _.findWhere(config.ROLE_WITH_NAMES, {value: role});
            if (map) {
                return map.name;
            } else {
                return role;
            }
        };
    }]);

    // filter boolean to active/inactive
    app.filter('activeInactive', function () {
        return function (input) {
            if (input === true) {
                return 'Active';
            }
            else {
                return 'Inactive';
            }
        };
    });

    // filters the process without corp category
    app.filter('processCategoriesWithoutCORP', ['config', function (config) {
        return function (categories) {
            var result = [];
            angular.forEach(categories, function (category) {
                if (category && category.id !== config.KPISLA_ASSESSMENT_CATEGORY_ID &&
                    category.id !== config.FUNCTIONAL_ASSESSMENT_CATEGORY_ID &&
                    category.id !== config.CORP_DIV_TRAINING_ASSESSMENT_CATEGORY_ID) {
                    result.push(category);
                }
            });
            return result;
        };
    }]);

    // core process categories filter
    app.filter('corpProcessCategories', ['config', function (config) {
        return function (categories) {
            var result = [];
            angular.forEach(categories, function (category) {
                if (category && category.id === config.CORP_DIV_TRAINING_ASSESSMENT_CATEGORY_ID) {
                    result.push(category);
                }
            });
            return result;
        };
    }]);

    // filter to create an add on title in add on tab
    app.filter('addOnTitle', function () {
        return function (addOn) {
            if (addOn.category) {
                return 'The Control <b>"' + addOn.name + '"</b> has been added to the <b>Controls (master list)</b> in ' +
                    '<br/><ul><li><span class="blue-link" >Processes &amp; Control Assessment <i>&gt;</i></span></li>' +
                    '<li><span class="blue-link">' + addOn.category.name + '</span></li>' +
                    '</ul>';
            } else {
                return 'The Service Level <b>"' + addOn.name + '"</b> has been added to the <b>SLA (master list)</b> in ' +
                    '<br/><ul><li><span class="blue-link" >Processes &amp; Control Assessment <i>&gt;</i></span></li>' +
                    '<li><span class="blue-link">KPI’s / SLA’s </span></li>' +
                    '</ul>';
            }
        };
    });

    // filter to create the add on title in popover
    app.filter('addOnTitlePopover', function () {
        return function (addOn) {
            if (addOn.category) {
                return 'The Control <b>"' + addOn.name + '"</b> has been added to the <b>Controls (master list)</b> in ' +
                    '<a href="#/admin/edit/processes/'+addOn.category.id+'" ng-click="currentEdit.category=' + addOn.category.id + '"> ' +
                    'Processes & Control Assessment &gt; ' + addOn.category.name + '.</a>';
            } else {
                return 'The Service Level <b>"' + addOn.name + '"</b> has been added to the <b>SLA (master list)</b> in ' +
                    '<a href="#/admin/edit/processes">Processes & Control Assessment &gt; KPI’s / SLA’s</a>';
            }
        };
    });
})();
