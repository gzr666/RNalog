
(function () {

    angular.module("appAdmin")
    .controller("CreateController", function ($scope, $rootScope, $http, zaposlenikService, toastr, $state, $stateParams) {
        


      
        zaposlenikService.dohvatiZaposlenika($stateParams.id).then(function (data) {

            $scope.zaposlenik = data;

        }, function (error) {



        });



        $scope.test2 = "create";
        $scope.zaposlenik = {};

        $scope.saveZaposlenik = function (zaposlenik) {
            var postZaposlenik = {
                "Ime": zaposlenik.ime

            }

           
            zaposlenikService.postZaposlenik(postZaposlenik).then(function (data) {

                toastr.success('Uspjesno kreiran zaposlenik', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editZaposlenik = function (zaposlenik) {

            var postZaposlenik = {

                "Ime": zaposlenik.ime

            }

           



            zaposlenikService.editZaposlenik(zaposlenik).then(function (data) {

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