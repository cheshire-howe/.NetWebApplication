'use strict';

/* Controllers */

var personControllers = angular.module('personControllers', []);

personControllers.controller('PersonCtrl', [
    '$scope', '$location', 'Person',
    function($scope, $location, Person) {
        $scope.persons = Person.query();

        $scope.deletePerson = function(personId) {
            Person.delete({ id: personId }, function () {
                $scope.persons = Person.query();
            });
        };
    }
]);

personControllers.controller('PersonCreateCtrl', [
    '$scope', '$location', '$http', 'Person',
    function ($scope, $location, $http, Person) {
        $scope.item = new Person();

        $http.get('/api/CountryApi').
            success(function (countries) {
                $scope.countries = countries;
                $scope.item.CountryId = countries[0].Id;
        });

        $scope.save = function() {
            $scope.item.$save(function() {
                $location.path('/');
            });
        };
    }
]);

personControllers.controller('PersonDetailCtrl', [
    '$scope', '$routeParams', 'Person',
    function($scope, $routeParams, Person) {
        $scope.person = Person.get({ id: $routeParams.id });
    }
]);

personControllers.controller('PersonEditCtrl', [
    '$scope', '$routeParams', '$location', '$http', 'Person',
    function ($scope, $routeParams, $location, $http, Person) {
        $scope.update = function() {
            $scope.item.$update({ id: $scope.item.Id }, function() {
                $location.path('/');
            });
        };

        $scope.loadPerson = function() {
            $scope.item = Person.get({ id: $routeParams.id }, function (data) {
                var s = "";
                for (var i = 0; i < data.Languages.length - 1; i++) {
                    s += data.Languages[i].Name + ', ';
                }
                s += data.Languages[data.Languages.length - 1].Name;
                $scope.item.Languages = s;
            });
            $http.get('/api/CountryApi').
                success(function (countries) {
                    $scope.countries = countries;
                });
        };

        $scope.loadPerson();
    }
]);
