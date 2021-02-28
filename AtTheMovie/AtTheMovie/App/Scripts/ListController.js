(function (app) {
    var ListController = function ($scope, $http) {
        $http.get("api/movies/")
            .then(response => $scope.movies = response,
                response => $scope.movies = response.statusText
            );
    };
    app.controller("ListController", ListController);
}(angular.module("atTheMovie")));