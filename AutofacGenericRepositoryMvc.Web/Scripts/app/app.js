'use strict';

/* App Module */
var personApp = angular.module('personApp', [
    'ngRoute',
    'personControllers',
    'personServices',
    'personDirectives'
]);

personApp.config([
    '$routeProvider', '$locationProvider',
    function($routeProvider, $locationProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/Angular/PersonList',
                controller: 'PersonCtrl'
            }).
            when('/Create', {
                templateUrl: '/Angular/Create',
                controller: 'PersonCreateCtrl'
            }).
            when('/Detail/:id', {
                templateUrl: '/Angular/Detail',
                controller: 'PersonDetailCtrl'
            }).
            when('/Edit/:id', {
                templateUrl: '/Angular/Edit',
                controller: 'PersonEditCtrl'
            }).
            otherwise({
                redirectTo: '/'
            });

        // Remove hash from url
        //$locationProvider.html5Mode(true);
    }
]);