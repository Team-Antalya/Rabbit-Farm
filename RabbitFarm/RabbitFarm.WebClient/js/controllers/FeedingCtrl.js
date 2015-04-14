'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Feeding', []).controller('FeedingCtrl', ['$scope', 'resource',
            function ($scope, resource) {

                $scope.loading = true;

                resource('GET', 'Feeding/All').then(function (response) {
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