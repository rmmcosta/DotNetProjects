(function (app) {
    var EditController = function ($scope, movieService) {

        $scope.isEditable = () => $scope.edit && $scope.edit.movie;

        $scope.cancel = () => $scope.edit.movie = null;

        $scope.save = () => {
            if ($scope.edit.movie.ID)
                updateMovie();
            else
                createMovie();
        };

        var updateMovie = () => {
            movieService
                .update($scope.edit.movie)
                .then(() => {
                    angular.extend($scope.movie.data, $scope.edit.movie);
                    $scope.edit.movie = null;
                });
        };

        var createMovie = () => {
            movieService
                .create($scope.edit.movie)
                .then(movie => {
                    $scope.movies.data.push(movie.data);
                    $scope.edit.movie = null;
                });
        };
    };
    app.controller("EditController", EditController);
}(angular.module("atTheMovie")));