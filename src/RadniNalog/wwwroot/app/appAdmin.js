/// <reference path="../lib/angular/angular.js" />


var myApp = angular.module("appAdmin", ["ui.router", "toastr", 'ngTable', 'chart.js']);

myApp.config(function ($stateProvider, $urlRouterProvider) {



    $urlRouterProvider.otherwise("/admin");

    $stateProvider.state("admin", {

        url: "/admin",
        templateUrl: "../templates/admin.html",
        controller: "AdminController"

    });

    $stateProvider.state("createZaposlenik", {

        url: "/kreirajZaposlenika",
        templateUrl: "../templates/createZaposlenik.html",
        controller: "CreateController"

    });
    $stateProvider.state("editZaposlenik", {

        url: "/editZaposlenika/:id",
        templateUrl: "../templates/editZaposlenik.html",
        controller: "CreateController"

    });

    $stateProvider.state("statistika", {

        url: "/statistika",
        templateUrl: "../templates/statistika.html",
        controller: "chartController2"

    });

    $stateProvider.state("radnici", {

        url: "/radnici",
        templateUrl: "../templates/zaposlenici.html",
        controller: "radniciController"

    });

    $stateProvider.state("vrstaRada", {

        url: "/vrstaRada",
        templateUrl: "../templates/vrstaRada.html",
        controller: "vrstaRadaController"

    });

    $stateProvider.state("createVrstaRada", {

        url: "/kreirajVrstuRada",
        templateUrl: "../templates/createVrstaRada.html",
        controller: "CreateVrstaRadaController"

    });
    $stateProvider.state("editVrstaRada", {

        url: "/editVrstaRada/:id",
        templateUrl: "../templates/editVrstaRada.html",
        controller: "CreateVrstaRadaController"

    });

    $stateProvider.state("mjestoRada", {

        url: "/mjestoRada",
        templateUrl: "../templates/mjestoRada.html",
        controller: "mjestoRadaController"

    });

    $stateProvider.state("createmjestoRada", {

        url: "/kreirajMjestoRada",
        templateUrl: "../templates/createMjestoRada.html",
        controller: "CreateMjestoRadaController"

    });
    $stateProvider.state("editMjestoRada", {

        url: "/editMjestoRada/:id",
        templateUrl: "../templates/editMjestoRada.html",
        controller: "CreateMjestoRadaController"

    });


    $stateProvider.state("automobil", {

        url: "/automobil",
        templateUrl: "../templates/automobil.html",
        controller: "automobilController"

    });

    $stateProvider.state("createAutomobil", {

        url: "/kreirajAutomobil",
        templateUrl: "../templates/createAutomobil.html",
        controller: "CreateAutomobilController"

    });
    $stateProvider.state("editAutomobil", {

        url: "/editAutomobil/:id",
        templateUrl: "../templates/editAutomobil.html",
        controller: "CreateAutomobilController"

    });






});