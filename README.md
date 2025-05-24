GranShopAPI - Documentação Simplificada

Requisitos:

XAMPP (MySQL)

VS Code

.NET 9.0 SDK

Como instalar:

Inicie o MySQL no XAMPP

Clone o repositório:

git clone https://github.com/LucasGabrielFaustinoDaSilva/GranShop.git
Abra a pasta no VS Code

Configuração:

Edite o arquivo appsettings.json com seus dados do MySQL:

json
{
  "ConnectionStrings": {
    "Conexao": "server=localhost;database=gran_shop;user=root;password=''"
  }
}
Como rodar:

No terminal do VS Code:

dotnet watch run
Acesse no navegador:

http://localhost:5031/swagger
Endpoints disponíveis:

Categorias: GET, POST, PUT, DELETE

Produtos: GET, POST, PUT, DELETE

Estrutura do projeto:

Controllers/: Lógica da API

Models/: Classes Categoria e Produto

Data/: Configuração do banco de dados

Dicas:

Verifique sempre se o MySQL está rodando no XAMPP

Consulte os erros no terminal do VS Code

Teste todas as operações no Swagger