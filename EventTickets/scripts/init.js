var app = angular.module('MyApp', ['ui.router', 'toastr', 'ngMessages', 'ngResource', 'ngAnimate', 'satellizer']);

app.config(function ($stateProvider, $urlRouterProvider, $authProvider, $locationProvider) {
    $stateProvider
        .state('home', {
            url: '/home',
            controller: 'HomeCtrl',
            templateUrl: 'partials/home.html'
        })
         .state('login', {
             url: '/login',
             controller: 'LoginCtrl',
             templateUrl: 'partials/login.html'
         })
        .state('signup', {
            url: '/signup',
            controller: 'SignupCtrl',
            templateUrl: 'partials/signup.html'
        })

        .state('/events', {
            url: '/events',
            controller: 'EventsCtrl',
            templateUrl: 'partials/events.html'
        })
        .state('/tickets', {
            url: '/tickets',
            controller: 'TicketsCtrl',
            templateUrl: 'partials/tickets.html'
        })
        .state('/purchase', {
            url: '/purchase',
            controller: 'PurchaseCtrl',
            templateUrl: 'partials/purchase.html'
        });

    $urlRouterProvider.otherwise('/login');

    //.when('/access_token=:accessToken', {
    //     template: '',
    //     controller: function ($location, $rootScope) {
    //         var hash = $location.path().substr(1);

    //         var splitted = hash.split('&');
    //         var params = {};

    //         for (var i = 0; i < splitted.length; i++) {
    //             var param = splitted[i].split('=');
    //             var key = param[0];
    //             var value = param[1];
    //             params[key] = value;
    //             $rootScope.loginid = value;
    //         }
    //         $location.path("/home");
    //     }
    // });

    //$locationProvider.html5Mode(true);
    ;
});