angular.module('main')
.controller('login-controller', [
   'login-service', '$scope', '$mediator',
    function (loginService, $scope, $mediator) {
       
        $scope.toggle = false;
        $scope.logIn = function (name, pswrd) {
            var data = {
                password: pswrd,
                login: name
            };
            loginService.sendLogIn(data).then
                (function () {                  
                    $scope.toggle = true;

                    $mediator.$emit('my:event', true);                   
                },
                function () {
                    alert('Error');
                });
        }

        $scope.logOut = function () {
            loginService.sendLogOut().then
               (function () {
                   $mediator.$emit('my:event', false);
                   $scope.toggle = false;               
               },
               function () {
                   alert('Error');
               });
        }
    }]);