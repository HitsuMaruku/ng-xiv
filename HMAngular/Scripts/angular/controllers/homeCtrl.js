hm.xivApp.controller('homeCtrl', ['$scope', '$filter', '$http', '$route', 
    function ($scope, $filter, $http, $route)
    {
        $scope.model = [];

        var getData = function ()
        {
            ////TODO: Show loading screen
            //$http.get("/api/DataCenter", {})
            //    .then(function success(resp)
            //    {
            //        $scope.model.DataCenters = resp.data;
            //        //TODO: Hide loading screen
            //    }, function failure(resp)
            //    {
            //        $scope.model.DataCenters = null;
            //        //TODO: Hide loading screen
            //    });
        };

        angular.element(document).ready(function ()
        {
            getData();
        });
    }
]);
