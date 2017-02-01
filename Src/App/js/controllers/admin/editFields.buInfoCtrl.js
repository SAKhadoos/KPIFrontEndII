/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for business unit info page.
 * 
 * Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 *
 * @author veshu, TCSASSEMBLER
 * @version 1.1
 */

(function () {
  'use strict';

  angular
    .module('app')
    .controller('editFieldsBUInfoCtrl', ['$rootScope', '$scope', 'LookupService', 'util', 'config',
      function ($rootScope, $scope, LookupService, util, config) {
        //sets the navigation menu as active
        $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;
        
        $scope.selected = {businessUnit:null};

        LookupService.getAllBusinessUnits(true).then(function (result) {
         $scope.adminLookups.BusinessUnit = result;
          $scope.selected.businessUnit = result[0];
        }, util.handleHttpError);

        $scope.resolveBusinessUnitLookups = function (id) {
          LookupService.getFunctionalAreaOwners(id, true).then(function (result) {
            $scope.adminLookups.FunctionalAreaOwner = result;
          }, util.handleHttpError);

          LookupService.getFunctionalAreas(id, true).then(function (result) {
            $scope.adminLookups.FunctionalArea = result;
          }, util.handleHttpError);

          LookupService.getAllDepartmentHeads(id, true).then(function (result) {
            $scope.adminLookups.DepartmentHead = result;
          }, util.handleHttpError);

          LookupService.getAllProducts(id, true).then(function (result) {
            $scope.adminLookups.Product = result;
          }, util.handleHttpError);

          LookupService.getAllDepartments(id, true).then(function (result) {
            $scope.adminLookups.Department = result;
          }, util.handleHttpError);
        };

        /**
         * Adds the business unit related entity
         */
        $scope.addBusinessUnitRelated = function (type, entity) {
          if($scope.selected.businessUnit && $scope.selected.businessUnit.id>0){
            entity=_.extend(entity, {BusinessUnitId: $scope.selected.businessUnit.id});
            $scope.createLookupEntity(type, entity);
          }
        };

        //change child data on selected parent item change
        $scope.$watch('selected.businessUnit', function (selected) {
          if (selected) {
            $scope.resolveBusinessUnitLookups(selected.id);
            $scope.$broadcast("addedNewRecord");
          }  
        });
      }]);
})();