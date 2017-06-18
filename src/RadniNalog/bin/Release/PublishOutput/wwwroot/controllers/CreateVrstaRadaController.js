
(function () {

    angular.module("appAdmin")
    .controller("CreateVrstaRadaController", function ($scope, $rootScope, $http, vrstaRadaService, toastr, $state, $stateParams) {
        


      
        vrstaRadaService.dohvatiVrstaRada($stateParams.id).then(function (data) {

            $scope.vrstaRada = data;

        }, function (error) {



        });



        $scope.test2 = "create";
        $scope.zaposlenik = {};

        $scope.saveVrstaRada = function (vrstaRada) {
            

           
            vrstaRadaService.postVrstaRada(vrstaRada).then(function (data) {

                toastr.success('Uspjesno kreirana Vrsta Rada', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editVrstaRada = function (vrstaRada) {

            
           



            vrstaRadaService.editVrstaRada(vrstaRada).then(function (data) {

                toastr.success('Uspjesno izmijenjena vrsta rada', '',
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