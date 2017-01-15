angular.module('main')
.factory('$mediator', function ($rootScope) {
    return $rootScope.$new(true);
});