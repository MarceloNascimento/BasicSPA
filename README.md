# Client-SPA  V1.0
.NET test application

Software de avaliação 
 - Para implementação do mesmo é recomendável utilizar o SQL server versão 2016, 
 com o mesmo executar os scripts de instalação database_script.sql localizado na raiz do projeto.
 - Após verificar se foi criado corretamente o banco ClientDB, Table Client, e criar usuários do banco se achar necessário.
 - Próximo passo atualizar os arquivos app.config(do tests e Infra)  e o arquivo Web.config(do APIServices) com os dados da connection string.
  -Feito isto com visual studio você poderá executar a aplicação clicando em executar 
  ou realizando o publicar no ISS da cloud ou servidor onpremisse de sua preferência.
  
  Observação:
  - Caso utilize a publicação deste projeto recomendo ter dois webSite criados no IIS um com webAPi e o outros para com Projeto1.
  - Existe um arquivo que faz o apontamento para a porta do webAPI(APIServices) em execução no diretório    app/common/globals/locationhostService.js, é fundamental que este seja configurado para http://"Servidor do Serviço":"porta em execução"
  Exemplo: http://192.168.0.1:9000 caso o IIS responda nesta porta, para conectar ao IIS.


- Duvidas sobre implementação gentileza enviar email para marcelo.analistadesistemas@gmail.com

@All directy reserved by Marcelo do Nascimento 

