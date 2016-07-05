app.service("APIService", function ($http) {
    this.Get = function () {
        return $http.get("api/values");
    }
    this.ChangeDirectory= function (sub) {
        return $http(
        {
            method: 'Post',
            url: 'api/Values',
            data:sub
        
        });
    }
});