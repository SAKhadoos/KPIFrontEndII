/*
 * Copyright (C) 2016 TopCoder Inc., All Rights Reserved.
 */
/**
 * This is controller for edit fields for add on page.
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
        .controller('editFieldsAddOnCtrl', ['$rootScope', 'config',
            function ($rootScope, config) {
                //sets the navigation menu as active
                $rootScope.currentMenu = config.MENUS.EDIT_FIELDS;
            }]);
})();