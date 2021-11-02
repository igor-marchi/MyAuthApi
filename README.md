# MyAuthAPI

# Comando para rodar o rabbit com docker

login
user/password: guest

<h1 align="center">
    MyAuthAPI
    <br>
    <br>
</h1>
<h4 align="center">
  API para gerenciamento de usuários e permissões
   <br>
   <br>
</h4>

<p align="center">
  <a href="#rocket-technologies">Technologies</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#information_source-how-to-use">How To Use</a>
   <br>
   <br>
</p>

<p align="center">
  <img alt="AppDemo" src="./GitHubAssets/demo.gif" />
</p>

## :rocket: Technologies

This project was developed with the following technologies:

- [.NET](https://dotnet.microsoft.com/) - Com c#
- [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Banco de dados relacional
- [RabbitMq](https://www.rabbitmq.com/) - Gerenciamento da comunicação de aplicações por filas (ex: envio de email ao criar usuário)
- [EntityFramework](https://docs.microsoft.com/pt-br/ef/) - ORM
- [FluentValidation](https://fluentvalidation.net/) - Validações dos inputs da API
- [AutoMapper](https://automapper.org/) - Mapeamento de entidades, modelos (ex: Entity -> DTOs -> Views)

## :information_source: How To Use

```bash
# Clone this repository
$ git clone https://github.com/igor-marchi/MyAuthApi.git MyAuthApi
# Run RabbitMq in docker on localhost:15672
$ docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management
# Go into Auth.WebApi repository
$ cd MyAuthApi/Auth.WebApi
# Run Web Api project
$ dotnet run
# Go into RabbitMqConsumer repository
$ cd ..
$ cd RabbitMqConsumer
# Run RabbitMqConsumer Api project
$ dotnet run
```
