hm.xivApp.run(['$route', function () { }]);

hm.xivApp.config([
            '$routeProvider',
            function ($routeProvider)
            {
                $routeProvider
                    .when('/', {
                        templateUrl: 'home.html',
                        controller: 'homeCtrl',
                        controllerAs: 'ctrl'
                    })
                    .when('/DataCenters', {
                        templateUrl: 'dataCenterList.html',
                        controller: 'dataCenterListCtrl',
                        controllerAs: 'ctrl'
                    })
                    .when('/DataCenters/:dataCenterId', {
                        templateUrl: 'dataCenterDetail.html',
                        controller: 'dataCenterDetailCtrl',
                        controllerAs: 'ctrl'
                    })
                    .otherwise({
                        redirectTo: '/'
                    });
            }
]);
