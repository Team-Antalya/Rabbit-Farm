'use strict';

define(['angular'], function (angular) {
    angular.module('App.Link', [])
        .directive('activeLink', ['$location', function (location) {

            return {
                restrict: 'A',
                link: function (scope, element, attrs, controller) {
                    var clazz = attrs.activeLink;
                    var path = attrs.href;

                    path = path.substring(1);
                    scope.location = location;

                    scope.$watch('location.path()', function (newPath) {
                        if (path === newPath) {
                            element.parent().addClass(clazz);
                        } else {
                            element.parent().removeClass(clazz);
                        }
                    })
                }
            }
        }]
    )
});