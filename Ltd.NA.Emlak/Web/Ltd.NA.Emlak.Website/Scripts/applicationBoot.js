var emlakApp = angular.module('emlakApp', []);
var apiUrl = 'http://localhost:8652/';

emlakApp.controller('searchController', function ($scope, $http,$q) {
    $scope.loading = true;
    $scope.ViewModelHouse=[];

    // filter view model
    $scope.filter = {
        street:undefined,
        address: undefined,
        city: undefined,
        zipCode: undefined,
        type:undefined
    };

    // paging view model
    $scope.paging = {
        totalRows: undefined,
        totalPages: function () {
            return Math.round(totalRows / recordsPerPage)
        },
        currentPage: undefined,
        recordsPerPage: undefined
    };

    //Try-4
    function gethouses() {
        var deferred = $q.defer();
        $http.post({
            '/api/Houses/', 
            $scope.filter
        })
            .success(function (results) {
            $scope.ViewModelHouse = results;
            $scope.loading = false;
            deferred.resolve(results);
            console.log('Success');
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed getting contacts');
            $scope.loading = false;
            console.log('An Error has occured while loading posts!');
        });

        return deferred.promise;
    };


    // trigger a search
    $scope.search = function () {
        console.log('First You search for ' + $scope.filter.address + ' Also From filter: ' + $scope.filter.type);
        gethouses();
        /*
        //Try-3
        $http.get('~/api/Houses').success(function (data) {
            $scope.filter = data;
            $scope.loading = false;
            alert('success ');
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
            alert('An Error has occured while loading posts!');
        });
        */
    };


});