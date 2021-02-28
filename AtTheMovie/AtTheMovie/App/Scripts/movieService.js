(function (app) {
    var movieService = function ($http, movieApiUrl) {
        var getAll = () => $http.get(movieApiUrl);
        var getById = id => $http.get(movieApiUrl + id);
        var create = movie => $http.post(movieApiUrl, movie);
        var update = movie => $http.put(movieApiUrl + movie.ID, movie);
        var destroy = movie => $http.delete(movieApiUrl + movie.ID);

        return {
            getAll: getAll,
            getById: getById,
            create: create,
            update: update,
            delete: destroy
        };
    };

    app.factory("movieService", movieService);

}(angular.module("atTheMovie")));