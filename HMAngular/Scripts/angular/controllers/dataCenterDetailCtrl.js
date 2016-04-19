hm.xivApp.controller('dataCenterDetailCtrl', ['$scope', '$filter', '$http', '$route', '$routeParams', 
    function ($scope, $filter, $http, $route, $routeParams)
    {
        $scope.model = [];

        //$scope.newCompany = function ()
        //{
        //    var url = NavigationUrls.NewCompany;
        //    window.location.href = url;
        //};

        //$scope.editCompany = function (company)
        //{
        //    var url = NavigationUrls.EditCompany.format(company.CompanyId);
        //    window.location.href = url;
        //};

        //$scope.viewUsers = function (company)
        //{
        //    var url = NavigationUrls.ViewUsers.format(company.CompanyId);
        //    window.location.href = url;
        //};

        var getData = function ()
        {
            $scope.spinner = { active: true };

            $http.get("/api/DataCenter/" + $routeParams.dataCenterId, {})
                .then(function success(resp)
                {
                    $scope.model.DataCenter = resp.data;
                    $scope.spinner = { active: false };
                }, function failure(resp)
                {
                    $scope.model.DataCenter = null;
                    $scope.spinner = { active: false };
                });
        };

        angular.element(document).ready(function ()
        {
            getData();
        });
    }
]);
