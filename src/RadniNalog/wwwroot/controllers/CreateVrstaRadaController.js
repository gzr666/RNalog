
(function () {

    angular.module("appAdmin")
    .controller("CreateVrstaRadaController", function ($scope, $rootScope, $http, vrstaRadaService, toastr, $state, $stateParams) {
        


      
        //vrstaRadaService.dohvatiVrstaRada($stateParams.id).then(function (data) {

        //    $scope.zaposlenik = data;

        //}, function (error) {



        //});



        $scope.test2 = "create";
        $scope.zaposlenik = {};

        $scope.saveVrstaRada = function (vrstaRada) {
            

           
            vrstaRadaService.postVrstaRada(vrstaRada).then(function (data) {

                toastr.success('Uspjesno kreiran zaposlenik', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editVrstaRada = function (zaposlenik) {

            var postZaposlenik = {

                "Ime": zaposlenik.ime

            }

           



            vrstaRadaService.editVrstaRada(zaposlenik).then(function (data) {

                toastr.success('Uspjesno izmijenjen zaposlenik', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });


            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })


                

        }





    });


}());