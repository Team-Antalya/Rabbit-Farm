'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Realization', []).controller('RealizationCtrl', ['$scope', 'resource',
            function ($scope, resource) {

                $scope.loading = true;

                $scope.getResources = function () {
                    resource('GET', 'Realization/All').then(function (response) {
                        $scope.data = response;
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };
                $scope.getResources();

                $scope.edit = function (id) {
                    $scope.loading = true;

                    resource('GET', 'Realization/Get/' + id).then(function (response) {
                        if(response.RealizationDate) {
                            response.RealizationDate = new Date(response.RealizationDate.slice(0, 10));
                        }

                        $scope.realization = response;
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    })
                };

                $scope.save = function (realization) {
                    $scope.loading = true;
                    var realizationToSave = {};

                    resource('PUT', 'Realization/Update/' + realization.Id, realizationToSave).then(function (response) {
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };

                $scope.remove = function (id) {
                    $scope.loading = true;

                    resource('DELETE', 'Realization/Delete/' + id).then(function () {
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                        $scope.getResources();
                    })
                }
            }
        ]
    )
});