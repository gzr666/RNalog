
(function () {

    angular.module("myApp")
    .controller("HomeController", function ($scope, $rootScope, $http, $filter, ngTableParams) {
        
       
        $scope.users = [];

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



    }).controller("AdminController", function ($scope, $rootScope, $http) {

        $scope.test2 = "Radi li";
        //$scope.zaposlenik = {};







    }).controller("CreateController", function ($scope, $rootScope, $http, zaposlenikService, toastr) {

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