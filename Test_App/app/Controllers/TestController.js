app.controller('APIController', function ($scope, APIService) {
    getAll();

    function getAll() {
        var servCall = APIService.Get();
        servCall.then(function (d) {
            $scope.Directories = d.data;
            $scope.Kills = $scope.Directories.Counts;
        }, function (error) {
            $log.error('Помилка при отриманні даних!!!');
        })
    }
    
    $scope.Change = function (obj) {
        var sub = { value: $scope.Directories.Path + '\\' + obj };
        var Change = APIService.ChangeDirectory(sub);
        Change.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Помилка при спробі відкриття файлу!!!')
        })
    };
})
