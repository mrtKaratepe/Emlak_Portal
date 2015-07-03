var emlakApp = angular.module('emlakApp', []);

emlakApp.controller('searchController', function ($scope, $http) {

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

    $http({
        method: 'POST',
        data: $.param({ fkey: "key" }),
        headers: { 'Content-Type': '~/api/Houses' }
    })

    $http.post('~/api/Houses').success(function (data) {
        $scope.filter = data.items;
        alert('You search for ' + $scope.filter.address + ' Also From filter: ' + $scope.filter.type);
    });

    // trigger a search
    $scope.search = function () {
        alert('You search for ' + $scope.filter.address + ' Also From filter: ' + $scope.filter.type);
    };


});