'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Purchase', []).controller('PurchaseCtrl', ['$scope', 'resource',
            function ($scope, resource) {

                $scope.loading = true;

                resource('GET', 'Purchase/All').then(function (response) {
                    $scope.data = response;
                }, function (error) {
                    console.log(error);
                }).finally(function () {
                    $scope.loading = false;
                })
            }
        ]
    )
});