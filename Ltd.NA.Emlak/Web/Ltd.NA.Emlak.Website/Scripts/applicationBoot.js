var emlakApp = angular.module('emlakApp', []);

emlakApp.controller('searchController', function($scope) {

    // filter view model
    $scope.filter = {
        address: undefined,
        city: undefined,
        zipCode: undefined
    };

    // paging view model
    $scope.paging = {
        totalRows: undefined,
        totalPages: function() {
            return Math.round(totalRows/recordsPerPage)
        },
        currentPage: undefined,
        recordsPerPage: undefined
    }

    // trigger a search
    $scope.search = function() {
        alert('You search for ' + $scope.filter.address);
    };

});