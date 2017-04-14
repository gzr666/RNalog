(function () {

    angular.module("appAdmin").factory("vrstaRadaService", function ($http, $q) {


        var saveVrstaRada = function (zaposlenik) {

            var q = $q.defer();

            $http.post("/api/VrstaRada", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteVrstaRada = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/VrstaRada/' + id
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

        var updateVrstaRada = function (zaposlenik)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/VrstaRada/' + zaposlenik.id,
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

        var getVrstaRada = function (id)
        {
            var q = $q.defer();
            var url = "/api/VrstaRada/" + id;
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

            postVrstaRada: saveVrstaRada,
            deleteVrstaRada: deleteVrstaRada,
            editVrstaRada: updateVrstaRada,
            dohvatiVrstaRada:getVrstaRada

        }


    });


}());