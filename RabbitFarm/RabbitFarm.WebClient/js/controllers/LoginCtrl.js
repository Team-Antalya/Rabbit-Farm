'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Login', [])
        .controller('LoginCtrl', ['$scope', '$location', 'resource', 'service', 'authorization',
            function ($scope, $location, resource, service, authorization) {

                $scope.login = function (user, form) {
                    if (form.$valid) {
                        $scope.loading = true;

                        angular.extend(service.headers, {'Content-Type': 'application/x-www-form-urlencoded'});

                        resource('POST', 'token', "grant_type=password&username=" +
                        user.username + "&password=" + user.password, true).then(function (response) {
                            authorization.setLocalUser(response);
                            authorization.getAuthorizationHeaders();
                            $location.path('/');
                        }, function (error) {
                            alert(error.error_description);
                        }).finally(function () {
                            $scope.loading = false;
                            service.headers = {};
                        });
                    }
                };
            }
        ]
    )
});