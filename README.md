# Projeto de avaliação de desenvolvedor .NET

`LEIA COM ATENÇÃO`

## Instruções para executar a aplicação
1) Altere a string de conexão no arquivo appsettings.json no projeto Ambev.DeveloperEvaluation.WebApi
1) Abra o Package Manager Console 
2) Selecione o projeto Ambev.DeveloperEvaluation.WebApi
3) Execute o comando Update-Database


## Instruções
**O teste abaixo terá até 7 dias corridos para ser entregue a partir da data de recebimento deste manual.**

- O código deve ser versionado em um repositório público do Github e um link deve ser enviado para avaliação depois de concluído
- Carregue este modelo em seu repositório e comece a trabalhar a partir dele
- Leia as instruções com atenção e certifique-se de que todos os requisitos estejam sendo atendidos
- O repositório deve fornecer instruções sobre como configurar, executar e testar o projeto
- A documentação e a organização geral também serão levadas em consideração

## Caso de uso
**Você é um desenvolvedor da equipe DeveloperStore. Agora precisamos implementar os protótipos da API.**

Como trabalhamos com `DDD`, para referenciar entidades de outros domínios, utilizamos o padrão `External Identities` com desnormalização de descrições de entidades.

Portanto, você escreverá uma API (CRUD completa) que trata dos registros de vendas. A API precisa ser capaz de informar:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

Não é obrigatório, mas seria um diferencial construir código para publicação de eventos de:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

Se você escrever o código, **não será necessário** publicar em qualquer Message Broker. Você pode registrar uma mensagem no log do aplicativo ou como achar mais conveniente.

### Regras de negócios

* Compras acima de 4 itens idênticos têm desconto de 10%
* Compras entre 10 e 20 itens idênticos têm 20% de desconto
* Não é possível vender mais de 20 itens idênticos
* Compras abaixo de 4 itens não podem ter desconto


Estas regras de negócios definem níveis e limitações de desconto com base na quantidade:

1. Níveis de desconto:
   - Mais de 4 itens: 10% de desconto
   - 10-20 itens: 20% de desconto

2. Restrições:
   - Limite máximo: 20 itens por produto
   - Não são permitidos descontos para quantidades inferiores a 4 itens

## Visão geral
Esta seção fornece uma visão geral de alto nível do projeto e das diversas habilidades e competências que ele pretende avaliar para candidatos a desenvolvedores.

Ver [Overview](/.doc/overview.md)

## Tecnologias
Esta seção lista as principais tecnologias usadas no projeto, incluindo backend, testes, frontend e componentes de banco de dados.

Ver [Tech Stack](/.doc/tech-stack.md)

## Frameworks
Esta seção descreve as estruturas e bibliotecas que são aproveitadas no projeto para aumentar a produtividade e a capacidade de manutenção do desenvolvimento.

Ver [Frameworks](/.doc/frameworks.md)

<!-- 
## Estrutura APIs
Esta seção inclui links para a documentação detalhada dos diferentes recursos da API:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Estrutura do Projeto
Esta seção descreve a estrutura geral e a organização dos arquivos e diretórios do projeto.

Ver [Project Structure](/.doc/project-structure.md)