'use strict';

require.config({
    paths: {
        angular: 'libs/angular/angular',
        angularRoute: 'libs/angular-route/angular-route',
        angularCookies: 'libs/angular-cookies/angular-cookies',
        angularMocks: 'libs/angular-mocks/angular-mocks',
        text: 'libs/requirejs-text/text',
        jquery: 'libs/jquery/dist/jquery',
        bootstrap: 'libs/bootstrap/dist/js/bootstrap',
        modal: 'libs/bootstrap-modal/js/bootstrap-modal'
    },
    shim: {
        angular: {exports: 'angular'},
        angularRoute: {
            deps: ['angular']
        },
        angularCookies: {
            deps: ['angular']
        },
        angularMocks: {
            deps: ['angular'],
            exports: 'angular.mock'
        },
        bootstrap: {
            deps: ['jquery']
        },
        modal: {
            deps: ['bootstrap']
        }
    },
    priority: [
        'angular'
    ],
    deps: [],
    callback: null,
    baseUrl: 'js'
});

require(['angular', 'app', 'bootstrap'], function (angular, app) {
        angular.element(document).ready(function () {
            angular.bootstrap(document, ['App']);
        });
    }
);