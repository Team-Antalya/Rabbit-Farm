'use strict';

define(['angular', 'angularCookies', 'services/resource'], function (angular) {
    angular.module('App.Account', ['ngCookies'])
        .factory('account', ['$rootScope', '$cookieStore', 'resource',
            function ($rootScope, $cookieStore, resource) {

                var login = function (user) {
                        console.log(user);
                    },
                    logout = function () {
                        console.log('Logged out');
                    },
                    register = function (user) {
                        console.log(user);
                    },
                    redirect = function (path) {
                        console.log('Redirect');
                    },
                    isAuthenticated = function () {
                        console.log(false);
                    };

                return {
                    login: login,
                    logout: logout,
                    register: register,
                    redirect: redirect,
                    isAuthenticated: isAuthenticated
                };
            }
        ]
    )
});