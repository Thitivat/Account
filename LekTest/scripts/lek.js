var app = angular.module("LekApp", ['ngMaterial', 'ngMessages']);
var editId;
angular.module('LekApp').config(function ($mdDateLocaleProvider) {
    $mdDateLocaleProvider.formatDate = function (date) {
        return moment(date).format("YYYY-MM-DD");
    };
});

//app.service('dataService', function () {
//    var itemList = [];

//    var addItem = function (newObj) {
//        itemList.push(newObj);
//    };

//    var getItems = function () {
//        return itemList;
//    };

//    return {
//        addItem: addItem,
//        getItems: getItems
//    };

//});

app.controller("AppCtrl", function ($scope, $location, $window, $http, $log, $mdDialog, $mdSidenav) {

    $scope.toggleRight = buildToggler('right');
    $scope.isOpenRight = function () {
        //dataService.addItem(item);
        return $mdSidenav('right').isOpen();
    };

    $scope.showDelete = function (ev) {
        // Appending dialog to document.body to cover sidenav in docs app
        var confirm = $mdDialog.confirm()
              .title('Would you like to delete this record?')
              .textContent('Delete this row id: ' + ev + '.')
              .ariaLabel('Lucky day')
              //.targetEvent(ev)
              .ok('Delete!')
              .cancel('Cancel');

        $mdDialog.show(confirm).then(function () {
            $http({
                method: 'POST',
                url: 'Home/Delete',
                data: { id: ev },
                //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
            .then(function (result) {
                // Success
                var url = "http://" + $window.location.host;
                $window.location.href = url;
            }, function (result) {
                // Error
                alert("fail");
            });
        },
        function () {
            // press cancel button
        });
    };

    function debounce(func, wait, context) {
        var timer;

        return function debounced() {
            var context = $scope,
                args = Array.prototype.slice.call(arguments);
            $timeout.cancel(timer);
            timer = $timeout(function () {
                timer = undefined;
                func.apply(context, args);
            }, wait || 10);
        };
    }

    function buildDelayedToggler(navID) {
        return debounce(function () {
            $mdSidenav(navID)
              .toggle()
              .then(function () {
                  $log.debug("toggle " + navID + " is done");
              });
        }, 200);
    }

    function buildToggler(navID) {
        return function () {
            $mdSidenav(navID)
              .toggle()
              .then(function () {
                  $log.debug("toggle " + navID + " is done");
              });
        }
    }

    $scope.showDetails = function (ev) {
        var url = 'http://' + $window.location.host + '/Home/Details/' + ev;
        $window.location.href = url;
    };

    $scope.showEdit = function (ev) {
        var url = 'http://' + $window.location.host + '/Home/Edit/' + ev;
        $window.location.href = url;
    };
});

app.controller('RightCtrl', function ($scope, $timeout, $mdSidenav, $log) {
    $scope.close = function () {
        $mdSidenav('right').close()
          .then(function () {
              $log.debug("close RIGHT is done");
          });
    };

    $scope.editTransaction = {
        name: "",
        amount: 0,
        description: "",
        type: "",
        date: null
    };

    $scope.edit = function (value) {
        //var value = dataService.getItems();
        $scope.editTransaction.name = value.name;
        $scope.editTransaction.description = value.description;
        $scope.editTransaction.type = value.type;
        $scope.editTransaction.date = value.date;
        $scope.editTransaction.amount = value.amount;
        alert("Edit Data" + $scope.editTransaction.name);
    };
});

app.controller("CreateCtrl", function ($scope, $location, $window, $http, $log) {
    $scope.transaction = {
        date: new Date(),
    }
});

app.controller("EditCtrl", function ($scope, $location, $window, $http, $log) {
    $scope.transaction = {
        //createdDate: new Date(),
    }
});