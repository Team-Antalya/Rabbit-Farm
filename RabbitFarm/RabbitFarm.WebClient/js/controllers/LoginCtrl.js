'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Login', [])
        .controller('LoginCtrl', ['$scope', 'account', 'authorization', '$location',
            function ($scope, account, authorization, $location) {
                $scope.login = function (user, form) {
                    if (form.$valid) {
                        account.login(user).then(
                            function success(loginSuccessData) {
                                authorization.setLocalUser(loginSuccessData);
                                authorization.getAuthorizationHeaders();

                                $location.path('/');
                            },
                            function error(loginErrorData) {
                                console.dir(loginErrorData)
                            }
                        )
                    }
                };

                $scope.logout = function () {
                    account.logout().then(
                        function success() {
                            sessionStorage.clear();
                            $location.path('/');
                        },
                        function error(logoutErrorMessage) {
                            console.dir(logoutErrorMessage);
                        }
                    )
                }


            }]
        )
});