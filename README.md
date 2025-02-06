# Projeto de avaliação de desenvolvedor .NET

`LEIA COM ATENÇÃO`

## Instruções para executar a aplicação
1) Altere a string de conexão no arquivo appsettings.json no projeto Ambev.DeveloperEvaluation.SalesApi
1) Abra o Package Manager Console 
2) Selecione o projeto Ambev.DeveloperEvaluation.SalesApi
3) Execute o comando Update-Database > Este comando vai criar e popular as tabelas: 
   Users, Customers, Products, SalesBranchs, Sales, SalesItems


### Regras de negócios

- **Percentual de desconto**

1. [x] Compras acima de 4 itens idênticos têm desconto de 10% 
2. [] Compras entre 10 e 20 itens idênticos têm 20% de desconto 
3. [] Não é possível vender mais de 20 itens idênticos
4. [] Compras abaixo de 4 itens não podem ter desconto
5. [] Estas regras de negócios definem níveis e limitações de desconto com base na quantidade:

- **Níveis de desconto:**

1. [] Mais de 4 itens: 10% de desconto
2. [] 10-20 itens: 20% de desconto

- **Restrições:**

1. [] Limite máximo: 20 itens por produto
2. [] Não são permitidos descontos para quantidades inferiores a 4 itens

