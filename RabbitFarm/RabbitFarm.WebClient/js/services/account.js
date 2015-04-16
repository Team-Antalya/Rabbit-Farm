'use strict';

define(['angular', 'angularCookies', 'services/resource'], function (angular) {
    angular.module('App.Account', ['ngCookies'])
        .factory('account', ['$location', 'authorization',
            function ($location, authorization) {

                var logout = function () {
                    authorization.setLocalUser(undefined);
                    authorization.removeAuthorizationHeaders();
                    $location.path('/');
                };

                return {
                    logout: logout
                };
            }
        ])
});