'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Register', [])
        .controller('RegisterCtrl', ['$scope', 'account', '$location',
            function ($scope, account, $location) {

                $scope.register = function (user, form) {
                    if (form.$valid) {
                        account.register(user)
                            .then(
                            function success(registerSuccessData) {
                                console.dir(registerSuccessData);
                                $location.path('/login');
                            },
                            function error(registerErrorData) {
                                console.dir(registerErrorData);
                            }
                        );
                    }
                }
            }]
        )
});