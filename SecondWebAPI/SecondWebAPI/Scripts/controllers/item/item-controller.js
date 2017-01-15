angular.module('main', ['AppServiceModule'])
.controller('item-controller', [
'$scope', '$http', 'item-service', '$mediator',
function ($scope, $http, itemService, $mediator) {

    $scope.addItem = function () {
        var newItem = {
            id: 0,
            author: $scope.author,
            tittle: $scope.tittle,
            task: $scope.task,
            createDate: new Date().toDateString()
        }

        itemService.add(newItem).then(
            function () {
                init();
            },
             function () {
                 alert("incorrect item!!!")
             });

        clearItem();
    }

    $scope.removeItem = function (index, elem) {

        if (!confirm("Are you shure?")) {
            return;
        }

        $scope.Items.splice(index, 1);

        itemService.remove(elem.id);
    }

    $scope.updateItem = function (elem) {
        itemService.update(elem.id,
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

    function clearItem() {
        $scope.author = '';
        $scope.tittle = '';
        $scope.task = '';

    }

    function init() {
        itemService.getAll().then(function (response) {
            $scope.Items = [];
            var data = JSON.parse(response.data);
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
    $mediator.$on('my:event', function (event, show) {
        $scope.showItem = show;
        init();
    });

}]);


