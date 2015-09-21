(function () {
    var controllerId = 'app.views.users.index';
    angular.module('app').controller(controllerId, [
        'abp.services.app.user', 
        function (userService) {
            var vm = this;

            vm.users = [];

            abp.ui.setBusy(
                null,
                userService.getUsers().success(function(data) {
                    vm.users = data.items;
                })
            );
        }
    ]);
})();

(function() {
    var controllerId = 'app.views.users';
    angular.module('app').controller(controllerId, [
        'abp.service.app.user',
        function(userService) {
            var vm = this;
            vm.users = [];

            vm.createUser= function(userName,name,surnName,emailAddress,password) {
                userService.createUser(userName, name, surnName, emailAddress, password).success(function(data) {
                    alert("创建完成" + data);
                });
            }
            //初始化
            abp.ui.setBusy(
                null,
                userService.getUsers().success(function(data) {
                    vm.users = data.items;
                }));


        }
    ]);
})();