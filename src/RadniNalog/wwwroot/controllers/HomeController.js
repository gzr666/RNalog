
(function () {

    angular.module("myApp")
    .controller("HomeController", function ($scope, $rootScope, $http, $filter, ngTableParams, toastr,$state, $stateParams,_,$timeout) {
        

      
       
        $scope.users = [];

        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.pNalozi = [{ id: 1, name: "DA" }, { id: 2, name: "NE" }];
        $scope.mjestaRada = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];
        $scope.rnalog = {};

        


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

        

      

       

        //izbrisi nalog
        $scope.removeNalog = function (user)
        {
            $http({
                method: 'DELETE',
                url: '/api/RNalog/' + user.id
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available

                //$timeout(function () {

                //    var index = $scope.users.indexOf(user);
                //    $scope.users.splice(index, 1);

                //}, 100);
                
               


             


                toastr.success('Uspjesno izbrisan Radni Nalog', '',
                    {
                        onHidden: function () { $state.go($state.current, {}, { reload: true }); }
                    });
               


            }, function errorCallback(response) {

                toastr.error('Doslo je do greske kod brisanja naloga', '',
                    {
                        onHidden: function () { $state.go("home"); }
                    });
                
            });


        }

        //uredinalog
        $scope.urediNalog = function (nalog)
        {



            if (nalog.Izvrsitelj3 == undefined) {
                nalog.Izvrsitelj3 = {};
                nalog.Izvrsitelj3.ime = "";
            }

            if (nalog.Izvrsitelj2 == undefined) {
                nalog.Izvrsitelj2 = {};
                nalog.Izvrsitelj2.ime = "";
            }

            var rnalog = {
                ID:$stateParams.id,
                OpisRadova: nalog.OpisRadova,
                Materijal: nalog.Materijal,
                Rukovoditelj: nalog.Rukovoditelj,
                Izvrsitelj2: nalog.Izvrsitelj2,
                Izvrsitelj3: nalog.Izvrsitelj3,
                PutniNalog: nalog.PutniNalog,
                AutomobilID: nalog.AutomobilID,
                MjestoRadaID: nalog.MjestoRadaID,
                VrstaRadaID: nalog.VrstaRadaID



            };

            $http({

                method: "PUT",
                url: "/api/RNalog/" + $stateParams.id,
                data: rnalog

            }).then(function (data) {

                toastr.success('Uspjesan Update Radnog Naloga', '',
                     {
                         onHidden: function () { $state.go("home"); }
                     });

            }, function (error) {

                console.log(error);
                toastr.error('Došlo je do greške...Pokušaj ponovo', '');
            });



        }

       

        

        //spremanje naloga
        $scope.saveNalog = function (nalog) {

         

            

            if (nalog.Izvrsitelj3 == undefined)
            {
                nalog.Izvrsitelj3 = {};
                nalog.Izvrsitelj3.ime = "";
            }

            if (nalog.Izvrsitelj2 == undefined) {
                nalog.Izvrsitelj2 = {};
                nalog.Izvrsitelj2.ime = "";
            }

            var rnalog = {
             
                OpisRadova: nalog.OpisRadova,
                Materijal: nalog.Materijal,
                Rukovoditelj: nalog.Rukovoditelj.ime,
                Izvrsitelj2: nalog.Izvrsitelj2.ime,
                Izvrsitelj3: nalog.Izvrsitelj3.ime,
                PutniNalog: nalog.PutniNalog.name,
                AutomobilID: nalog.AutomobilID.id,
                MjestoRadaID: nalog.MjestoRadaID.id,
                VrstaRadaID: nalog.VrstaRadaID.id



            };

            $http.post("/api/RNalog", rnalog).then(function (data) {

                toastr.success('Uspjesno kreiran Radni Nalog', '',
                     {
                         onHidden: function () { $state.go("home"); }
                     });

            }, function (error) {

                toastr.error('Došlo je do greške...Pokušaj ponovo', '');
            });


        }

        $http.get("api/nalozi").then((function (data2) {

            console.log(data2);

            var testArray = _.map(data2.data, function (num, key) {

                return {
                    id:num.id,
                    datum: num.datum,
                    rukovoditelj: num.rukovoditelj,
                    izvrsitelj2: num.izvrsitelj2,
                    izvrsitelj3: num.izvrsitelj3,
                    mjestoRada: num.mjestoRada.ime,
                    automobil: num.automobil.registracija,
                    opisRadova: num.opisRadova

                }


            });

            console.log(testArray);



            //angular.copy(data2.data, $scope.users);
            angular.copy(testArray, $scope.users);

        }), function (error) {


            console.log("error");
        }).then(function () {

            $scope.usersTable = new ngTableParams(
                                    {
                                        page: 1,
                                        count: 10
                                    },
                                     {
                                         total: $scope.users.length,
                                         getData: function ($defer, params) {
                                             $scope.data = params.sorting() ? $filter('orderBy')($scope.users, params.orderBy()) : $scope.users;
                                             $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                                             $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                             $defer.resolve($scope.data);
                                         }
                                     });



        });








    





    }).controller("chartController",function($scope){


        $scope.options = { 
            title: { display: true, text: 'Legend', position: 'bottom', padding: 5 },
            legend: { display: true,position:"bottom" } 
        };



            	

        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales",
        "TestSales1","TestSales2","TestSales2","TestSales2","TestSales2"];
        $scope.data = [300, 500, 100,400,1000,800,56,888];


        $scope.labels2 = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
        $scope.series2 = ['Series A', 'Series B'];

        $scope.data2 = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];



    })







    
    


}());