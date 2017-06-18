
(function () {

    angular.module("myApp")
    .controller("chartController", function ($scope) {


        $scope.options = {
            title: { display: true, text: 'Test', position: 'bottom', padding: 5 },
            legend: { display: true, position: "bottom" }
        };





        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales",
        "TestSales1", "TestSales2", "TestSales2", "TestSales2", "TestSales2"];
        $scope.data = [300, 500, 100, 400, 1000, 800, 56, 888];


        $scope.labels2 = ['2034', '2007', '2008', '2009', '2010', '2011', '2012'];
        $scope.series2 = ['Series A', 'Series B'];

        $scope.data2 = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];



    });


}());