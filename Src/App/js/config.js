/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Application configuration.
 *
 * Changes in 1.1:
 *  - Added new configurations for list pages
 * Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - Added 'ROLE_WITH_NAMES' and updated 'PERMISSIONS'
 *
 * Changes in 1.3 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 1
 * Changes in 1.4 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER
 * @version 1.4
 */
(function () {
    'use strict';
    var ownerUserRoleName = 'Owner';
    var buFunctionalApproverRoleName = 'BUFunctionalApprover';
    var buRiskManagementApproverRoleName = 'BURiskManagementApprover';
    var divisionalRiskManagementApproverRoleName = 'DivisionalRiskManagementApprover';
    var adminRoleName = 'Admin';
    var kpiRoleName = 'KPIUser';

    var config = {
        // The base URL of the rest services
        REST_SERVICE_BASE_URL: 'http://localhost:7104',
        COEUS_APP_NAME: 'PCA Tool',
        KPI_APP_NAME: 'KPI Scorecard Tool',
        DATE_FORMAT: 'dd-MM-yyyy',
        ROLES: {
            OWNER_ROLE_NAME: ownerUserRoleName,
            BU_FUNCTIONAL_APPROVER_ROLE_NAME: buFunctionalApproverRoleName,
            BU_RISK_MANAGEMENT_APPROVER_ROLE_NAME: buRiskManagementApproverRoleName,
            DIVISIONAL_RISK_MANAGEMENT_APPROVER_ROLE_NAME: divisionalRiskManagementApproverRoleName,
            ADMIN_ROLE_NAME: adminRoleName,
            KPI_USER_ROLE_NAME: kpiRoleName
        },
        KPISLA_ASSESSMENT_CATEGORY_ID: 1,
        FUNCTIONAL_ASSESSMENT_CATEGORY_ID: 2,
        CORP_DIV_TRAINING_ASSESSMENT_CATEGORY_ID: 3,
        SHARED_SERVICE_BUSINESS_UNIT_ID: 5,
        NO_CONTROLS_IN_PLACE_CONTROL_TYPE_ID: 9,
        USER_DEFINED_KEY_CONTROLS_MATURITY_ID: 3,
        USER_DEFINED_KEY_LIKELIHOOD_OF_OCCURRENCE_ID: 7,
        USER_DEFINED_TESTING_FREQUENCY_ID: 17,
        DEFAULT_PAGE_SIZE: 8,
        MAXIMUM_ALLOWED_FUNCTION_CHANGES: 20,
        // holds the mapping of actions and roles
        PERMISSIONS: [
            {
                action: 'home',
                roles: [ownerUserRoleName, buFunctionalApproverRoleName, buRiskManagementApproverRoleName,
                    divisionalRiskManagementApproverRoleName, adminRoleName]
            },
            {
                action: 'userAccess',
                roles: [adminRoleName]
            },
            {
                action: 'addAssessment',
                roles: [ownerUserRoleName, adminRoleName]
            },
            {
                action: 'draftAssessments',
                roles: [ownerUserRoleName, adminRoleName]
            },
            {
                action: 'awaitingAssessments',
                roles: [ownerUserRoleName, buFunctionalApproverRoleName, buRiskManagementApproverRoleName,
                    divisionalRiskManagementApproverRoleName,adminRoleName]
            },
            {
                action: 'approvedAssessments',
                roles: [ownerUserRoleName, buFunctionalApproverRoleName, buRiskManagementApproverRoleName,
                    divisionalRiskManagementApproverRoleName, adminRoleName]
            },
            {
                action: 'rejectedAssessments',
                roles: [ownerUserRoleName, adminRoleName]
            },
            {
                action: 'editFields',
                roles: [adminRoleName]
            },
            {
                action: 'kpi.home',
                roles: [adminRoleName, kpiRoleName]
            },
            {
                action: 'kpi.operationalincident',
                roles: [adminRoleName, kpiRoleName]
            },
            {
                action: 'kpi.privacyincident',
                roles: [adminRoleName, kpiRoleName]
            },
            {
                action: 'kpi.auditfinding',
                roles: [adminRoleName, kpiRoleName]
            },
            {
                action: 'kpi.summary',
                roles: [adminRoleName, kpiRoleName]
            },
            {
                action: 'kpi.editFields',
                roles: [adminRoleName]
            }
        ],
        MENUS: {
            HOME: 'home',
            ADD_ASSESSMENT: 'addAssessment',
            DRAFT_ASSESSMENT: 'draftAssessment',
            AWAITING_ASSESSMENT: 'awaitingAssessment',
            APPROVED_ASSESSMENT: 'approvedAssessment',
            REJECTED_ASSESSMENT: 'rejectedAssessment',
            USER: 'user',
            EDIT_FIELDS: 'editFields',
            KPI: {
                KPIs: 'Key Performance Indicators',
                OPERATIONAL_INCIDENT: 'Operational Incident',
                PRIVACY_INCIDENT: 'Privacy Incident',
                AUDIT_FINDING: 'Audit Finding',
                SUMMARY: 'Summary',
                EDIT_FIELDS: 'Edit Fields'
            }
        },
        ASSESSMENT_STATUS: {
            DRAFT: 'draft',
            AWAITING: 'awaiting',
            APPROVED: 'approved',
            REJECTED: 'rejected'
        },
        EXPORT_FORMAT: {
            EXCEL: 'excel'
        },
        SORT_DIR: {
            ASC: 'Ascending',
            DESC: 'Descending'
        },
        APPROVAL_STATUS: {
            DRAFT: {value: 'Draft', displayName: 'Draft'},
            APPROVED: {value: 'Approved', displayName: 'Approved'},
            REJECTED: {value: 'Rejected', displayName: 'Rejected'},
            AWAITING_BU_FUNCTIONAL_APPROVAL: {
                value: 'AwaitingBUFunctionalApproval',
                displayName: 'Awaiting Functional Modifications Approval'
            },
            AWAITING_BU_RISK_MANAGEMENT_APPROVAL: {
                value: 'AwaitingBURiskManagementApproval',
                displayName: 'Awaiting BU Risk Management Approval'
            },
            AWAITING_DIVISIONAL_RISK_MANAGEMENT_APPROVAL: {
                value: 'AwaitingDivisionalRiskManagementApproval',
                displayName: 'Awaiting the Divisional Risk Management Approval'
            }
        },
        ROLE_WITH_NAMES:[
            {
                value:ownerUserRoleName,
                name:'Owner'
            },
            {
                value:buFunctionalApproverRoleName,
                name:'BU Functional Approver'
            },
            {
                value:buRiskManagementApproverRoleName,
                name:'BU Risk Management Approver'
            },
            {
                value:divisionalRiskManagementApproverRoleName,
                name:'Divisional Risk Management Approver'
            },
            {
                value:adminRoleName,
                name:'Admin'
            }
        ],
        KPI_ROLE_WITH_NAMES: [
            {
                value: kpiRoleName,
                name: 'KPI Normal User'
            }
        ],
        ADD_ON_STATUS: {
            APPROVED: 'Approved',
            REJECTED: 'Rejected',
            PENDING: 'Pending'
        }
    };
    window.APP_CONFIG = config;
    angular
        .module('app')
        .constant("config", window.APP_CONFIG);
})();

