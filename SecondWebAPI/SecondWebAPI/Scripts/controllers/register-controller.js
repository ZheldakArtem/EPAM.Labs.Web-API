angular.module('main')
.controller('register-controller', [
'$scope', '$http',
function ($scope, $http) {

    $scope.registerBlock = true;

    $scope.register = function () {

         var data = {
            email: $scope.email,
            password: $scope.password,
            confirmPassword: $scope.confirmpassword
        };
        $http.post('/api/Account/Register', data).then(function () {
            alert("Register is successfull");
            $scope.logOut = true;
            $scope.registerBlock = false;
        },
        function () {
            alert("Error");
        });

        //if ($scope.register) {
        //    $scope.logOut = true;
        //    $scope.register = false;
        //} else {
        //    $scope.logOut = false;
        //    $scope.register = true;
        //}    
    };

}]);