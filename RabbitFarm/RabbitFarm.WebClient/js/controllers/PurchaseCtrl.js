'use strict';

define(['angular', 'services/resource'], function (angular) {
    angular.module('App.Purchase', []).controller('PurchaseCtrl', ['$scope', 'resource',
            function ($scope, resource) {

                $scope.loading = true;

                $scope.getResources = function () {
                    resource('GET', 'Purchase/All').then(function (response) {
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

                    resource('GET', 'Purchase/Get/' + id).then(function (response) {
                        console.log(response);
                        $scope.purchase = response;
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    })
                };

                $scope.save = function (purchase) {
                    $scope.loading = true;

                    var purchaseToSave = {};

                    resource('PUT', 'Purchase/Update/' + purchase.Id, purchaseToSave).then(function (response) {
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };

                $scope.remove = function (id) {
                    $scope.loading = true;

                    resource('DELETE', 'Purchase/Delete/' + id).then(function () {
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