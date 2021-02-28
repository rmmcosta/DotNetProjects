(function (app) {
    var ListController = function ($scope, movieService) {

        movieService
            .getAll()
            .then(response => $scope.movies = response,
                response => $scope.movies = response.statusText
            );

        $scope.delete = movie => movieService.delete(movie)
            .then(() => removeMovieById(movie.ID), response => console.log(response));

        $scope.create = () => {
            $scope.edit = {
                movie: {
                    Title: "",
                    ReleaseYear: new Date().getFullYear(),
                    Runtime: 0
                }
            };
        };

        var removeMovieById = id => {
            var movies = $scope.movies.data;
            for (var i = 0; i < movies.length; i++) {
                if (movies[i].ID === id) {
                    movies.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("ListController", ListController);
}(angular.module("atTheMovie")));