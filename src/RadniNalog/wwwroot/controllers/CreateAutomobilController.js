
(function () {

    angular.module("appAdmin")
    .controller("CreateAutomobilController", function ($scope, $rootScope, $http, automobilService, toastr, $state, $stateParams) {
        


      
        automobilService.dohvatiAutomobil($stateParams.id).then(function (data) {

            $scope.automobil = data;

        }, function (error) {



        });



        

        $scope.saveAutomobil = function (automobil) {
            

           
            automobilService.postAutomobil(automobil).then(function (data) {

                toastr.success('Uspjesno kreiran Automobil', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editAutomobil = function (automobil) {

            
           



            automobilService.editAutomobil(automobil).then(function (data) {

                toastr.success('Uspjesno izmijenjen automobil', '',
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