
//app.directive("compareTo", compareTo);

app.controller('SignupCtrl', function ($scope, $http, $location) {
    $scope.users = [];

    $http.get('http://eventticketapi.azurewebsites.net/customers')
   .then(function (response) {
       $scope.users = angular.fromJson(response.data);
   }
   , function (response) {
       alert("Error in retrieving events information");
   });

    validate = function () {
        if ($scope.user.password1 != $scope.password2) {
            alert('Confirm password must match');
            return false;
        }

        var i;
        for (i = 0; i < $scope.users.length; i++) {
            if ($scope.users[i].userid === $scope.user.userid) {
                    alert('User Id with this email already exists');
                    return false;
             }
        }

        return true;
    };

    $scope.SignUp = function () {

        if (!validate())
            return false;

        var userdata = '[{\"userid\":\"' + $scope.user.userid
                    + '\",\"password\":\"' + $scope.user.password1
                    + '\",\"firstname\":\"' + $scope.user.firstname
                    + '\",\"lastname\":\"' + $scope.user.lastname
                    + '\",\"email\":\"' + $scope.user.email
                    + '\",\"phone\":\"' + $scope.user.phone
                    + '\"}]';

        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }
        data = angular.toJson(userdata);
        $http.post('http://eventticketapi.azurewebsites.net/customers', data, config)
            .success(function (data, status, header, config) {
                alert("Registration successfull");
                $location.path('/home');
                $scope.$apply();
            })
            .error(function (data, status, header, config) {
                alert("Error in creating user");
        });
     };
});