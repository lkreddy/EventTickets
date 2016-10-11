
app.controller('LoginCtrl', function ($scope, $http, $location) {
    $scope.google_login = function () {
        var client_id = "506903963651-fk1bg0fntovfbgonf97suct1g17j3tol.apps.googleusercontent.com";
        var scope="email";
        var redirect_uri = "http://callbackclient.azurewebsites.net";
        var response_type="token";
        var url="https://accounts.google.com/o/oauth2/auth?scope="+scope+"&client_id="+client_id+
        "&response_type=" + response_type + "&redirect_uri=" + redirect_uri;
        window.location.replace(url);
    };

    $scope.SignIn = function () {
        var users = [];
        var url = 'http://eventticketapi.azurewebsites.net/customers/' + $scope.user.id;
        $http.get(url)
            .then(function (response) {
                users = angular.fromJson(response.data);
                if (users.length > 0) {                   
                    if ($scope.user.password == users[0].password) {
                        //$rootspace.loginid = $scope.user.id;
                        $location.path('/home');
                        $scope.$apply();
                    }
                    else
                        alert('Incorrect Password');
                }
                else
                    alert('Please signup to continue');
            }
            , function (response) {
                alert("Error in retrieving users information ");
        });
              
    };

    //function onSuccess(googleUser) {
    //    console.log('Signed in as: ' + googleUser.getBasicProfile().getName());
    //}

    //function onSignIn(googleUser) {
    //    var profile = googleUser.getBasicProfile();
    //    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    //    console.log('Name: ' + profile.getName());
    //    console.log('Image URL: ' + profile.getImageUrl());
    //    console.log('Email: ' + profile.getEmail());
    //}

    //function signOut() {
    //    var auth2 = gapi.auth2.getAuthInstance();
    //    auth2.signOut().then(function () {
    //        console.log('User signed out.');
    //    });

});
