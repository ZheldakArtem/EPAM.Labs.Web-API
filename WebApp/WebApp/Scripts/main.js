angular.module('AppServiceModule', [])
.service('ItemServise', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('/api/Items');
        },
        add: function (data) {
            return $http.post('/api/Items', data);
        },
        remove: function (id) {
            return $http.delete('/api/Items/' + id);
        },
        update: function (id, data) {
            return $http.put('/api/Items/' + id, data);
        }
    }
}]);

angular.module('main', ['AppServiceModule'])
.controller('items', [
'$scope', '$http', 'ItemServise',
function ($scope, $http, ItemServise) {

    $scope.addItem = function () {
        var newItem = {
            author: $scope.author,
            tittle: $scope.tittle,
            task: $scope.task,
            createDate: new Date().toDateString()
        }
        $scope.Items.push(newItem);
        ItemServise.add(newItem);

        clear();
    }

    $scope.removeItem = function (index, elem) {
        $scope.Items.splice(index, 1);

        ItemServise.remove(elem.id)
    }

    $scope.updateItem = function (elem) {
        elem.author = $scope.author;
        elem.tittle = $scope.tittle;
        elem.task = $scope.task;
        ItemServise.update(elem.id, elem)
    }

    function clear() {
        $scope.author = '';
        $scope.tittle = '';
        $scope.task = '';

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
