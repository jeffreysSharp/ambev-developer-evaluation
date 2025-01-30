[Back to README](../README.md)

## Definições Gerais de API

### Paginação

A paginação é suportada para pontos de extremidade de lista usando os seguintes parâmetros de consulta:

- `_page`: Page number (default: 1)
- `_size`: Number of items per page (default: 10)

Exemplo:
```
GET /products?_page=2&_size=20
```

### Pedido

Ao solicitar uma coleção de um recurso, você também pode especificar a ordem dos elementos na coleção usando o parâmetro de consulta `_order`. Basta indicar a ordem desejada: crescente (`asc`) ou decrescente (`desc`). Se não for especificado, a ordem padrão será crescente.

**Observação**

Na solicitação GET, você deve usar os nomes dos campos no mesmo formato da resposta JSON.

Por exemplo, considere o seguinte recurso de Produto:

```json
{
  "id": 1,
  "title": "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
  "price": 109.95,
  "description": "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
  "category": "men's clothing",
  "image": "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
  "rating": {
    "rate": 3.9,
    "count": 120
  }
}
```

Neste caso, para recuperar uma lista de produtos ordenados por preço em ordem decrescente e depois por título em ordem crescente, a solicitação ficaria assim:

```
GET /products?_order="price desc, title asc"
```

or 

```
GET /products?_order="price desc, title"
```

### Filtragem

Os filtros podem ser aplicados aos endpoints da lista usando os seguintes parâmetros de consulta:

- `field=value`: Filtrar por valor de campo específico

Exemplo:

```
GET /products?category=men's clothing&price=109.95
```

**Campos de string**

Para filtrar correspondências parciais para campos de string, use um asterisco (`*`) antes ou depois do valor.

Exemplo:

```
GET /products?title=Fjallraven*
GET /products?category=*clothing
```

**Campos numéricos e de data**

Para filtrar campos numéricos ou de data por intervalo, use os prefixos `_min` e `_max` antes do nome do campo.

Exemplo:

```
GET /products?_minPrice=50
GET /products?_minPrice=50&_maxPrice=200
GET /carts?_minDate=2023-01-01
```

Operadores Lógicos
Ao combinar filtros, use `&` (AND) between them.

Exemplo:

```
GET /products?category=men's clothing&_minPrice=50
GET /products?title=Fjallraven*&category=men's clothing&_minPrice=100
```

*Observação*
Mesmo ao filtrar com "OR" para valores diferentes no mesmo campo, use `&` na consulta.

## Tratamento de erros

A API usa códigos de resposta HTTP convencionais para indicar o sucesso ou a falha de uma solicitação de API. Em geral:

- 2xx range indicate success
- 4xx range indicate an error that failed given the information provided (e.g., a required parameter was omitted, etc.)
- 5xx range indicate an error with our servers

### Formato de resposta de erro

```json
{
  "type": "string",
  "error": "string",
  "detail": "string"
}
```

- `type`: A machine-readable error type identifier
- `error`: A short, human-readable summary of the problem
- `detail`: A human-readable explanation specific to this occurrence of the problem

Exemplos de respostas de erro:

1. Recurso não encontrado
```json
{
  "type": "ResourceNotFound",
  "error": "Product not found",
  "detail": "The product with ID 12345 does not exist in our database"
}
```

2. Erro de autenticação
```json
{
  "type": "AuthenticationError",
  "error": "Invalid authentication token",
  "detail": "The provided authentication token has expired or is invalid"
}
```

3. Erro de validação
```json
{
  "type": "ValidationError",
  "error": "Invalid input data",
  "detail": "The 'price' field must be a positive number"
}
```

Para obter informações detalhadas sobre erros, consulte a documentação específica do endpoint.

<br>
<div style="display: flex; justify-content: space-between;">
  <a href="./frameworks.md">Previous: Frameworks</a>
  <a href="./products-api.md">Next: Products API</a>
</div>