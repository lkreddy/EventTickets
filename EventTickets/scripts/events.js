app.controller('EventsCtrl', function ($scope, $http) {
    //if($rootscope.loginid == ''){
    //    $location.path('/login');
    //    $scope.$apply();
    //}

    $scope.evnts = [];
    //$scope.evnts = {
    //    startdate: new Date(2016, 3, 28),
    //    starttime: new Date(1970, 0, 1, 14, 57, 0)
    //};

    $http.get('http://eventticketapi.azurewebsites.net/events')
   .then(function (response) {
       $scope.evnts = angular.fromJson(response.data);
   }
   , function (response) {
       alert("Error in retrieving events information");
   });

    $scope.SaveEvent = function () {
           var eventdata = '[{\"eventname\":\"' + $scope.evnt.eventname
                    + '\",\"sessiondesc\":\"' + $scope.evnt.sessiondesc
                    + '\",\"startdate\":\"' + $scope.evnt.startdate
                    + '\",\"starttime\":\"' + $scope.evnt.starttime
                    + '\",\"duration\":' + $scope.evnt.duration
                    + '}]';
            $scope.evnts.push(
            {
                eventname: $scope.evnt.eventname,
                sessiondesc: $scope.evnt.sessiondesc,
                startdate: $scope.evnt.startdate,
                starttime: $scope.evnt.starttime,
                duration: $scope.evnt.duration
            });
       
        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }

        data = angular.toJson(eventdata);
        $http.post('http://eventticketapi.azurewebsites.net/events', data, config)
            .success(function (data, status, header, config) {
                alert("Event created successfully");
            })
            .error(function (data, status, header, config) {
                alert("Error in saving Event");
            });
    };
});