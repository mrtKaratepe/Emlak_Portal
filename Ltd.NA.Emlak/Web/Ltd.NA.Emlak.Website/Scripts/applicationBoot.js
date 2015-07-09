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
        take: 2,
        skip: 0
    };

    // paging view model
    $scope.paging = {
        totalRows: 0,
        recordsPerPage: $scope.filter.take,
        totalPages: function () {
            var range = new Array ;
            var total = Math.ceil(this.totalRows / this.recordsPerPage);

            for (var i = 0; i <total; i++) {
                range.push(i);
            }
            return range;
        },
        currentPage: 0
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
        var totalPagesCount = Math.ceil($scope.paging.totalRows / $scope.paging.recordsPerPage);
        if (totalPagesCount > page && page >= 0) {
            // clean up the collection
            $scope.loading = true;
            this.houses = [];
            $scope.filter.skip = $scope.filter.take * page;

            // send a new search request with new parameters
            $scope.search();

            // update the paging view model
            $scope.paging.currentPage = page;
            $scope.loading = false;
        }
        console.log(page);
    };
});