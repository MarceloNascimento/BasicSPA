/* Request $http RestFull GET PUT DELETE UPDATE*/
(function () {
    'use strict';

    // Request service
    angular.module('app').service('clientService', ['$http', '$location', 'messageService',
        'locationhostService',
        function ($http, $location, messageService, locationhostService) {
            this.dto = {};


            this.apiBase = locationhostService.apiBase + 'api/client';;

            var _get = $http.get(this.apiBase, {
                'content-type': 'application/json', 'async': true,
                'crossDomain': true, 
                'Access-Control-Allow-Origin': '*',
                'cache-control': 'no-cache'
            });

            //To save or update some dto passede by front-end
            this.goSaveOrUpdate = function (dto, fn) {
                var data = {
                    Codigo: dto.codigo,
                    Nome: dto.nome,
                    CPF: dto.CPF, CNPJ: dto.CNPJ,
                    telefone: dto.telefone,
                    Tipo: dto.tipo
                };
                if (dto !== null && angular.isNumber(dto.codigo) && dto.codigo > 0) {
                   return this.update(data, fn);
                } else {
                    return this.save(data, fn);
                }
            }

            //method to save access request form
            this.save = function (data, fn) {
                
                $http.post(this.apiBase + '/POST', data, {
                    'content-type': 'application/json', 'async': true,
                    'crossDomain': true,
                    'cache-control': 'no-cache'
                }).then(fn, function (resp) {                   
                    return resp;

                }, function (error) {
                    return messageService.danger(error);
                });

            };

            this.update = function (data,fn) {
               
                $http.put(this.apiBase + '/PUT', data, {
                    'content-type': 'application/json', 'async': true,
                    'crossDomain': true,
                    'cache-control': 'no-cache'
                }).then(fn, function (resp) {                   
                    return resp;

                }, function (error) {
                    return messageService.danger(error);
                });
            };
            

            this.listAll = function (fn) {
                _get.then(fn, function (resp) {
                    //fn();
                    console.log(resp);
                    return resp.data;

                }, function (error) {
                    messageService.danger(error);
                });
            };
            

            this.GetById = function (Id, fn) {
                $http.get(this.apiBase + '?Id=' + Id).then(fn, function (resp) {
                    fn();
                    return resp.data;
                }, function (error) {
                    messageService.danger(error);
                });
            };

          

            this.delete = function (codigo, fn) {                
                $http.delete(this.apiBase + '?id=' + codigo, {
                    'content-type': 'application/json', 'async': true,
                    'crossDomain': true,
                    'cache-control': 'no-cache'
                }).then(fn, function (resp) {  
                    console.log(resp);
                    return resp;

                }, function (error) {
                    return messageService.danger(error);
                });
            };

        }])

})();