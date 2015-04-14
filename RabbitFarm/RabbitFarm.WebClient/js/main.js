'use strict';

require.config({
    paths: {
        angular: 'libs/angular/angular',
        angularRoute: 'libs/angular-route/angular-route',
        angularCookies: 'libs/angular-cookies/angular-cookies',
        angularMocks: 'libs/angular-mocks/angular-mocks',
        text: 'libs/requirejs-text/text',
        jquery: 'libs/jquery/dist/jquery',
        bootstrap: 'libs/bootstrap/dist/js/bootstrap'
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

            (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
                (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
                m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
            })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

            ga('create', 'UA-40584040-1', 'auto');
            ga('send', 'pageview');
        });
    }
);