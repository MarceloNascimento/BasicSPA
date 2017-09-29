/* Request $http RestFull GET PUT DELETE UPDATE*/
(function () {
    'use strict';

    // Request service
    app.service('clientService', ['$http', 'messageService',
        'locationhostService',
        function ($http, messageService, locationhostService) {
            this.dto = {};


            this.apiBase = locationhostService.apiBase + 'api/client';;

            //var _get = $http.get(this.apiBase, {
            //    'content-type': 'application/json',
            //    'crossDomain': true, 'async': true,               
            //    'cache-control': 'no-cache'
            //}, { cache: false });


            var _get = $http({
                method: 'GET',
                url: this.apiBase,
                headers: {
                    'content-type': 'application/json', 'Access-Control-Allow-Origin': '*',
                    'Cache-Control': 'no-cache'
                }, cache: false
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

            this.update = function (data, fn) {

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
                _get.then(fn,function (response) {
                   
                    console.log(response);
                    return response.data;
                    fn();
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

        }]);

})();