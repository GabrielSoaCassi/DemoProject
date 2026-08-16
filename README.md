# Project Demo

Projeto feito para estudo do curso do Macoratti [Clean Architecture Essencial - ASP .NET Core com C#](https://www.udemy.com/course/clean-architecture-essencial-asp-net-core-com-c/?couponCode=26BBPAA2MX) onde implementamos fundamentos de Clean Architecture usando .NET .


# Estrutura do projeto
O projeto segue o padrão proposto no curso que é implementar uma **Arquitetura em Camadas** deixando o menor nível possível de acoplamento entre as camadas. Sendo escolhido o seguinte padrão :
	- Domain 
	- Data
	- Application
	- IoC
	- WebUI/API  
| Camada | Dependências |
|--|--|
| Domain |—|
| Data | Domain |
|Application|Domain|
|IoC|Domain,Data,Application|
|WebUI/API|IoC|

é importante deixar claro que foi a escolha do curso em projetos novos, que realizei, notei que eu preferi importar a dependência de **Data** para **Application**, pois não criei interfaces para a **Repository** sendo algo que foi puramente escolha minha, mas que impede de trocar as implementações de **Repository**. 

## Domínio

Optamos pela modelagem de **dominio rico**, para manter as **regras de negócio** totalmente nas entidades, e assim ter os testes funcionando de forma simples.
**Exceções de domínio** é o próprio modelo que fica responsável.

## Data

Camada responsável por dados, seja consumindo de API externas ou realizando acesso ao banco

## Application

Implementação concreta  de validações, de **input / output**, controle de acesso as **repositories**, implementação de padrões arquiteturais como **CQRS**,**Mediator**, criação de DTO's.
no curso foi abordado dessa forma mas nada impede que a convenção do time seja diferente, desde que atenda ao time.

## IoC

Responsável pela injeção de dependências, conexão do banco de dados, e por agrupar as camadas anteriores.

## WebUI/API

Framework escolhido podendo ser um **MVC**, **API Rest**, **Desktop UI**.
