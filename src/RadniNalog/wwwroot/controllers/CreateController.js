
(function () {

    angular.module("appAdmin")
    .controller("CreateController", function ($scope, $rootScope, $http, zaposlenikService, toastr) {
        
        $scope.test2 = "create";


        $scope.saveZaposlenik = function (zaposlenik) {
            var postZaposlenik = {
                "Ime": zaposlenik.ime

            }

           
            zaposlenikService.postZaposlenik(postZaposlenik).then(function (data) {

                toastr.success('Uspjesno kreiran zaposlenik', '');

            }, function (error) {



            })

        };





    });


}());