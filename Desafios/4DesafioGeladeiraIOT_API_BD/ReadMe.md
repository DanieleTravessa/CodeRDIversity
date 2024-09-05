### **Códigos gerados usando VScode**

<a id="documentacao"></a>
<h1 align="center">
    Programa CodeRDIversity - 4° Projeto<br>    
</h1>
<p align="center">
      <img src="https://prospertechtalents.com/wp-content/uploads/2024/02/Prosper-Logo-Red.png" alt="Logo Prosper Tech Talents"> 
</center>
<p align="center">
    <img src="https://www.rdisoftware.com/img/logo.png" alt="Logo RDI"> 
</center>

# GeladeiraAPI

## 🤖Introdução
Este repositório possui os Projetos relacionado à quarta semana durante o programa.
Para os projetos desenvolvidos nesse repositório foi utilizado a ferramente **VSCode**.

## 🚀Proposta do desafio:
### 🖱️  Criar uma API conectada a um  Banco de Dados
API para gerenciamento de itens de uma geladeira IOT, implementada com ASP.NET Core Web API, Entity Framework Core e SQL Server.

## 🖱️Configuração do Ambiente

### Pré-requisitos

- .NET 6 SDK ou superior
- SQL Server
- Visual Studio Code ou outro editor de sua preferência

### Configuração do Banco de Dados

1. Executado o script [`database.sql`](Desafios\4DesafioGeladeiraIOT_API_BD\GeladeiraApiBD\GeladeiraApiBD.sql) no seu servidor SQL Server para criar a tabela `Itens` e inserir dados iniciais.

### Configuração da Aplicação

1. Atualize a string de conexão no arquivo `appsettings.json` com as informações do seu servidor SQL Server.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=GeladeiraApiDB;Trusted_Connection=True;MultipleActiveResultSets=true"
    // "DefaultConnection": "Data Source=DESKTOP-JBG4ILK;Database=GeladeiraApiBD;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```

### 🖱️ Estruturação da Tabela
Foi criada a tabela 
### 🖱️ Criação das Requests
 
### 🖱️ Como rodar a aplicação
Use o comando:
```
dotnet watch run
```
#### Recomendo usar o atributo  
    [watch]  
    - Ele inicia um observador de arquivo que executa um comando quando os arquivos são alterados.

### 🖱️ Validação dos Resultados  
Os resultados foram validados para garantir a precisão das análises. Esta etapa incluiu a revisão das queries e a verificação dos dados de entrada.
### Retorno no Swagger
![alt text](\Imagens\image-7.png)
![alt text](\Imagens\image.png)

**Get-Listar todos os itens**
![alt text](Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-1.png)
**Get-Listar um item específico**
![alt text](Desafios/4DesafioGeladeiraIOT_API_BD/Imagens/image-2.png)
**Post-Inserir um item**
![alt text](/Imagens/image-3.png)
**Retirar um item**
![alt text](/Imagens/image-5.png)
![alt text](/Imagens/image-6.png)

## ✴️Melhorias identificadas:
1. Incluir Validação de posição e validação de categoria.
![alt text](/Imagens/image-4.png)
2. Acessar o item pelo nome do produto.

## 📄Tecnologias Utilizadas  
- **C#**: Linguagem criada pela Microsoft utilizada para criação e execução de programas.  
- **VSCode**: Utilizado para criação das Soluções, Projetos e Códigos.  
- **GIT**: Utilizado para o versionamento de código e documentação.  
- **.NET**: Framework desenvolvido pela Microsoft com várias funcionalidades.  
- **Visual Studio**: IDE, mais performática que o VSCode para programas desenvolvidos em C#.  

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
