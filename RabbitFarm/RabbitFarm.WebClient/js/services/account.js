'use strict';

define(['angular', 'angularCookies', 'services/resource'], function (angular) {
    angular.module('App.Account', ['ngCookies'])
        .factory('account', ['$rootScope', '$cookieStore', 'resource', '$http', '$q', 'service',
            function ($rootScope, $cookieStore, resource, $http, $q, service) {

                var userServiceUrl = service.url,
                    login = function (user) {
                        console.log(user);
                        $http.post(userServiceUrl + '/Token', user)
                            .success(function (userLoginData) {
                                d.resolve(userLoginData);
                            })
                            .error(function (loginErr) {
                                d.reject(loginErr);
                            });
                    },
                    logout = function () {
                        console.log('Logged out');
                    },
                    register = function (user) {
                        var d = $q.defer();
                        $http.post(userServiceUrl + '/account/register', user)
                            .success(function (userRegistrationData) {
                                d.resolve(userRegistrationData);
                            })
                            .error(function (registrationErr) {
                                d.reject(registrationErr);
                            });
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