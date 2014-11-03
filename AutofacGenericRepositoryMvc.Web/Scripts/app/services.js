var personServices = angular.module('personServices', ['ngResource']);

personServices.factory('Person', [
    '$resource',
    function($resource) {
        return $resource('/api/PersonApi/:id', { id: '@id' }, { update: { method: 'PUT' } });
    }
]);