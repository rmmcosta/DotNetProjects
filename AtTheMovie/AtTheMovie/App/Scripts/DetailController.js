(function (app) {
    var DetailController = function ($scope, $http, $routeParams) {
        var id = $routeParams.id;
        $http.get("/api/Movies/" + id)
            .then(response => $scope.movie = response,
                response => $scope.movie = response.statusText
            );
    };
    app.controller("DetailController", DetailController);
}(angular.module("atTheMovie")));