/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for global edit page.
 *
 * Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 *
 * @author veshu
 * @version 1.1
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('editFieldsGlobalCtrl', ['$rootScope', '$scope', 'LookupService', 'util', 'config',
            function ($rootScope, $scope, LookupService, util, config) {
                //sets the navigation menu as active
                $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;

                LookupService.getAllBusinessUnits(true).then(function (result) {
                    $scope.adminLookups.BusinessUnit = result;
                }, util.handleHttpError);

                LookupService.getAllPercentages(true).then(function (result) {
                    $scope.adminLookups.Percentage = result;
                }, util.handleHttpError);

                LookupService.getAllSites(true).then(function (result) {
                    $scope.adminLookups.Site = result;
                }, util.handleHttpError);


                LookupService.getAllAssessmentTypes(true).then(function (result) {
                    $scope.adminLookups.AssessmentType = result;
                }, util.handleHttpError);

                LookupService.getAllAssessmentStatuses(true).then(function (result) {
                    $scope.adminLookups.AssessmentStatus = result;
                }, util.handleHttpError);

                LookupService.getAllChangeTypes(true).then(function (result) {
                    $scope.adminLookups.ChangeType = result;
                }, util.handleHttpError);

                LookupService.getAllLikelihoodOfOccurrences(true).then(function (result) {
                    $scope.adminLookups.LikelihoodOfOccurrence = result;
                }, util.handleHttpError);

                LookupService.getAllRiskImpacts(true).then(function (result) {
                    $scope.adminLookups.RiskImpact = result;
                }, util.handleHttpError);

                LookupService.getAllControlFrequencies(true).then(function (result) {
                    $scope.adminLookups.ControlFrequency = result;
                }, util.handleHttpError);

                LookupService.getAllControlDesigns(true).then(function (result) {
                    $scope.adminLookups.ControlDesign = result;
                }, util.handleHttpError);

                LookupService.getAllTestingFrequencies(true).then(function (result) {
                    $scope.adminLookups.TestingFrequency = result;
                }, util.handleHttpError);

                LookupService.getAllControlTriggers(true).then(function (result) {
                    $scope.adminLookups.ControlTrigger = result;
                }, util.handleHttpError);

                LookupService.getAllKeyControlsMaturities(true).then(function (result) {
                    $scope.adminLookups.KeyControlsMaturity = result;
                }, util.handleHttpError);

            }]);
})();