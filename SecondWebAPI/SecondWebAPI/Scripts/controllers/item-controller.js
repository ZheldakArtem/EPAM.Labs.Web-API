angular.module('main', ['AppServiceModule'])
.controller('item-controller', [
'$scope', '$http', 'item-servise',
function ($scope, $http, ItemServise) {

    $scope.addItem = function () {
        var newItem = {
            id: 0,
            author: $scope.author,
            tittle: $scope.tittle,
            task: $scope.task,
            createDate: new Date().toDateString()
        }

        ItemServise.add(newItem).then(
            function () {
                $scope.Items.push(newItem);
            },
             function () {
                 alert("incorrect item!!!")
             });

        clear();
    }

    $scope.removeItem = function (index, elem) {

        if (!confirm("Are you shure?")) {
            return;
        }

        $scope.Items.splice(index, 1);

        ItemServise.remove(elem.id);
    }

    $scope.updateItem = function (elem) {      
        ItemServise.update(elem.id,
         {
            id: elem.id,
            author: $scope.author,
            tittle: $scope.tittle,
            task: $scope.task,
            createDate: elem.createDate
        }).then(
            function () {
                elem.author = $scope.author;
                elem.tittle = $scope.tittle;
                elem.task = $scope.task;
            },
             function () {
                 alert("incorrect updated!!!")
            });
    }

    function clear() {
        $scope.author = '';
        $scope.tittle = '';
        $scope.task = '';

    }

    function init() {
        ItemServise.getAll().then(function (response) {
            $scope.Items = [];
            var data = JSON.parse(response.data.Result);
            data.forEach(function (element, index, array) {
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