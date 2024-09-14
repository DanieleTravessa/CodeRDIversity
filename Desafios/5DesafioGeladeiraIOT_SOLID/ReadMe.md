### **Códigos gerados usando VScode**

<a id="documentacao"></a>
<h1 align="center">
    Programa CodeRDIversity - 5° Projeto<br>    
</h1>
<p align="center">
      <img src="https://prospertechtalents.com/wp-content/uploads/2024/02/Prosper-Logo-Red.png" alt="Logo Prosper Tech Talents"> 
</center>
<p align="center">
    <img src="https://www.rdisoftware.com/img/logo.png" alt="Logo RDI"> 
</center>

# GeladeiraSOLID

## 🤖Introdução
Este repositório possui os Projetos relacionado à quinta semana durante o programa.
Para os projetos desenvolvidos nesse repositório foi utilizado a ferramente **VSCode**.

## 🚀Proposta do desafio:
### 🖱️  Criar uma API conectada a um  Banco de Dados
Este projeto implementa uma API RESTful para gerenciar uma geladeira inteligente seguindo os princípios de SOLID, implementada com ASP.NET Core Web API, Entity Framework Core e SQL Server. A aplicação permite adicionar, remover e buscar itens armazenados nas prateleiras e containers da geladeira, garantindo a unicidade de combinações de prateleira, container e posição.

## 🖱️Configuração do Ambiente

### Pré-requisitos

- .NET 6 SDK ou superior
- SQL Server
- Visual Studio Code ou Visual Studio

## Funcionalidades

- **Adicionar Item**: Insere um novo item na geladeira, garantindo que a combinação de prateleira, container e posição seja única.
- **Classificar itens por categoria**: (hortifruti, laticínios, carnes, etc.).
- **Monitorar a validade**: Retorna os produtos que a validade estiver expirada (data de validade igual ou anterior à data atual).
- **Remover Item**: Remove um item existente da geladeira.
- **Buscar Item por Nome**: Retorna os detalhes de um item com base no nome.
- **Atualizar Item Vencido**: Atualiza um item vencido, acessando pelo id.
- **Validação**: Impede a inserção de itens duplicados com a mesma combinação de prateleira, container e posição.

## Estrutura do Projeto
O projeto segue uma estrutura de camadas para facilitar a manutenção e evolução da aplicação:

1. **Camada de Dados (Data Layer)**: 
   - Contém o contexto do Entity Framework (`GeladeiraSOLIDContext`), onde estão mapeadas as tabelas e seus relacionamentos.
   
2. **Camada de Modelos (Models Layer)**:
   - Definição das classes que representam os itens da geladeira, como a classe `Item` com suas propriedades (`Nome`, `Categoria`, `Validade`, `Prateleira`, `Container`, `Posicao`, etc.).
   
3. **Camada de Regras de Negócio (Business Logic Layer)**:
   - Contém a lógica para operações relacionadas a itens da geladeira, como validação de validade e posições disponíveis.

4. **Camada de Apresentação (Presentation Layer)**:
   - A API RESTful responsável por expor as funcionalidades do sistema e permitir operações como criação, leitura, atualização e exclusão de itens.

### Configuração do Banco de Dados

1. Foi usada a migrations para criação da tabela;
2. Foi executado o script [`database.sql`](Desafios\5DesafioGeladeiraIOT_SOLID\GeladeiraSOLID\GeladeiraSOLID.sql) no servidor SQL Server para popular a tabela `Itens` e com os dados iniciais.

### Configuração da Aplicação

1. Atualize a string de conexão no arquivo `appsettings.json` com as informações do seu servidor SQL Server.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=GeladeiraApiDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
    // "DefaultConnection": "Data Source=DESKTOP-JBG4ILK;Database=GeladeiraApiBD;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```
<!--
### 🖱️ Estruturação da Tabela
Foi criada a tabela 
### 🖱️ Criação das Requests
-->
 
### 🖱️ Como rodar a aplicação
Use o comando:
```
dotnet watch run
```
#### Recomendo usar o atributo  
    [watch]  
    - Ele inicia um observador de arquivo que executa um comando quando os arquivos são alterados.
<!--
### 🖱️ Validação dos Resultados  
Os resultados foram validados para garantir a precisão das análises. Esta etapa incluiu a revisão das queries e a verificação dos dados de entrada.
### Retorno no Swagger  
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-7.png)
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image.png)  

**Get-Listar todos os itens**                  ---              **Get-Listar um item específico**  

![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-1.png)
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-2.png)  

**Post-Inserir um item**  
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-3.png)  

**Retirar um item**  
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-5.png)
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-6.png)  

## ✴️Melhorias identificadas:
1. Incluir Validação de posição e validação de categoria.
     
![alt text](/Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-4.png)

3. Acessar o item pelo nome do produto.
-->

## 📄Tecnologias Utilizadas  
- **.NET 8**: Framework utilizado para a construção da API.
- **C#**: Linguagem criada pela Microsoft utilizada para criação e execução de programas.  
- **VSCode**: Utilizado para criação das Soluções, Projetos e Códigos.  
- **GIT**: Utilizado para o versionamento de código e documentação.  
- **.NET**: Framework desenvolvido pela Microsoft com várias funcionalidades.  
- **Entity Framework Core**: Para gerenciamento de banco de dados.
- **Swagger**: Para a documentação da API.
- **SOLID**: Princípios de design seguidos no projeto.
- Opcional: **Visual Studio**: IDE, mais performática que o VSCode para programas desenvolvidos em C#.  

## 📰 Referências e Materiais Extras:  
✴ Documentação do C# e .NET.  
✴ Livros e recursos online sobre a linguagem e o framework.  
✴ Orientações das aulas.  

## 📄Conclusão
Este desafio buscou promover o aprendizado da implantação de uma API, além da prática da liguagem C# e do framework .NET. 
Se você está interessado em contribuir ou aprender mais sobre o assunto, sinta-se à vontade para contribuir! 🚀  

## 💌Como Contribuir:  
Fique à vontade para sugerir melhorias no modelo da API ou na documentação.  
Caso encontre algum problema ou tenha dúvidas, abra uma issue para discussão.  
Contribuições são bem-vindas via pull requests.  

# Índice de conteúdo  
1. [Etapas do Projeto](#etapas-do-projeto)  
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)  
3. [Códigos Desenvolvidos](#códigos-desenvolvidos)  
4. [Visualizações](#visualizações)
5. [Conclusão](#conclusão) -->
