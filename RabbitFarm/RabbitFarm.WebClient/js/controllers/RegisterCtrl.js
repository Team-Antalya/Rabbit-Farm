'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Register', [])
        .controller('RegisterCtrl', ['$scope', '$location', 'resource', 'service', 'authorization',
            function ($scope, $location, resource, service, authorization) {

                $scope.register = function (user, form) {
                    if (form.$valid) {
                        $scope.loading = true;

                        angular.extend(service.headers, {'Content-Type': 'application/x-www-form-urlencoded'});

                        resource('POST', 'account/register',
                            'Email=' + user.email + '&password=' + user.password +
                            '&confirmPassword=' + user.confirm).then(function (response) {
                                authorization.setLocalUser(response);
                                authorization.getAuthorizationHeaders();
                                $location.path('/');
                            }, function (error) {
                                alert(error.error_description);
                            }).finally(function () {
                                $scope.loading = false;
                                service.headers = {};
                            }
                        )
                    }
                };
            }
        ]
    )
});