'use strict';

define(['angular'], function (angular) {
    angular.module('App.Resource', [])
        .factory('resource', ['$http', '$q', 'service',
            function ($http, $q, service) {

                return function (method, table, data, noApi) {
                    var deferred = $q.defer();

                    $http({
                        method: method,
                        url: (noApi ? service.url.replace('api/', '') : service.url) + table,
                        headers: service.headers,
                        data: data
                    }).success(function (res) {
                        deferred.resolve(res);
                    }).error(function (res) {
                        deferred.reject(res);
                    });

                    return deferred.promise;
                }
            }
        ]
    )
});