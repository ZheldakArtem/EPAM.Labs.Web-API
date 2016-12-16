angular.module('AppServiceModule', [])
.service('item-servise', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('/api/Home');
        },
        add: function (data) {
            return $http.post('/api/Home', data);
        },
        remove: function (id) {
            return $http.delete('/api/Home/' + id);
        },
        update: function (id, data) {
            return $http.put('/api/Home/' + id, data);
        }
    }
}]);