angular.module('AppServiceModule')
.service('login-service', ['$http', function ($http) {
    return {
        sendLogOut:function(){
            return $http.get('/api/Login');
        },
        sendLogIn: function (data) {
            return $http.post('/api/Login', data);
        }
    }
}]);