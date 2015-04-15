'use strict';

define(['angular', 'angularCookies', 'services/resource'], function (angular) {
    angular.module('App.Account', ['ngCookies'])
        .factory('account', ['$rootScope', '$cookieStore', 'resource', '$http', '$q', 'service', 'authorization',
            function ($rootScope, $cookieStore, resource, $http, $q, service, authorization) {

                var userServiceUrl = service.url.replace('api/', ''),
                    login = function (user) {
                        var d = $q.defer(),
                            urlEncoded = {'Content-Type': 'application/x-www-form-urlencoded'};
                        angular.extend(service.headers, urlEncoded);
                        user.grant_type = 'password';
                        $http.post(userServiceUrl + 'token', "grant_type=password&username=" + user.username + "&password=" + user.password, { headers: service.headers})
                            .success(function (userLoginData) {
                                d.resolve(userLoginData);
                            })
                            .error(function (loginErr) {
                                d.reject(loginErr);
                            });
                        return d.promise;
                    },
                    logout = function () {
                        var d = $q.defer(),
                            headers = authorization.getAuthorizationHeaders();
                        $http.post(userServiceUrl + 'account/logout', {}, {headers: headers})
                            .success(function (userLogoutData) {
                                authorization.setLocalUser(undefined);
                                authorization.removeAuthorizationHeaders();
                                d.resolve(userLogoutData);
                                console.log('logged out')
                            })
                            .error(function (logoutErr) {
                                d.reject(logoutErr);
                            });

                        return d.promise;
                    },
                    register = function (user) {
                        var d = $q.defer();
                        $http.post(userServiceUrl + 'api/account/register', user)
                            .success(function (userRegistrationData) {
                                d.resolve(userRegistrationData);
                            })
                            .error(function (registrationErr) {
                                d.reject(registrationErr);
                            });
                        return d.promise;
                    },
                    redirect = function (path) {
                        console.log('Redirect');

                    },
                    isAuthenticated = function () {
                        return !!authorization.getLocalUser();
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