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

    $urlRouterProvider.otherwise("/admin");

    $stateProvider.state("admin", {

        url: "/admin",
        templateUrl: "../templates/admin.html",
        controller: "AdminController"

    });

    $stateProvider.state("create", {

        url: "/kreirajZaposlenika",
        templateUrl: "../templates/createZaposlenik.html",
        controller: "CreateController"

    });







});