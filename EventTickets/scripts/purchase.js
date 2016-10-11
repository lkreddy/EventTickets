app.controller('PurchaseCtrl', function ($scope, $http) {
    $scope.tickets = [];
    $http.get('http://eventticketapi.azurewebsites.net/tickets')
        .then(function (response) {
            $scope.tickets = angular.fromJson(response.data);
        }
        , function (response) {
            alert("Error in retrieving tickets");
        });

    $scope.transactions = [];
    $http.get('http://eventticketapi.azurewebsites.net/transactions')
        .then(function (response) {
            $scope.transactions = angular.fromJson(response.data);
        }
        , function (response) {
            alert("Error in retrieving transactions");
        });

    $scope.qtylist = [];

    $scope.TicketSelected = function () {
        while ($scope.qtylist.length) {
            $scope.qtylist.pop();
        }

        if ($scope.selTicket != null) {
            for (var i = $scope.selTicket.minqty; i < $scope.selTicket.maxqty + 1; i++) {
                $scope.qtylist.push(i);
            }
        }
    }
    
    $scope.Purchase = function () {
        
                var transdata = '[{\"ticketname\":\"' + $scope.selTicket.ticketname
                        + '\",\"sessiondesc\":\"' + $scope.selTicket.sessiondesc
                        + '\",\"eventname\":\"' + $scope.selTicket.eventname
                        + '\",\"quantity\":' + $scope.quantity
                        + ',\"price\":' + $scope.selTicket.price
                        + ',\"timestamp\":\"2016-03-20\",\"userid\":\"kalyan\"}]';

        $scope.transactions.push(
           {
               ticketname: $scope.selTicket.ticketname,
               sessiondesc: $scope.selTicket.sessiondesc,
               eventname: $scope.selTicket.eventname,
               quantity: $scope.quantity,
               price: $scope.selTicket.price
           });

        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }

        var data = angular.toJson(transdata);
        $http.post('http://eventticketapi.azurewebsites.net/transactions', data, config)
            .success(function (data, status, header, config) {
                alert("Transaction completed successfully");
            })
            .error(function (data, status, header, config) {
                alert("Error in saving Transaction");
            });
    };
});