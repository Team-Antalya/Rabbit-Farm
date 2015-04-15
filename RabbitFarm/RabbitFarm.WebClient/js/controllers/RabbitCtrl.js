'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Rabbit', []).controller('RabbitCtrl', ['$scope', 'resource',
            function ($scope, resource) {

                $scope.loading = true;

                resource('GET', 'Rabbit/All').then(function (response) {
                    $scope.data = response;
                }, function (error) {
                    console.log(error);
                }).finally(function () {
                    $scope.loading = false;
                });

                $scope.edit = function (rabbit) {
                    console.log($('button[data-rabbit]'));
                };
            }
        ]
    )
});