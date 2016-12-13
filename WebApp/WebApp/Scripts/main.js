angular.module('AppServiceModule', [])
.service('ItemServise', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('/api/Items');
        },
        save: function (data) {
            return $http.post('/api/Items', data);
        },
        remove: function (id) {
            return $http.delete('/api/Items/'+id);
        }
    }
}]);

angular.module('main', ['AppServiceModule'])
.controller('list', [
'$scope', '$http', 'ItemServise',
function ($scope, $http, ItemServise) {

    $scope.newItem = '';
    $scope.MyFunc = function () {
        alert("click");
    };
    $scope.addItem = function () {
        $scope.newItem = {
            id: $scope.id,
            author: $scope.author,
            tittle: $scope.tittle,
            task: $scope.task,
            createDate: new Date().toDateString()
        }
        $scope.Items.push($scope.newItem);
        ItemServise.save($scope.newItem);

        $scope.newImg = '';
    }

    $scope.removeItem = function (index, elem) {
        $scope.Items.splice(index, 1);

        ItemServise.remove(elem.id)
    }

    function init() {
        ItemServise.getAll().then(function (response) {
            $scope.Items = [];

            response.data.forEach(function (element, index, array) {
                $scope.Items.push({
                    id: element.Id,
                    author: element.Author,
                    tittle: element.Tittle,
                    task: element.Task,
                    createDate: element.CreateDate
                });
            })
        });
    }

    init();
}]);
