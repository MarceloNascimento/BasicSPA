
var app = angular.module('app');
var baseUrl = 'app/views';
app.config(function ($routeProvider, $locationProvider) {
    // remove o # da url

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
    $routeProvider

        .when('/', {
            templateUrl: '../app/views/index.html',
            controllerAs: 'vm',
        })      
        .when('/404', {
            templateUrl: 'app/views/Error/404.html',   
            controllerAs: 'vm',
        })
        //otherwise, will redirect '/'
        .otherwise({ redirectTo: '/404' });

});
