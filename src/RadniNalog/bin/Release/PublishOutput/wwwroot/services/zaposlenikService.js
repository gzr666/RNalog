(function () {

    angular.module("appAdmin").factory("zaposlenikService", function ($http, $q) {


        var saveZaposlenik = function (zaposlenik) {

            var q = $q.defer();

            $http.post("/api/zaposlenici", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteZaposlenik = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/zaposlenici/' + id
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available

                q.resolve(response.data);
              

            }, function errorCallback(response) {

                q.reject(response);
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });


            return q.promise;

        }

        var updateZaposlenik = function (zaposlenik)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/zaposlenici/' + zaposlenik.id,
                data:zaposlenik
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available

                q.resolve(response.data);


            }, function errorCallback(response) {

                q.reject(response);
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });


            return q.promise;



        }

        var getZaposlenik = function (id)
        {
            var q = $q.defer();
            var url = "/api/zaposlenici/" + id;
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;


        }



        


        //var getData = function (id) {
        //    var q = $q.defer();

        //    $http.get("data/apartman" + id + ".json").then(
        //        function (data) {


        //            q.resolve(data.data);

        //        },
        //    function (error) {

        //        q.reject(error);
        //    });

        //    return q.promise;
        //}

        //var getApartmani = function () {
        //    var q = $q.defer();

        //    $http.get("data/apartmani.json").then(
        //        function (data) {


        //            q.resolve(data.data);

        //        },
        //    function (error) {

        //        q.reject(error);
        //    });

        //    return q.promise;


        //}

        //var getBooking = function (id) {
        //    var q = $q.defer();

        //    $http.get("http://nodesinj-gzr.rhcloud.com/apartman?apartmanID=" + id).then(
        //        function (data) {


        //            q.resolve(data.data);

        //        },
        //    function (error) {

        //        q.reject(error);
        //    });

        //    return q.promise;
        //}

        //var postBook = function (booking) {

        //    var q = $q.defer();

        //    $http.post("http://nodesinj-gzr.rhcloud.com/apartman", booking).then(
        //        function (data) {


        //            q.resolve(data.data);

        //        },
        //    function (error) {

        //        q.reject(error);
        //    });

        //    return q.promise;


        //}

        //var deleteBooking = function (id) {

        //    var q = $q.defer();

        //    $http.delete("http://nodesinj-gzr.rhcloud.com/apartman/" + id).then(
        //        function (data) {


        //            q.resolve(data.data);

        //        },
        //    function (error) {

        //        q.reject(error);
        //    });

        //    return q.promise;


        //}





        return {

            postZaposlenik: saveZaposlenik,
            deleteZaposlenik: deleteZaposlenik,
            editZaposlenik: updateZaposlenik,
            dohvatiZaposlenika:getZaposlenik

        }


    });


}());