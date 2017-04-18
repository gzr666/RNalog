/// <reference path="../lib/angular/angular.js" />


var myApp = angular.module("myApp", ["ui.router", 'ngTable', 'chart.js', "toastr", "720kb.datepicker"]);

myApp.config(function ($stateProvider, $urlRouterProvider) {



    $urlRouterProvider.otherwise("/home");

    $stateProvider.state("home", {

        url: "/home",
        templateUrl: "../Home/home",
        controller: "HomeController"

    });

    $stateProvider.state("createNalog", {

        url: "/kreirajNalog",
        templateUrl: "../templates/createNalog.html",
        controller: "HomeController"

    });
    $stateProvider.state("statistika", {

        url: "/statistika",
        templateUrl: "../templates/statistika.html",
        controller: "chartController"

    });

   

    







});