/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for bulk import page.
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
    .controller('editFieldsBulkImportCtrl', ['$rootScope', '$scope', '$timeout', '$window', '$injector', 'LookupService', 'util', 'config', 'FileUploader', 'storage', 'Upload',
      function ($rootScope, $scope, $timeout, $window, $injector, LookupService, util, config, FileUploader, storage, Upload) {
        //sets the navigation menu as active
        $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;
        $scope.upload = {
          progress: 0 // set intitial value
        };

        // show hide popup upload file
        $scope.showPopupUpload = function () {
          $scope.uploadFileShow = true;
          $scope.upload.uploading = false;
          $scope.upload.completed = false;
          $scope.upload.failed = false;
          $scope.upload.showUploader = true;
          $timeout(function () {
            if (angular.element(document.querySelectorAll('#wrapper'))[0].offsetHeight > $window.innerHeight) {
              angular.element(document.querySelectorAll('.dark-overlay')).css("height", angular.element(document.querySelectorAll('#wrapper'))[0].offsetHeight + "px");
            } else {
              angular.element(document.querySelectorAll('.dark-overlay')).css("height", $window.innerHeight + "px");
            }
          }, 50);
          angular.element("body").css("overflow", "hidden");
        };

        // hides the popup
        $scope.hidePopupUpload = function () {
          $scope.uploadFileShow = false;
          angular.element("body").css("overflow", "auto");
        };

        /**
         * Handles the retry upload event
         */
        $scope.retryUpload = function () {
          $scope.upload.uploading = false;
          $scope.upload.completed = false;
          $scope.upload.failed = false;
          $scope.upload.showUploader = true;
        };

        // upload handler
        $scope.uploadFiles = function (file) {
          if (file) {
            file.upload = Upload.upload({
              url: config.REST_SERVICE_BASE_URL + '/api/v1//importLookupEntities/',
              headers: _getHeader(),
              data: { file: file }
            }).progress(function (evt) {
              var percentage = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
              if (percentage < 95) {
                $scope.upload.progress = percentage;
                angular.element(document.querySelectorAll('.inline-progress')).css('width', percentage + "%");
              }
            });
              
            $scope.upload.uploading = true;
            $scope.upload.completed = false;
            $scope.upload.failed = false;
            $scope.upload.showUploader = false;
              
            file.upload.then(function () {
              $scope.upload.progress = 100;
              angular.element(document.querySelectorAll('.inline-progress')).css('width', 100 + "%");
              $timeout(function () {
                $scope.upload.uploading = false;
                $scope.upload.completed = true;
                $scope.upload.failed = false;
                $scope.upload.showUploader = false;
              },600);
            }, function (response) {
              $scope.upload.uploading = false;
              $scope.upload.completed = false;
              $scope.upload.failed = true;
              $scope.upload.showUploader = false;
              var error = response.data;
              if (error === "Token was not found or has been expired.") {
                error = "Your session has expired. Please log in.";
              }
              $scope.upload.error = error;
            });
          }
        };

        /**
         * Gets the header for Http request
         * 
         * @returns the request header
         */
        function _getHeader() {
          var header = {};
          var accessToken = storage.getSessionToken();
          if (!accessToken) {
            $injector.get('util').logout();
          }
          if (accessToken && !header.Authorization) {
            header.Authorization = 'Bearer ' + accessToken.tokenValue;
          }
          return header;
        }
      }]);
})();