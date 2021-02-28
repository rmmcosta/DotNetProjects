(function (app) {

    var DetailController = function ($scope, movieService, $routeParams) {

        var id = $routeParams.id;

        movieService.getById(id)
            .then(response => $scope.movie = response,
                response => $scope.movie = response.statusText
            );

        $scope.edit = () => {
            $scope.edit.movie = angular.copy($scope.movie.data);
        };

    };

    app.controller("DetailController", DetailController);

}(angular.module("atTheMovie")));