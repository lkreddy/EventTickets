app.controller('TicketsCtrl', function ($scope, $http) {
    $scope.evnts = [];
    $http.get('http://eventticketapi.azurewebsites.net/events')
       .then(function (response) {
           $scope.evnts = angular.fromJson(response.data);
       }
       , function (response) {          
           alert("Error in retrieving events information ");
       });

    $scope.tickets = [];
    
    $scope.SaveTickets = function () {
        //var ticketdata = '[{\"ticketname\":\"Ticket1\",\"sessiondesc\":\"Session1\",\"eventname\":\"MyEvent\",\"availability\":\"2 Day Event\",\"minqty\":3,\"maxqty\":5,\"price\":10}]';
        var ticketdata = '[{\"ticketname\":\"' + $scope.ticket.ticketname
             + '\",\"eventname\":\"' + $scope.selEvent.eventname
             + '\",\"sessiondesc\":\"' + $scope.selEvent.sessiondesc
             + '\",\"availability\":\"' + $scope.ticket.availability
             + '\",\"minqty\":' + $scope.ticket.minqty
             + ',\"maxqty\":' + $scope.ticket.maxqty
             + ',\"price\":' + $scope.ticket.price
             + ',\"status\": 1}]';

        $scope.tickets.push(
        {
           ticketname: $scope.ticket.ticketname,
           eventname: $scope.selEvent.eventname,
           sessiondesc: $scope.selEvent.sessiondesc,
           availability: $scope.ticket.availability,
           minqty: $scope.ticket.minqty,
           maxqty: $scope.ticket.maxqty,
           price: $scope.ticket.price           
       });

        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }

        var data = angular.toJson(ticketdata);
        $http.post('http://eventticketapi.azurewebsites.net/tickets', data, config)
          .success(function (data, status, header, config) {
              alert("Ticket created successfully");
          })
              .error(function (data, status, header, config) {
                    alert("Error in saving Ticket");
          });
     };
});
