'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Rabbit', []).controller('RabbitCtrl', ['$scope', 'resource', 'service',
            function ($scope, resource, service) {

                $scope.loading = true;

                $scope.getResources = function () {
                    resource('GET', 'Rabbit/All').then(function (response) {
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

                    resource('GET', 'Rabbit/Get/' + id).then(function (response) {
                        if (response.Acquisition) {
                            response.Acquisition.AcquisitionDate = new Date(response.Acquisition.AcquisitionDate.slice(0, 10));
                        }

                        $scope.rabbit = response;
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    })
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

                    angular.extend(service.headers, {'Content-Type': 'application/x-www-form-urlencoded'});

                    resource('PUT', 'Rabbit/Update/' + rabbit.Id, rabbitToSave).then(function (response) {
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        service.headers = {};
                        $scope.loading = false;
                    });
                };

                $scope.remove = function (id) {
                    $scope.loading = true;

                    angular.extend(service.headers, {'Content-Type': 'application/x-www-form-urlencoded'});

                    resource('DELETE', 'Rabbit/Delete/' + id).then(function () {
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                        service.headers = {};
                        $scope.getResources();
                    })
                }
            }
        ]
    )
});