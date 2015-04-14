'use strict';

define(['angular', 'services/account'], function (angular) {
    angular.module('App.Login', [])
        .controller('LoginCtrl', ['$scope', 'account', function ($scope, account) {

            $scope.login = function (user, form) {
                if(form.$valid) {
                    account.login(user);
                }
                else {
                    console.log('Error');
                }
            }
        }]
    )
});