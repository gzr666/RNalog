
(function () {

    angular.module("myApp")
    .controller("HomeController", function ($scope, $rootScope, $http, $filter, ngTableParams) {
        
       
        $scope.users = [];

        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.pNalozi = [{ id: 1, name: "DA" }, { id: 2, name: "NE" }];
        $scope.mjestaRada = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];


        //dohvati zaposlenike
        $http.get("/api/zaposlenici").success(function (data) {


            
            angular.copy(data, $scope.rukovoditelji);
            angular.copy(data, $scope.izvrsitelji1);
            angular.copy(data, $scope.izvrsitelji2);
        });

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


        $scope.saveNalog = function (nalog)
        {

            console.log(nalog);
            console.log(nalog.Rukovoditelj.id + nalog.Rukovoditelj.ime);
        }

        $http.get("app/data.json").then((function (data2) {

            console.log(data2);

            angular.copy(data2.data, $scope.users);

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