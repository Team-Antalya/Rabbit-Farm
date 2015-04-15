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

                        $http.post(userServiceUrl + 'token',
                            "grant_type=password&username=" + user.username + "&password=" + user.password,
                            { headers: service.headers})
                            .success(function (userLoginData) {
                                d.resolve(userLoginData);
                            })
                            .error(function (loginErr) {
                                d.reject(loginErr);
                            });
                        return d.promise;
                    },
                    register = function (user) {
                        var d = $q.defer(),
                            urlEncoded = {'Content-Type': 'application/x-www-form-urlencoded'};
                        angular.extend(service.headers, urlEncoded);

                        $http.post(userServiceUrl + 'api/account/register',
                            'Email=' + user.email + '&password=' + user.password + '&confirmPassword=' + user.confirm,
                            { headers: service.headers})
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
                    logout = function () {
                        var d = $q.defer();
                        authorization.setLocalUser(undefined);
                        authorization.removeAuthorizationHeaders();
                        d.resolve();

                        return d.promise;
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