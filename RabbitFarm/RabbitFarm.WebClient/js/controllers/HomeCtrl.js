'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Home', []).controller('HomeCtrl', ['$scope', 'resource','account', 'authorization', '$location',
            function ($scope, resource,account, authorization, $location) {
                if(authorization.getAuthorizationHeaders()){
                   $scope.account = account;
                }
            }
        ]
    )
});