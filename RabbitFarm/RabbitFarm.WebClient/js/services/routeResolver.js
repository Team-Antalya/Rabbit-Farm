'use strict';

define(['angular'], function (angular) {
    angular.module('App.RouteResolver', [])
        .provider('routeResolver', function () {

            this.$get = function () {
                return this;
            };

            this.routeConfig = function () {
                var viewsDirectory = 'views/',
                    controllersDirectory = 'js/controllers/',

                    setBaseDirectories = function (viewsDir, controllersDir) {
                        viewsDirectory = viewsDir;
                        controllersDirectory = controllersDir;
                    },

                    getViewsDirectory = function () {
                        return viewsDirectory;
                    },

                    getControllersDirectory = function () {
                        return controllersDirectory;
                    };

                return {
                    setBaseDirectories: setBaseDirectories,
                    getControllersDirectory: getControllersDirectory,
                    getViewsDirectory: getViewsDirectory
                };
            }();

            this.route = function (routeConfig) {

                var resolve = function (baseName, secure, path) {

                    return {
                        templateUrl: routeConfig.getViewsDirectory() + (path || '') + baseName.toLowerCase() + '.html',
                        controller: baseName + 'Ctrl',
                        title: baseName,
                        secure: (secure) ? secure : false
                    }
                };

                return {
                    resolve: resolve
                }
            }(this.routeConfig);
        }
    )
});