/// <reference path="../lib/angular/angular.js" />


var myApp = angular.module("myApp", ["ui.router", 'ngTable', 'chart.js', "toastr"]);

myApp.config(function ($stateProvider, $urlRouterProvider) {



    $urlRouterProvider.otherwise("/home");

    $stateProvider.state("home", {

        url: "/home",
        templateUrl: "../templates/home.html",
        controller: "HomeController"

    });
    $stateProvider.state("statistika", {

        url: "/statistika",
        templateUrl: "../templates/statistika.html",
        controller: "chartController"

    });

   

    







});