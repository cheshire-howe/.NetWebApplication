'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
var personServices = angular.module('app.services', ['ngResource']);

personServices.factory('Person', [
    '$resource', function($resource) {
        return $resource('http://localhost:1708/api/PersonApi/:id', { id: '@id' }, {
            update: {
                method: 'PUT'
            }
        });
    }
]);