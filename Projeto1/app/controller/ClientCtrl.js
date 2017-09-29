(function () {
    'use strict';

    app.controller('ClientCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'clientService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, clientService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagClient = [];
                vm.user = {};
                vm.loadGrid = loadGrid;
                vm.goCadastro = goCadastro;
                vm.goConsulta = goConsulta;  
                vm.tela = 'Consulta';
            }

           

            function getVm() {
                return vm;
            }


            function loadGrid() {               
                loadAnimeService.show();                 
                clientService.listAll(function (resp) {
                    //if (resp !== null) {          
                    console.info(resp);
                        vm.bagClient = resp.data;                         
                    //}
                        
                });
                
            }

            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = [];
                vm.bagTipos = ['Física', 'Jurídica'];
                loadAnimeService.close();
            }

            function goConsulta() {
                vm.bagClient = null;   
                vm.bagClient = [];   
                loadAnimeService.show();
                vm.loadGrid();   
                vm.tela = 'Consulta';
                loadAnimeService.close();
            }


            vm.goDeletar = function (codigo) {
                loadAnimeService.show();                
                clientService.delete(codigo, function (resp) {
                    if (resp !== null) {                          
                        vm.goConsulta();  
                        messageService.success("Operação realizada com sucesso!");
                    }
                });
            }


            vm.goEditar = function (obj) {
                loadAnimeService.show();
                vm.tela = 'Cadastro';               
                vm.user = obj;
                loadAnimeService.close();                
            }

            vm.goSaveOrUpdate = function () {
                loadAnimeService.show();
                clientService.goSaveOrUpdate(vm.user, function (resp) {                    
                    if (resp !== null) {                       
                        vm.loadGrid();
                        messageService.success("Operação realizada com sucesso!");                       
                        loadAnimeService.close();
                    }
                });

            }

            startVm();
            vm.loadGrid();

        }]);
})();