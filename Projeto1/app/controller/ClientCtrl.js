(function () {
    'use strict';

    angular.module('app').controller('ClientCtrl', ['$scope', '$injector', '$timeout', 'loadAnimeService', 'messageService', '$location', 'clientService',
        function ($scope, $injector, $timeout, loadAnimeService, messageService, $location, clientService) {

            var vm = this;

            function startVm() {

                //bag from Services which wil be bringing a list of objects from db
                vm.bagClient = [];
                vm.user = {};
                vm.loadGrid = loadGrid;
                vm.goCadastro = goCadastro;
                vm.goConsulta = goConsulta;               
            }

            startVm();

            function getVm() {
                return vm;
            }


            function loadGrid() {               
                loadAnimeService.show();
                vm.bagClient = [];                
                clientService.listAll(function (resp) {
                    if (resp !== null) {
                        console.info(resp);
                        vm.bagClient = resp.data; 
                        vm.tela = 'Consulta';
                        loadAnimeService.close();
                    }
                });

                vm.bagTipos = ['Física','Jurídica'];
            }

            function goCadastro() {
                loadAnimeService.show();
                vm.tela = 'Cadastro';
                vm.user = [];
                loadAnimeService.close();
            }

            function goConsulta() {
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

            vm.loadGrid();

        }]);
})();