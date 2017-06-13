
(function () {

    angular.module("myApp")
    .controller("EditNalogController", function ($scope, $rootScope, $http, $filter, ngTableParams, toastr,$state, $stateParams,_) {
        

      
       
        $scope.users = [];

        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.pNalozi = [{ id: 1, name: "DA" }, { id: 2, name: "NE" }];
        $scope.mjestaRada = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];
        $scope.rnalog = {};
        $scope.spremnik = {};



        //dohvati mjesta rada
        $http.get("/api/MjestoRada").success(function (data) {

            angular.copy(data, $scope.mjestaRada);



        });

        //dohvati vrste rada
        $http.get("/api/VrstaRada").success(function (data) {

            angular.copy(data, $scope.vrsteRada);

        });

        //dohvati automobile
        $http.get("/api/Automobil").success(function (data) {

            angular.copy(data, $scope.automobili);

        });



        //dohvati zaposlenike
        $http.get("/api/zaposlenici").success(function (data) {



            angular.copy(data, $scope.rukovoditelji);
            angular.copy(data, $scope.izvrsitelji1);
            angular.copy(data, $scope.izvrsitelji2);
        });

        
        $http.get("/api/RNalog/" + $stateParams.id).then(function (data) {

            angular.copy(data.data, $scope.rnalog);
            $scope.pNalozi
            
            $scope.spremnik.rukovoditelj = _.where($scope.rukovoditelji, { ime: data.data.rukovoditelj })[0];
            $scope.spremnik.izvrsitelj1 = _.where($scope.izvrsitelji1, { ime: data.data.izvrsitelj2 })[0];
            $scope.spremnik.izvrsitelj2 = _.where($scope.izvrsitelji2, { ime: data.data.izvrsitelj3 })[0];
            $scope.spremnik.nalog = _.where($scope.pNalozi, { name: data.data.putniNalog })[0];
            $scope.spremnik.mjestoRada = _.where($scope.mjestaRada, { id: data.data.mjestoRadaID })[0];
            $scope.spremnik.vrstaRada = _.where($scope.vrsteRada, { id: data.data.vrstaRadaID })[0];
            $scope.spremnik.automobil = _.where($scope.automobili, { id: data.data.automobilID })[0];
            $scope.spremnik.opisRadova = data.data.opisRadova;
            $scope.spremnik.materijal = data.data.materijal;
          

            



        }, function () {



        });

        $scope.defRuk1 = function ()
        {
            $scope.isRuk1 = false;


        }
        $scope.defRuk2 = function () {
            $scope.isRuk2 = false;


        }
        $scope.defRuk3 = function () {
            $scope.isRuk3 = false;


        }
        $scope.defRuk4 = function () {
            $scope.isRuk4 = false;


        }
        $scope.defRuk5 = function () {
            $scope.isRuk5 = false;


        }
        $scope.defRuk6 = function () {
            $scope.isRuk6 = false;


        }
        




       

        


        //uredinalog
        $scope.urediNalog = function (spremnik)
        {



            if (spremnik.Izvrsitelj3 == undefined) {
                spremnik.Izvrsitelj3 = {};
                spremnik.Izvrsitelj3.ime = "";
            }

            if (spremnik.Izvrsitelj2 == undefined) {
                spremnik.Izvrsitelj2 = {};
                spremnik.Izvrsitelj2.ime = "";
            }

            var rnalog = {
                ID:$stateParams.id,
                OpisRadova: spremnik.opisRadova,
                Materijal: spremnik.materijal,
                Rukovoditelj: spremnik.rukovoditelj.ime,
                Izvrsitelj2: spremnik.izvrsitelj1.ime,
                Izvrsitelj3: spremnik.izvrsitelj2.ime,
                PutniNalog: spremnik.nalog.name,
                AutomobilID: spremnik.automobil.id,
                MjestoRadaID: spremnik.mjestoRada.id,
                VrstaRadaID: spremnik.vrstaRada.id



            };

            $http({

                method: "PUT",
                url: "/api/RNalog/" + $stateParams.id,
                data: rnalog

            }).then(function (data) {

                toastr.success('Uspjesan Update Radnog Naloga', '',
                     {
                         onHidden: function () { $state.go($state.home, {}, { reload: true }); }
                     });

            }, function (error) {

                console.log(error);
                toastr.error('Došlo je do greške...Pokušaj ponovo', '');
            });



        }

       

        

       

        


    })




    





    







    
    


}());