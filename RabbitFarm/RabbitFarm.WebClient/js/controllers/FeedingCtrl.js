'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Feeding', []).controller('FeedingCtrl', ['$scope', 'resource', 'service',
            function ($scope, resource, service) {

                $scope.loading = true;

                $scope.getResources = function () {
                    resource('GET', 'Feeding/All').then(function (response) {
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

                    resource('GET', 'Feeding/Get/' + id).then(function (response) {
                        if (response.FeedingDate) {
                            response.FeedingDate = new Date(response.FeedingDate.slice(0, 10));
                        }

                        $scope.feeding = response;
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    })
                };

                $scope.save = function (feeding) {
                    $scope.loading = true;

                    var feedingToSave = {};

                    resource('PUT', 'Feeding/Update/' + feeding.Id, feedingToSave).then(function (response) {
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };

                $scope.remove = function (id) {
                    $scope.loading = true;

                    resource('DELETE', 'Feeding/Delete/' + id).then(function () {
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