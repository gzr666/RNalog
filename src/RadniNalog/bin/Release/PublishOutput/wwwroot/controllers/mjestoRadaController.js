(function () {

    angular.module("appAdmin")
    .controller("mjestoRadaController", function ($scope, $rootScope, $http, $filter, ngTableParams, mjestoRadaService, toastr, $state) {
        
       


       
        $scope.users = [];

        $http.get("/api/MjestoRada").then((function (data2) {

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


        $scope.removeMjestoRada = function (user) {

            mjestoRadaService.deleteMjestoRada(user.id).then(function (data) {

                toastr.success('Uspjesno izbrisano Mjesto Rada', '',{
                    onHidden: function () { $state.go("admin"); }
                });
              
                
                

               
               


            }, function (error) {

                toastr.error('Došlo je do pogreške...', '');
            });

           



        }


    });

}());