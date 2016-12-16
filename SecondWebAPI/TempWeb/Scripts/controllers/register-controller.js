angular.module('main')
.controller('register-controller', [
'$scope', '$http',
function ($scope, $http) {

    $scope.registerBlock = true;

    $scope.toggle = function () {
        $scope.registerBlock = true;
        $scope.logOut = false;
    }

    $scope.register = function () {

        var data = {
            email: $scope.email,
            password: $scope.password,
            confirmPassword: $scope.confirmpassword
        };
        $http.post('/api/Account/Register', data).then(
            function () {
                alert("Register is successfull");
                $scope.logOut = true;
                $scope.registerBlock = false;
            },
            function () {
                alert("Error");
       });

    }

    $scope.logIn = function () {
        var tokenKey = "tokenInfo";
        var loginData = {
            grant_type: 'password',
            username: $scope.emailLogin,
            password: $scope.passwordLogin
        };

        $http.post('/Token', loginData).then(
           function () {
               alert("Login is successfull");
               $scope.logOut = true;
               $scope.registerBlock = false;
               sessionStorage.setItem(tokenKey, data.access_token);
               var container = document.getElementById("container");
               container.style.display = "block";
           },
           function () {
               alert("Error");
           });
    };
}]);