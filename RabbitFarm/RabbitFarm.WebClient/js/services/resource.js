'use strict';

define(['angular'], function (angular) {
    angular.module('App.Resource', [])
        .factory('resource', ['$http', '$q', 'service',
            function ($http, $q, service) {

                return function (method, table, data) {
                    var deferred = $q.defer();

                    $http({
                        method: method,
                        url: service.url + table,
                        headers: service.headers,
                        data: data
                    })
                        .success(deferred.resolve)
                        .error(deferred.reject);

                    return deferred.promise;
                }
            }
        ]
    )
});