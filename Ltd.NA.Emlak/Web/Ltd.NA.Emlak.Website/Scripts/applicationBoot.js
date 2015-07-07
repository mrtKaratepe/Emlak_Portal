var emlakApp = angular.module('emlakApp', []);
var apiUrl = 'http://localhost:8652/';

emlakApp.controller('searchController', function ($scope, $http, $q) {

    $scope.loading = false;
    $scope.houses = [];

    // filter view model
    $scope.filter = {
        street:undefined,
        address: undefined,
        city: undefined,
        zipCode: undefined,
        type: undefined,
        take: 10,
        skip: 0
    };

    // paging view model
    $scope.paging = {
        totalRows: 0,
        totalPages: function () {
            return new Array(Math.round(this.totalRows / this.recordsPerPage));
        },
        currentPage: 0,
        recordsPerPage: $scope.filter.take
    };

    $scope.search = function gethouses() {

        $scope.loading = true;

        var request = {
            method: 'POST',
            url: apiUrl + 'api/Houses',
            headers: {
                'Content-Type': 'application/json'
            },
            data: $scope.filter
        }

        $http(request)
        .success(function (result) {
            $scope.houses = result.Items;
            $scope.paging.totalRows = result.TotalRecords;
            $scope.loading = false;
        }).error(function (data, status, headers, config) {
            $scope.loading = false;
        });
    };

    $scope.loadRows = function (page) {
        // clean up the collection

        // send a new search request with new parameters

        // update the paging view model
        console.log(page);
    };
});