# Projeto de avaliação de desenvolvedor .NET

`Jeferson Almeida`
`https://www.linkedin.com/in/jefersonalmeidadotnetdeveloper`
`11 997541210`


## Instruções para executar a aplicação
1. Altere a string de conexão no arquivo appsettings.json no projeto Ambev.DeveloperEvaluation.SalesApi
2. Abra o Package Manager Console 
3. Selecione o projeto Ambev.DeveloperEvaluation.SalesApi
4. Execute o comando Update-Database > Este comando vai criar e popular as tabelas: 
   Users, Customers, Products, SalesBranchs, Sales, SalesItems
5. Ao abrir o Swagger, no Item Sales execute o POST:

#### POST /Sale
- Description: Add a new Sale
- Request Body:
  ```json
  {
  "saleNumber": 4,
  "customerId": "c180df72-7893-4c43-9aac-cc3e285f56db",
  "salesBrancheId": "82d01876-9ce5-43f2-b872-f2f838652a82",
  "saleItems": [
   {
	 "quantity": 6,
	 "price": 3.25,
	 "totalSaleItemAmount": 0,
	 "discount": 0,
	 "totalPriceDiscount": 0,
	 "productId": "7fa0352c-fc7f-4f75-b7a4-a294aabb829b",
	 "saleId": "debd81f5-7b98-4c63-a482-8f0123bfa093"
   }
  ]
  }
  ```

### Regras de negócios

- **Percentual de desconto**

1. [x] Compras acima de 4 itens idênticos têm desconto de 10% 
2. [x] Compras entre 10 e 20 itens idênticos têm 20% de desconto 
3. [x] Não é possível vender mais de 20 itens idênticos
4. [x] Compras abaixo de 4 itens não podem ter desconto
5. [x] Estas regras de negócios definem níveis e limitações de desconto com base na quantidade:

- **Níveis de desconto:**

1. [x] Mais de 4 itens: 10% de desconto
2. [x] 10-20 itens: 20% de desconto

- **Restrições:**

1. [x] Limite máximo: 20 itens por produto
2. [x] Não são permitidos descontos para quantidades inferiores a 4 itens

