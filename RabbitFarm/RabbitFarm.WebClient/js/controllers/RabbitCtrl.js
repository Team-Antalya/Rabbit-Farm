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

                $scope.edit = function (id) {
                    $scope.loading = true;

                    resource('GET', 'Rabbit/Get/' + id).then(function (response) {
                        response.Acquisition.AcquisitionDate = new Date(response.Acquisition.AcquisitionDate.slice(0, 10));
                        $scope.rabbit = response;
                    }, function (error) {
                        alert(error);
                    }).finally(function () {
                        $scope.loading = false;
                    }).then()
                };

                $scope.save = function (rabbit) {
                    $scope.loading = true;

                    var rabbitToSave = {
                        Mark: rabbit.Mark,
                        Gender: rabbit.Gender,
                        Status: rabbit.Status,
                        LitterId: rabbit.LitterId,
                        AcquisitionId: rabbit.AcquisitionId,
                        FarmId: rabbit.FarmId
                    };

                    resource('PUT', 'Rabbit/Update/' + rabbit.Id, rabbitToSave).then(function (response) {
                        alert(response);
                    }, function (error) {
                        alert(error);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };

                $scope.remove = function (id) {
                    $scope.loading = true;

                    resource('DELETE', 'Rabbit/Delete/' + id).then(function () {
                    }, function (error) {
                        alert(error);
                    }).finally(function () {
                        $scope.loading = false;
                    })
                }
            }
        ]
    )
});