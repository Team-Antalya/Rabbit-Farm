'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Register', [])
        .controller('RegisterCtrl', ['$scope', 'account', function ($scope, account) {

            $scope.register = function (user, form) {
                if (form.$valid) {
                    account.register(user);


                }
            }
        }]
        )
});