'use strict';

define(['angular', 'angularCookies', 'services/resource'], function (angular) {
    angular.module('App.Authorization', ['ngCookies'])
        .factory('authorization', ['$rootScope', '$cookieStore', 'resource', '$http', '$q', 'service',
            function ($rootScope, $cookieStore, resource, $http, $q, service) {

                function getLocalUser() {
                    var savedUser = JSON.parse(sessionStorage.getItem('userData'));
                    if (savedUser) {
                        return savedUser;
                    } else {
                        return false;
                    }
                }

                function setLocalUser(user) {
                    if (!!user) {
                        var userStr = JSON.stringify(user);
                        sessionStorage.setItem('userData', userStr);
                    } else {
                        sessionStorage.removeItem('userData');
                    }
                }

                function isLogged() {
                    return !!this.getLocalUser();
                }

                function setAuthorizationHeaders(accessToken) {
                    angular.extend(service.headers , {Authorization: 'Bearer ' + accessToken},{});
                }

                function getAuthorizationHeaders() {
                    var loggedUser = getLocalUser();
                    if (loggedUser) {
                        setAuthorizationHeaders(loggedUser.access_token);
                    }

                    return service.headers ;
                }

                function removeAuthorizationHeaders() {
                    delete service.headers['Authorization'];
                }

                return{
                    getLocalUser: getLocalUser,
                    setLocalUser: setLocalUser,
                    isLogged: isLogged,
                    getAuthorizationHeaders: getAuthorizationHeaders,
                    removeAuthorizationHeaders: removeAuthorizationHeaders
                }

            }
        ])
});