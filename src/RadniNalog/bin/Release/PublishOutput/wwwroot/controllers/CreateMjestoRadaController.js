
(function () {

    angular.module("appAdmin")
    .controller("CreateMjestoRadaController", function ($scope, $rootScope, $http, mjestoRadaService, toastr, $state, $stateParams) {
        


      
        mjestoRadaService.dohvatiMjestoRada($stateParams.id).then(function (data) {

            $scope.mjestoRada = data;

        }, function (error) {



        });



        

        $scope.saveMjestoRada = function (mjestoRada) {
            

           
            mjestoRadaService.postMjestoRada(mjestoRada).then(function (data) {

                toastr.success('Uspjesno kreirano Mjesto Rada', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editMjestoRada = function (mjestoRada) {

            
           



            mjestoRadaService.editMjestoRada(mjestoRada).then(function (data) {

                toastr.success('Uspjesno izmijenjeno mjesto rada', '',
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