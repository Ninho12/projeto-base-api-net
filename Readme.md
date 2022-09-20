# Os Passos para criar uma API no .Net

Primeiro Inicia um projeto criando uma pasta
ou renomeando essa pasta;

projeto-base-api-net

> cd projeto-base-api-net

> dotnet new webapi

----> Caso estiver usando esse como base não precisar seguir o tutorial;
	Esse tutorial é para quem esta criando um projeto de api do zero;

No Terminal:

## Instalando a ferramenta dotnet-ef (EntityFramework)
1 Passo: dotnet tool install --global dotnet-ef

	Esse passo é so necessario executar uma vez 
	no seu computador.


## Instalando os pacotes nescessario para a criação da api:

2 Passo: dotnet add package Microsoft.EntityFrameworkCore.Design

	Instala um pacote para trabalhar com banco de dados.

3 Passo: dotnet add package Microsoft.EntityFrameworkCore.SqlServer

	Instala o pacote para trabalhar com o Sql Server;
	Para trabalhar com outro banco de dados é só trocar para o nome
	do banco de dados. Exemplo: dotnet add package Microsoft...MySql

## Criação de Arquivos  

4 Passo: Criar uma classe exemplo: Pessoa, criar uma pasta com nome: Models
	para separar as classes que vão virar tabelas no banco de dados.

	public class Pessoa{
		
		public int id { get; set; }
		public string nome { get; set; }
		public string email { get; set; }
		public string senha { get; set; }
		
	}

5 Passo: Criar um contexto, cria uma pasta: Context, crie uma classe com nome
	que você quiser, exemplo: PessoasContext.

	public class PessoasContext : DbContext {
		
		public PessoasContxt(DbContextOptions<PessoasContext> options) : base(options){}
		// PessoasContext é nome da classe que conecta com o banco de dados, você pode mudar
		//	de acordo com a sua aplicação.

		public Dbset<Pessoa> Pessoas { get; set; }
		// Dbset é para o EntityFramework transformar a classe que estar dentro
		// <> em uma tabela do banco de dados; Pessoa é a classe e Pessoas é a tabela.
	}
	
## Configurando a conexão

6 Passo: Configurar a conexão: No arquivo de configuração:

	1. appsettings.json
	2. appsettings.Development.json
		Adiciona no segundo arquivo essas linhas:
			"ConnectionString":{ 
				"ConexaoPadrao": "Server=localhost\\sqlexpress; Initial Catolog=Humanos; Integrated Security=True"
				// Humanos é o nome do banco, posso escrever qualquer nome depentendo da aplicação.
			 }

7 Passo: Abrir a classe Program.cs para adicionar os comandos

	começando com um Import
		using ModuloAPI.Context;
		using Microsoft.EntityFrameworkCore;

	no começo dos seu codigo:
		builder.Services.AddDbContext<PessoaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionsString("ConexaoPadrao")));

## Trabalhando com Migration

8 Passo: Criando uma Migration

	Rodar o SqlServer;
	No Terminal:
		dotnet-ef migrations add CriacaoTabelaPessoas - Enter

	Automaticamente o sistema criar uma pasta Migrations;
	As migrations vão fazer a conversão das classes para tabelas no banco de dados;

9 Passo: Executar uma migration

	dotnet-ef database update - Enter
	
	Com esse comando criamos uma ou varias tabelas no banco de dados.

10 Passo: 