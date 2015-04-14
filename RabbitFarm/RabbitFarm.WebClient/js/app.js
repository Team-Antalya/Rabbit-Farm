'use strict';

define(
    [ // Paths
        'angular',
        'angularRoute',

        'services/resource',
        'services/routeResolver',
        'services/account',

        'directives/activeLink',

        'controllers/HomeCtrl',

        'controllers/RabbitCtrl',
        'controllers/FeedingCtrl',
        'controllers/PurchaseCtrl',
        'controllers/RealizationCtrl',
        'controllers/ReportCtrl',

        'controllers/LoginCtrl',
        'controllers/RegisterCtrl'
    ],
    function (angular) {

        return angular.module('App',
            [ // Modules
                'ngRoute',
                'App.RouteResolver',
                'App.Resource',
                'App.Account',

                'App.Link',

                'App.Home',
                'App.Login',
                'App.Register',
                'App.Rabbit',
                'App.Feeding',
                'App.Purchase',
                'App.Realization',
                'App.Report'
            ])
            .config(['$routeProvider', 'routeResolverProvider',
                function ($routeProvider, routeResolverProvider) {

                    var route = routeResolverProvider.route;

                    $routeProvider
                        .when('/', route.resolve('Rabbit'))
                        .when('/feedings', route.resolve('Feeding'))
                        .when('/purchases', route.resolve('Purchase'))
                        .when('/realizations', route.resolve('Realization'))
                        .when('/reports', route.resolve('Report'))

                        .when('/login', route.resolve('Login'))
                        .when('/register', route.resolve('Register'))
                        .otherwise({redirectTo: '/'});
                }])
            .run(['$location', '$rootScope', 'account', function ($location, $rootScope, account) {
                $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {

                    if (current.hasOwnProperty('$$route')) {
                        $rootScope.title = current.$$route.title;
                    }
                });

                $rootScope.$on('$routeChangeStart', function (event, next, current) {
                    if (next && next.$$route && next.$$route.secure) {
                        //if (!authService.user.isAuthenticated) {
                        //    authService.redirectToLogin();
                        //}
                    }
                });
            }])
            .constant('app', {
                title: 'Rabbit Farm',
                description: 'Rabbit Farm Manager',
                url: 'https://github.com/Team-Antalya/Rabbit-Farm'
            })
            .constant('service', {
                url: 'http://localhost:4741/api/',
                headers: {
                    //'X-Parse-Application-Id': 'LZDh2PdmAw839VX7DsoBCB9dMj700VfYfZNMRKDF',
                    //'X-Parse-REST-API-Key': 'iZuEgvv58kEQ3YyaBK4VWOfaJH8AWFkt7xExgbrv'
                }
            });
    }
);