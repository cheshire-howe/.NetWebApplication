'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS PersonApi SPA';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | About';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /People
    .controller('ListCtrl', ['$scope', '$location', '$state', '$window', 'Person', function ($scope, $location, $state, $window, Person) {

        $scope.people = Person.query();

        $scope.deletePerson = function(id) {
            Person.delete({ id: id }, function() {
                $scope.people = Person.query();
            });
        };

        $scope.$root.title = 'AngularJS SPA | People';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /Person/:id
    .controller('DetailCtrl', ['$scope', '$location', '$state', '$stateParams', '$window', 'Person', function ($scope, $location, $state, $stateParams, $window, Person) {
        $scope.person = Person.get({ id: $stateParams.id });
        
        $scope.$root.title = 'AngularJS SPA | Person Details';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /Person/:id/edit
    .controller('EditCtrl', [
        '$scope', '$state', '$stateParams', '$location', '$window', '$http', 'Person',
        function ($scope, $state, $stateParams, $location, $window, $http, Person) {
            $scope.update = function() {
                $scope.person.$update({ id: $scope.person.Id }, function () {
                    $state.go('list');
                });
            };

            $scope.loadPerson = function() {
                $scope.person = Person.get({ id: $stateParams.id }, function (data) {
                    var s = "";
                    for (var i = 0; i < data.Languages.length - 1; i++) {
                        s += data.Languages[i].Name + ', ';
                    }
                    s += data.Languages[data.Languages.length - 1].Name;
                    $scope.person.Languages = s;
                });
                $http.get('http://localhost:1708/api/CountryApi').
                    success(function(countries) {
                        $scope.countries = countries;
                    });
            };

            $scope.loadPerson();
        
            $scope.$root.title = 'AngularJS SPA | Person Edit';
            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });
        }
    ])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);