(function () {
    var app = angular.module("atTheMovie", ["ngRoute"]);
    var config = function ($routeProvider) {
        $routeProvider
            .when("/list",
                { templateUrl: "/App/Views/ListMovies.html" }
            )
            .when("/details/:id",
                { templateUrl: "/App/Views/MovieDetail.html" }
            )
            .otherwise({ redirectTo: "/list" })
    };
    app.config(config);
    app.constant("movieApiUrl", "/api/movies/");
}());