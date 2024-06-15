# API de Produtos
Esse projeto é uma API de produtos que será utilizada por outra aplicação client. A API possui opções de leitura por id, leitura de lista, inserção, alteração, e deleção, além da apresentação de um dashboard, que apresenta a quantidade e o preço unitário médio segregado por tipo de produto.

## Requisîtos
```
Docker versão 26.1.1
docker compose versão 4.3
DBeaver versao 24.0.5
Visual Studio 2022 versão 17.9.7
```

## Rodando o banco

Na raiz do projeto, abra um terminal e execute o seguinte comando para inicializar o banco:
```
docker-compose up -d
```
Este comando executará um container com a imagem do postgres e criará as entidades necessárias, expondo o banco na porta 5432 para a aplicação.

## Testando a aplicação manualmente

Abra o projeto no visual studio e execute.
A api deverá abrir uma documentação swagger que você pode utilizar
para listar, inserir, atualizar e excluir Produtos, além do Dashboard.
Clique no botão Authorize e utilize o usuário e senha admin:admin na autenticação Basic.


## Perguntas
- Quais princípios SOLID foram usados? Qual foi o motivo da escolha deles? <br><br>
Os princípios SOLID utilizados foram o princípio da responsabildade única e o princípio da inversão de dependência.<br>
Princípio da responsabilidade única por tornar o código mais coeso, além de torná-lo mais apropriado para o reaproveitamento de código.<br>
Princípio da inversão de dependência por permitir que a alteração de uma classe não afete outras partes do sistema. Podendo garantir mais segurança durante a manutenção e reduzir o risco de ocasionar erros em outras partes do sistema.<br><br>
- Dado um cenário que necessite de alta performance, cite 2 locais possíveis
de melhorar a performance da API criada e explique como seria a
implementação desta melhoria. 
<br><br>
Os dois pontos de melhoria de performance são o GetAll() e o GetDashboard().
<br><br>
GetAll(): Em um caso de listagem de muitos registros, uma solução viável é a paginação. Isso implica em limitar o número de registos retornardos por página. Dessa forma poderá reduzir a carga do servidor e melhorar o desempenho em uma situação com muitos registros.
<br><br>
GetDashboard(): Para o dashboard, cache de dados é uma opção para essa melhoria. Isso consite em armazenar em cache os dados necessários para renderizar o dashboard. No método, antes de acessar o banco, deve haver uma verificação se os dados estão em cache. E quando houver alterações, seja por adição de um novo registro, atualização ou deleção, o cache deverá ser invalidado e atualizado.