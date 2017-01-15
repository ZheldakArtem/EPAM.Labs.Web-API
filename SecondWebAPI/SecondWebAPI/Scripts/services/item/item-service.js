angular.module('AppServiceModule', [])
.service('item-service', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get(path);
        },
        add: function (data) {
            return $http.post(path, data);
        },
        remove: function (id) {
            return $http.delete(path + id);
        },
        update: function (id, data) {
            return $http.put(path + id, data);
        }
    }
}]);