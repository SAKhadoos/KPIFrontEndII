/*
 * Copyright (C) 2016-2017 TopCoder Inc., All Rights Reserved.
 */
/**
 * Application directives.
 *
 * Changes in 1.1:
 *  - Added new directives 'showDialog', 'closeDialog', 'checklistModel'
 *  - updated datepicker directive to update calendar from value
 *
 * Changes in 1.2 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
 *  - updated 'showDialog' dialog to fix the main body scroll when dialog is opened
 *
 * Changes in 1.3 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 1
 * Changes in 1.4 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.5 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 * Changes in 1.6 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION
 *
 * @author veshu, TCSASSEMBLER, TCSASSEMBLER
 * @version 1.6
 */
(function () {
    'use strict';

    var app = angular.module('app');

    // date picker
    app.directive('datePicker', function () {
        return {
            require: '?ngModel',
            restrict: 'A',
            link: function (scope, element, attrs, controller) {
                var updateModel = function (ev) {
                    scope.$apply(function () {
                        controller.$setViewValue(moment(ev.date).format("YYYY-MM-DD"));
                    });
                };
                var options = {
                    format: 'dd-mm-yyyy',
                    todayHighlight: false
                };
                element.datepicker(options).on('changeDate', updateModel);
                $('.datepicker table').each(function () {
                    if (!$(this).find('.ok-btn').length) {
                        $(this).append('<tfoot><tr><th colspan="7" style="background: #798B9A; width: 100%; height: 29px; line-height: 29px; border-radius: 0; ">' +
                            '<a href="javascript:;" style="color: #FFF; width: 100%;" class="fl ok-btn">OK</a></th></tr></tfoot>');
                        $(this).find('.ok-btn').on('click', function () {
                            $('.datepicker').hide();
                        });
                    }
                });
                if (attrs.ngModel) {
                    scope.$watch(attrs.ngModel, function (value) {
                        if (value) {
                            element.datepicker('setValue', moment(value, "YYYY-MM-DD"));
                        }
                    });
                }
            }
        };
    });

    /**
     * Date picker input directive
     */
    app.directive('datepickerInput', [function () {
        return {
            restrict: 'A',
            link: function (scope, element) {
                element.on('click', function () {
                    $(this).siblings('input').trigger('focus');
                });
            }
        };
    }]);

    /**
     * tool tips for multiple select
     */
    app.directive('toolTips', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                function showTip(element, html, adjust) {
                    if (!$('#tips').length) {
                        $('<div id="tips" class="tips"><div class="content">' + html + '</div><div class="arrow-down"></div></div>').appendTo('body');
                    } else {
                        $('#tips .content').html(html);
                    }
                    var top = element.offset().top - $('#tips').height() - 33;
                    var left = element.offset().left - 15;
                    if (adjust) {
                        top = top - 7;
                        left = left - 8;
                    }
                    $('#tips').css({
                        'top': top,
                        'left': left
                    }).show();
                }

                element.find("button.ms-choice").hover(function () {
                    $(this).closest('.inputs').find('select').multipleSelect('refresh');
                    var selects = $(this).closest('.inputs').find('select').multipleSelect('getSelects', 'text');
                    var html = '';
                    if (attrs.preMessage && $(this).closest('.inputs').find('.ms-drop ul li').length <= 0) {
                        html = attrs.preMessage;
                    } else if (selects.length) {
                        html = '<ul>';
                        for (var i = 0; i < selects.length; ++i) {
                            html += '<li>' + selects[i] + '</li>';
                        }
                        html += '</ul>';
                    } else {
                        html = 'Nothing selected';
                    }
                    showTip($(this), html);
                }, function () {
                    $('#tips').remove();
                });
            }
        };
    });

    /**
     * tool tips for multiple select
     */
    app.directive('selectTooltip', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                function showTip(element, html, adjust) {
                    if (!$('#tips').length) {
                        $('<div id="tips" class="tips"><div class="content">' + html + '</div><div class="arrow-down"></div></div>').appendTo('body');
                    } else {
                        $('#tips .content').html(html);
                    }
                    var top = element.offset().top - $('#tips').height() - 33;
                    var left = element.offset().left - 15;
                    if (adjust) {
                        top = top - 7;
                        left = left - 8;
                    }
                    $('#tips').css({
                        'top': top,
                        'left': left
                    }).show();
                }

                element.hover(function () {
                    var selectedItem = $("option:selected", $(element));
                    var text = !selectedItem ? 'Nothing selected' : selectedItem.text();
                    var html = '<ul><li>' + text + '</li></ul>';
                    showTip($(this), html);
                }, function () {
                    $('#tips').remove();
                });
            }
        };
    });

    /**
     * Updates the height of text area as required by text
     */
    app.directive('autoGrow', function () {
        return {
            restrict: 'A',
            link: function (scope, element) {
                element.on('keyup', function () {
                    element[0].style.height = "20px";
                    element[0].style.height = (element[0].scrollHeight + 3) + "px";
                });
            }
        };
    });

    /**
     * Shows the JQuery dialog
     */
    app.directive('showDialog', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var height = attrs.dialogHeight || 300;
                element.on('click', function () {
                    $(attrs.targetId).dialog({
                        resizable: false,
                        height: height,
                        modal: true,
                        dialogClass: "no-close",
                        closeOnEscape: false,
                        open: function () {
                            angular.element("body").css("overflow", "hidden");
                        },
                        close: function () {
                            angular.element("body").css("overflow", "auto");
                        }
                    });

                });
            }
        };
    });

    /**
     * Closes the JQuery dialog
     */
    app.directive('closeDialog', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.on('click', function () {
                    $(attrs.targetId).dialog('close');
                });
            }
        };
    });

    /**
     * Build the control types dropdown.
     */
    app.directive('controlTypeSelect', function (LookupService, config, util) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                function populateData(assessment, controlTypes) {
                    $.each(element.next('div.ms-parent').find('input:checkbox'), function (i, checkbox) {
                        if ($(checkbox).val().indexOf('other') !== -1) {
                            if ($(checkbox).prop('checked') || assessment.otherNames[$(checkbox).val()] !== undefined) {
                                var template = $('<nobr><input type="text" name="other" width = "50%" maxlength="200" class="other-input" placeholder=""/>\<span class="char-count">0/200</span>\<a href="javascript:;" class="btn-small btn-small-primary" >Save</a></nobr>');
                                var text = template.find('input:text');
                                text.val(assessment.otherNames[$(checkbox).val()]);
                                var count = text.val().length;
                                text.next('span.char-count').text(count + '/' + (200 - count));
                                $(checkbox).parent().parent().after(template);
                                $(template.find('input:text')).focus();
                                template.find('a').on('click', function () {
                                    var controlType = template.find('input:text').val();
                                    element.next('div.ms-parent').find('div.ms-drop').hide();
                                    if (controlType) {
                                        var order = _.max(_.pluck(assessment.selectableControlTypes, "displayOrder")) + 1;
                                        var entity = {
                                            name: controlType,
                                            displayOrder: order,
                                            enabled: true,
                                            addOnStatus: config.ADD_ON_STATUS.PENDING,
                                            category: {
                                                id: attrs.categoryType
                                            }
                                        };
                                        // do not throw error here
                                        LookupService.createLookupEntity('ControlType', entity);
                                    }
                                });
                                template.find('input:text').on('keyup', function () {
                                    var index = template.prev('li').find('input:checkbox').val();
                                    if (!controlTypes.otherNames) {
                                        controlTypes.otherNames = [];
                                    }
                                    assessment.otherNames[index] = $(this).val();
                                    scope.$apply(function () {
                                        if (!assessment.inputs) {
                                            assessment.inputs = [];
                                        }
                                        assessment.inputs.push({});
                                        assessment.inputs.splice(assessment.inputs.length - 1, 0);
                                    });
                                    var span = $(this).next('span.char-count');
                                    var count = $(this).val().length;
                                    span.text(count + '/' + (200 - count));
                                });
                            }
                        }
                    });
                }

                var assessment = scope.$eval(attrs.controlTypeSelect.replace('.controlTypes', ''));
                if (assessment) {
                    if (!assessment.otherNames) {
                        assessment.otherNames = {};
                    }
                    scope.$watch(attrs.controlTypeSelect, function (controlTypes) {
                        setTimeout(function () {
                            populateData(assessment, controlTypes);
                        }, 100);
                    });
                }
            }
        };
    });

    /**
     * Close the multiple drop down when clicking on other places on the web page
     */
    app.directive('closeDrop', function () {
        return {
            restrict: 'A',
            link: function (scope, element) {
                $(document).click(function (e) {
                    var that = element.next('div.ms-parent');
                    if ($(e.target)[0] === that.find('button.ms-choice')[0] ||
                        $(e.target).parents('.ms-choice')[0] === that.find('button.ms-choice')[0] ||
                        $(e.target).attr('name') === 'selectItem') {
                        return;
                    }
                    if (($(e.target)[0] === that.find('div.ms-drop')[0] ||
                        $(e.target).parents('.ms-drop')[0] !== that.find('div.ms-drop')[0])) {
                        element.multipleSelect('close');
                    }
                });
            }
        };
    });

    /**
     * Build the SLAs dropdown.
     */
    app.directive('serviceLevelSelect', function (LookupService, config, util) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                function populateData(assessment) {
                    $.each(element.next('div.ms-parent').find('input:radio'), function (i, radioButton) {
                        if ($(radioButton).val().indexOf('other') !== -1) {
                            if ($(radioButton).prop('checked', true) || assessment.additionalSLA !== undefined) {
                                var template = $('<nobr><input type="text" name="other" width = "50%" maxlength="200" class="other-input" placeholder=""/>\<span class="char-count">0/200</span>\<a href="javascript:;" class="btn-small btn-small-primary" >Save</a></nobr>');
                                var text = template.find('input:text');
                                text.val(assessment.additionalSLA);
                                var count = text.val().length;
                                text.next('span.char-count').text(count + '/' + (200 - count));
                                $(radioButton).parent().parent().after(template);
                                $(template.find('input:text')).focus();
                                template.find('a').on('click', function () {
                                    var slaName = template.find('input:text').val()
                                    assessment.additionalSLA = slaName;
                                    element.next('div.ms-parent').find('button.ms-choice').find('span').text(template.find('input:text').val());
                                    element.next('div.ms-parent').find('div.ms-drop').hide();
                                    if (slaName) {
                                        var order = _.max(_.pluck(assessment.SLAs, "displayOrder")) + 1;
                                        var entity = {
                                            name: slaName,
                                            displayOrder: order,
                                            enabled: true,
                                            addOnStatus: config.ADD_ON_STATUS.PENDING
                                        };
                                        LookupService.createLookupEntity('SLA', entity).then(function (result) {
                                            assessment.createdSLA = result;
                                        }, util.handleHttpError);
                                    }
                                });
                                template.find('input:text').on('keyup', function () {
                                    assessment.additionalSLA = $(this).val();
                                    element.next('div.ms-parent').find('button.ms-choice').find('span').text($(this).val());
                                    var span = $(this).next('span.char-count');
                                    var count = $(this).val().length;
                                    span.text(count + '/' + (200 - count));
                                });
                            }
                        }
                    });
                }

                var assessment = scope.$eval(attrs.serviceLevelSelect.replace('.selectedSLA', ''));
                if (assessment) {
                    scope.$watch(attrs.serviceLevelSelect, function (selectedSLA) {
                        setTimeout(function () {
                            populateData(assessment, selectedSLA);
                        }, 100);
                    });
                }
            }
        };
    });

    /**
     * tool tips for table header from message
     */
    app.directive('customToolTips', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                function showTip(element, html, adjust) {
                    if (!$('#tips').length) {
                        $('<div id="tips" class="tips thtips"><div class="content">' + html + '</div><div class="arrow-down"></div></div>').appendTo('body');
                    } else {
                        $('#tips .content').html(html);
                    }
                    var top = element.offset().top - $('#tips').height() - 33;
                    var left = element.offset().left - 25;
                    if (adjust) {
                        top = top - 7;
                        left = left - 8;
                    }
                    $('#tips').css({
                        'top': top,
                        'left': left
                    }).show();
                }

                element.hover(function () {
                    var mssage = attrs.ctMessage;
                    var html = '<ul>';
                    html += '<li>' + mssage + '</li>';
                    html += '</ul>';
                    showTip($(this), html);
                }, function () {
                    $('#tips').remove();
                });
            }
        };
    });

    /**
     * Checklist-model
     * AngularJS directive for list of checkboxes
     * https://github.com/vitalets/checklist-model
     * License: MIT http://opensource.org/licenses/MIT
     */
    app.directive('checklistModel', ['$parse', '$compile', function ($parse, $compile) {
        // contains
        function contains(arr, item, comparator) {
            if (angular.isArray(arr)) {
                for (var i = arr.length; i--;) {
                    if (comparator(arr[i], item)) {
                        return true;
                    }
                }
            }
            return false;
        }

        // add
        function add(arr, item, comparator) {
            arr = angular.isArray(arr) ? arr : [];
            if (!contains(arr, item, comparator)) {
                arr.push(item);
            }
            return arr;
        }

        // remove
        function remove(arr, item, comparator) {
            if (angular.isArray(arr)) {
                for (var i = arr.length; i--;) {
                    if (comparator(arr[i], item)) {
                        arr.splice(i, 1);
                        break;
                    }
                }
            }
            return arr;
        }

        // http://stackoverflow.com/a/19228302/1458162
        function postLinkFn(scope, elem, attrs) {
            // exclude recursion, but still keep the model
            var checklistModel = attrs.checklistModel;
            attrs.$set("checklistModel", null);
            // compile with `ng-model` pointing to `checked`
            $compile(elem)(scope);
            attrs.$set("checklistModel", checklistModel);

            // getter / setter for original model
            var getter = $parse(checklistModel);
            var setter = getter.assign;
            var checklistChange = $parse(attrs.checklistChange);
            var checklistBeforeChange = $parse(attrs.checklistBeforeChange);

            // value added to list
            var value = attrs.checklistValue ? $parse(attrs.checklistValue)(scope.$parent) : attrs.value;


            var comparator = angular.equals;

            if (attrs.hasOwnProperty('checklistComparator')) {
                if (attrs.checklistComparator[0] == '.') { //jshint ignore:line
                    var comparatorExpression = attrs.checklistComparator.substring(1);
                    comparator = function (a, b) {
                        return a[comparatorExpression] === b[comparatorExpression];
                    };

                } else {
                    comparator = $parse(attrs.checklistComparator)(scope.$parent);
                }
            }

            // watch UI checked change
            scope.$watch(attrs.ngModel, function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }

                if (checklistBeforeChange && (checklistBeforeChange(scope) === false)) {
                    scope[attrs.ngModel] = contains(getter(scope.$parent), value, comparator);
                    return;
                }

                setValueInChecklistModel(value, newValue);

                if (checklistChange) {
                    checklistChange(scope);
                }
            });

            function setValueInChecklistModel(value, checked) {
                var current = getter(scope.$parent);
                if (angular.isFunction(setter)) {
                    if (checked === true) {
                        setter(scope.$parent, add(current, value, comparator));
                    } else {
                        setter(scope.$parent, remove(current, value, comparator));
                    }
                }

            }

            // declare one function to be used for both $watch functions
            function setChecked(newArr, oldArr) {//jshint ignore:line
                if (checklistBeforeChange && (checklistBeforeChange(scope) === false)) {
                    setValueInChecklistModel(value, scope[attrs.ngModel]);
                    return;
                }
                scope[attrs.ngModel] = contains(newArr, value, comparator);
            }

            // watch original model change
            // use the faster $watchCollection method if it's available
            if (angular.isFunction(scope.$parent.$watchCollection)) {
                scope.$parent.$watchCollection(checklistModel, setChecked);
            } else {
                scope.$parent.$watch(checklistModel, setChecked, true);
            }
        }

        return {
            restrict: 'A',
            priority: 1000,
            terminal: true,
            scope: true,
            compile: function (tElement, tAttrs) {
                if ((tElement[0].tagName !== 'INPUT' || tAttrs.type !== 'checkbox') &&
                    (tElement[0].tagName !== 'MD-CHECKBOX') && (!tAttrs.btnCheckbox)) {
                    throw 'checklist-model should be applied to `input[type="checkbox"]` or `md-checkbox`.';
                }

                if (!tAttrs.checklistValue && !tAttrs.value) {
                    throw 'You should provide `value` or `checklist-value`.';
                }

                // by default ngModel is 'checked', so we set it if not specified
                if (!tAttrs.ngModel) {
                    // local scope var storing individual checkbox model
                    tAttrs.$set("ngModel", "checked");
                }

                return postLinkFn;
            }
        };
    }]);

    /**
     * Fixed header directive
     */
    app.directive('fixedHeader', function () {
        return {
            restrict: 'A',
            link: function (scope, element) {
                // Fix table header when scroll to top
                $.fn.fixMe = function () {
                    return this.each(function () {
                        var $this = $(this),
                            $t_fixed;

                        function init() {
                            $this.wrap('<div class="row" />');
                            $t_fixed = $this.clone();
                            $t_fixed = $t_fixed.find("tbody").remove().end().addClass("fix-header");
                            angular.element($t_fixed).insertBefore($this);
                            resizeFixed();
                        }

                        function resizeFixed() {
                            $t_fixed.find("th").each(function (index) {
                                $(this).css("width", $this.find("th").eq(index).outerWidth() + "px");
                            });
                            //$t_fixed.width($this.width());
                            $t_fixed.hide();
                        }

                        function scrollFixed() {
                            var offset = $(this).scrollTop(), // jshint ignore:line
                                tableOffsetTop = $this.offset().top,
                                tableOffsetBottom = tableOffsetTop + $this.height() - $this.find("thead").height();
                            if (offset <= tableOffsetTop || offset >= tableOffsetBottom) {
                                $t_fixed.hide();
                            } else if (offset >= tableOffsetTop && offset <= tableOffsetBottom && $t_fixed.is(":hidden")) {
                                $t_fixed.show();
                            }
                        }

                        //$(window).resize(resizeFixed);
                        $(window).scroll(scrollFixed);
                        init();
                    });
                };
                element.fixMe();
            }
        };
    });

    //toggleView directive
    app.directive('toggleView', function () {
        return {
            restrict: 'A',
            link: function (scope, el) {
                var _ = $(el);
                $('.toggle-group-title', _).on('click', function () {
                    if (_.hasClass('collapse')) {
                        _.removeClass('collapse');
                    } else {
                        _.addClass('collapse');
                    }
                });
            }
        };
    });

    /**
     * Edit block directive, which performs sorting, creating , updating and deleting of block item
     */
    app.directive('editBlock', ['LookupService', 'util', 'config', function (LookupService, util, config) {
        //editBlock
        return {
            restrict: 'A',
            require: '?list',
            scope: {
                model: "=",
                list: '=editBlock',
                selected: '=',
                dragItems: '=?',
                entityType: '@type',
                hideCheckbox: '@',
                masterList: '@',
                categoryId: '@',
                uniqueName: '@',
                parentId: '@',
                onlyInteger: '@',
                onCreated: '&'
            },
            templateUrl: 'partials/blocks/editBlock.template.html',
            controller: function ($scope) {
                $scope.isProcessingNewRecord = false;
                //sortOptions
                $scope.sortOptions = {
                    handle: '.move-handel',
                    stop: function (e, ui) {
                        var lists = ui.item.parent();
                        var ids = lists.sortable("toArray");
                        LookupService.reorderLookupEntities($scope.entityType, ids, _.range(1, ids.length + 1))
                            .catch(function () {
                                lists.sortable("cancel");
                                util.handleHttpError("An error occurred while reordering the items.");
                            });
                    }
                };
                //addRecord
                $scope.addRecord = function () {
                    if ($scope.newRecord && !$scope.isProcessingNewRecord) {
                        $scope.isProcessingNewRecord = true;
                        var order = _.max(_.pluck($scope.list, "displayOrder")) + 1;
                        var entity = {
                            name: $scope.newRecord,
                            displayOrder: order,
                            enabled: true,
                            addOnStatus: config.ADD_ON_STATUS.APPROVED
                        };
                        if ($scope.entityType === 'KPI') {
                            entity = _.extend(entity, { KPICategory: { id: $scope.parentId } });
                        }
                        if ($scope.entityType === 'Percentage') {
                            entity.name = $scope.newRecord + '%';
                            entity.value = $scope.newRecord;
                        }
                        $scope.onCreated()($scope.entityType, entity);
                    }
                };
                // listens for added new record broadcast
                $scope.$on('addedNewRecord', function () {
                    $scope.newRecord = '';
                    $scope.isProcessingNewRecord = false;
                });

                // listens for api error occurrence during API operation
                $scope.$on('apiErrorOccurred', function () {
                    $scope.isProcessingNewRecord = false;
                });

                // updates the record
                $scope.updateRecord = function () {
                    if ($scope.updatingRecord && $scope.updatingRecord.name.length) {
                        var record = $scope.updatingRecord;
                        if ($scope.entityType === 'Percentage') {
                            record.value = record.name;
                            record.name = record.name + '%';
                        }
                        LookupService.updateLookupEntity($scope.entityType, record.id, record).then(function (result) {
                            angular.forEach($scope.list, function (item, index) {
                                if (item.id === result.id) {
                                    $scope.list[index] = result;
                                }
                            });
                            $scope.updatingRecord = null;
                            $scope.editing = null;
                        }, function (err) {
                            util.handleHttpError(err);
                        });
                    }
                };

                // sets the edit mode for lookup entity
                $scope.setEditingMode = function (record) {
                    $scope.editing = record.id;
                    $scope.updatingRecord = angular.copy(record);
                };

                $scope.cancelEditingMode = function () {
                    $scope.editing = undefined;
                    $scope.updatingRecord = undefined;
                }
                // deleting entity
                $scope.deleting = {};

                /** 
                 * Shows the delete confirmation.
                 * @param {String} index the index
                 * @param {Number} id the id of entity
                 * @param {String} name the name of entity
                 */
                $scope.showDeleteConfirm = function (index, id, name) {
                    $scope.deleting = {};
                    $scope.deleting.index = index;
                    $scope.deleting.name = name;
                    $scope.deleting.id = id;
                    $scope.deleting.entityType = $scope.entityType;
                    var elementId = '#modal-delete-' + $scope.entityType + '-record-';
                    if ($scope.uniqueName) {
                        elementId += $scope.uniqueName;
                    }
                    var options = {
                        resizable: false,
                        modal: true,
                        dialogClass: "no-close",
                        closeOnEscape: false,
                        open: function () {
                            angular.element("body").css("overflow", "hidden");
                        },
                        close: function () {
                            angular.element("body").css("overflow", "auto");
                            $(this).dialog('destroy');
                        }
                    };
                    $(elementId).dialog(options).dialog('open');
                };
                //remove record
                $scope.removeRecord = function () {
                    if ($scope.deleting && $scope.deleting.id > 0) {
                        LookupService.deleteLookupEntity($scope.entityType, $scope.deleting.id).then(function () {
                            $scope.list.splice($scope.deleting.index, 1);
                            // select next item
                            if ($scope.selected && $scope.selected.id === $scope.deleting.id) {
                                $scope.selected = $scope.list[$scope.deleting.index];
                            }
                            $scope.deleting = null;
                        }, util.handleHttpError);
                    }
                };

                // enable or disable
                $scope.enableOrDisabled = function (item) {
                    if ($scope.entityType === 'KPI') {
                        item = _.extend(item, { KPICategory: { id: $scope.parentId } });
                    }
                    LookupService.updateLookupEntity($scope.entityType, item.id, item).then(function (result) {
                        angular.forEach($scope.list, function (item, index) {
                            if (item.id === result.id) {
                                $scope.list[index] = result;
                            }
                        });
                    }, util.handleHttpError);
                };

                $scope.removeItemDrag = function (record) {
                    for (var i = 0; i < $scope.dragItems.length; i++) {
                        if ($scope.dragItems[i].id === record.id) {
                            $scope.dragItems.splice(i, 1);
                        }
                    }
                };

                $scope.toggleAllChks = function (checkAll) {
                    angular.forEach($scope.list, function (item) {
                        item.selected = checkAll;
                    });

                    $scope.dragItems = [];

                    if (checkAll) {
                        angular.forEach($scope.list, function (item) {
                            $scope.dragItems.push(item);
                        });
                    }
                };

                $scope.changeChk = function (record) {
                    if (!record.selected) {
                        $scope.removeItemDrag(record);
                    } else {
                        $scope.dragItems.push(record);
                    }
                };
            },
            link: function (scope, el) {
                var _ = $(el);
                //select item
                scope.select = function (item) {
                    if (_.hasClass('can-select')) {
                        scope.selected = item;

                    }
                };
            }
        };
    }]);

    /**
     *Directives to bind the event handler for "enter" key press
     */
    app.directive('ngEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.ngEnter);
                    });
                    event.preventDefault();
                }
            });
        };
    });

    /**
     * Directive which will focus the element while show/hide is change
     */
    app.directive('focusOnShow', function ($timeout) {
        return {
            restrict: 'A',
            link: function ($scope, $element, $attr) {
                if ($attr.ngShow) {
                    $scope.$watch($attr.ngShow, function (newValue) {
                        if (newValue) {
                            $timeout(function () {
                                $element[0].focus();
                            }, 0);
                        }
                    });
                }
                if ($attr.ngHide) {
                    $scope.$watch($attr.ngHide, function (newValue) {
                        if (!newValue) {
                            $timeout(function () {
                                $element[0].focus();
                            }, 0);
                        }
                    });
                }
            }
        };
    });

    /**
     * Directive to handle the custom select the select
     */
    app.directive("customSelect", function () {
        return function (scope, el) {
            var _ = $(el);
            $('.select-val', _).on('click', function (e) {
                e.stopPropagation();
                var p = $(this).closest('.select-group');
                if (p.hasClass('open')) {
                    p.removeClass('open');
                } else {
                    p.addClass('open');
                }
            });
            $('.select-list', _).on('click', function (e) {
                e.stopPropagation();
            });
            $('body').on('click', function () {
                $('.select-group.open').removeClass('open');
            });
        };
    });

    /**
     * Directive to binds the single click event handler
     */
    app.directive('sglclick', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                var fn = $parse(attr['sglclick']); // jshint ignore:line
                var delay = 300, clicks = 0, timer = null;
                element.on('click', function (event) {
                    clicks++;  //count clicks
                    if (clicks === 1) {
                        timer = setTimeout(function () {
                            scope.$apply(function () {
                                fn(scope, { $event: event });
                            });
                            clicks = 0;             //after action performed, reset counter
                        }, delay);
                    } else {
                        clearTimeout(timer);    //prevent single-click action
                        clicks = 0;             //after action performed, reset counter
                    }
                });
            }
        };
    }]);

    /**
     * Directive which handles the drag of master list
     */
    app.directive('positionArea', function () {
        return {
            link: function (scope, element, attrs) {
                $(".when-drop-drap").draggable({
                    handle: ".move-hand",
                    containment: "#main-content",
                    start: function () {
                        scope.startDrag = true;
                        $(".when-drop-drap").addClass("active").parent().addClass("active").zIndex(50);
                    },
                    stop: function () {
                        scope.testDrag = true;
                        scope.showDragInfo = function (index, $event, rootItem, array, type) {
                            if (scope.startDrag === true && scope.testDrag === true && array.length > 0) {
                                angular.element($event.currentTarget).find(".when-drop-d").css("display", "block");
                                scope.testDrag = false;
                                scope.startDrag = false;
                                // type will be the entity type of parent such as CoreProcess/KPICategory/Process
                                scope.$emit('child-item-added', rootItem, array, type);
                            }
                        };

                        $(".when-drop-drap").removeClass("active").parent().removeClass("active").zIndex(0);
                    },
                    revert: true,
                    revertDuration: 20
                });
            }
        }
    });

    /**
     * Directives for jqPlot
     */
    app.directive('uiChart', function () {
        return {
            restrict: 'EACM',
            template: '<div></div>',
            replace: true,
            link: function (scope, elem, attrs) {
                var renderChart = function () {
                    var data = scope.$eval(attrs.uiChart);
                    elem.html('');
                    if (!angular.isArray(data)) {
                        return;
                    }

                    var opts = {};
                    if (!angular.isUndefined(attrs.chartOptions)) {
                        opts = scope.$eval(attrs.chartOptions);
                        if (!angular.isObject(opts)) {
                            throw 'Invalid ui.chart options attribute';
                        }
                    }

                    elem.jqplot(data, opts);
                };

                scope.$watch(attrs.uiChart, function () {
                    renderChart();
                }, true);

                scope.$watch(attrs.chartOptions, function () {
                    renderChart();
                });
            }
        };
    });

    /**
     * Directive to handle notification popover and icon.
     */
    app.directive('notificationHeader', function () {
        return function (scope, el) {
            var _ = $(el);
            //hide nfn panel
            $('.nfn-link', _).on('click', function (e) {
                e.stopPropagation();
                $(".right-nav").closest('.top-nav').toggleClass('nfn-open');
            });
            $('.nofication-panel', _).on('click', function (e) {
                e.stopPropagation();
            });
            $('body').on('click', function () {
                $('.nfn-open').removeClass('nfn-open');
            })
        }
    });
    
    /**
     * Directive to allow only integer
     */
    app.directive('onlyIntegers', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {
                function fromUser(text) {
                    if (text) {
                        var transformedInput = text.replace(/[^0-9]/g, '');

                        if (transformedInput !== text) {
                            ngModelCtrl.$setViewValue(transformedInput);
                            ngModelCtrl.$render();
                        }
                        return transformedInput;
                    }
                    return undefined;
                }
                ngModelCtrl.$parsers.push(fromUser);
            }
        };
    });

    /**
     * Directive to allow only decimal value
     */
    app.directive('onlyDecimals', function () {
        return {
            require: '?ngModel',
            link: function (scope, element, attrs, ngModelCtrl) {
                if (!ngModelCtrl) {
                    return;
                }

                ngModelCtrl.$parsers.push(function (val) {
                    if (angular.isUndefined(val)) {
                        var val = '';
                    }

                    var clean = val.replace(/[^-0-9\.]/g, '');
                    var negativeCheck = clean.split('-');
                    var decimalCheck = clean.split('.');
                    if (!angular.isUndefined(negativeCheck[1])) {
                        negativeCheck[1] = negativeCheck[1].slice(0, negativeCheck[1].length);
                        clean = negativeCheck[0] + '-' + negativeCheck[1];
                        if (negativeCheck[0].length > 0) {
                            clean = negativeCheck[0];
                        }

                    }

                    if (!angular.isUndefined(decimalCheck[1])) {
                        decimalCheck[1] = decimalCheck[1].slice(0, 2);
                        clean = decimalCheck[0] + '.' + decimalCheck[1];
                    }

                    if (val !== clean) {
                        ngModelCtrl.$setViewValue(clean);
                        ngModelCtrl.$render();
                    }
                    return clean;
                });

                element.bind('keypress', function (event) {
                    if (event.keyCode === 32) {
                        event.preventDefault();
                    }
                });
            }
        };
    });

    /**
     * Inline Edit directive, which performs updating of an item
     */
    app.directive('inlineEdit', ['LookupService', 'util', 'config', function (LookupService, util, config) {
        return {
            restrict: 'A',
            require: '?item',
            scope: {
                model: "=",
                item: '=inlineEdit',
                entityType: '@type',
                parentId: '@',
                propertyName: '@field'
            },
            templateUrl: 'partials/blocks/inlineEdit.template.html',
            controller: function ($scope) {
                $scope.value = $scope.item[$scope.propertyName];
                // updates the record
                $scope.updateRecord = function () {
                    if ($scope.updatingRecordValue && $scope.updatingRecordValue.length) {
                        var record = angular.copy($scope.item);
                        record[$scope.propertyName] = $scope.updatingRecordValue;
                        if ($scope.entityType === 'SubProcessRisk') {
                            record.coreProcess = { id: $scope.parentId };
                        }
                        LookupService.updateLookupEntity($scope.entityType, record.id, record).then(function (result) {
                            $scope.item[$scope.propertyName] = result[$scope.propertyName];
                            $scope.value = $scope.item[$scope.propertyName];
                            $scope.updatingRecord = null;
                            $scope.editing = null;
                        }, function (err) {
                            util.handleHttpError(err);
                        });
                    }
                };

                // sets the edit mode for lookup entity
                $scope.setEditingMode = function () {
                    $scope.editing = true;
                    $scope.updatingRecordValue = angular.copy($scope.item[$scope.propertyName]);
                };

                $scope.cancelEditingMode = function () {
                    $scope.editing = false;
                    $scope.updatingRecordValue = undefined;
                }
            },
            link: function (scope, el) {
                var _ = $(el);
            }
        };
    }]);
})();
