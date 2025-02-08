using DotNetEnv;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Services;

SelecionarOpcao();

static void SelecionarOpcao()
{
    Env.Load();
    var server = Environment.GetEnvironmentVariable("SERVER");
    var database = Environment.GetEnvironmentVariable("DATABASE");
    var user = Environment.GetEnvironmentVariable("USER");
    var password = Environment.GetEnvironmentVariable("PASSWORD");
    
    var stringConnection = $"Server={server};Database={database};User ID={user};Password={password};TrustServerCertificate=True";
    
    while (true)
    {
        Console.WriteLine(@"
            Escolha a opção desejada:
            [0] Sair
            [1] Produtos
            [2] Cliente
            [3] Vendas
            ");
        var opcao = int.Parse(Console.ReadLine());

        if (opcao == 0) break;
        
        switch (opcao)
        {
            case 1: Produtos(stringConnection); break;
            case 2: Console.WriteLine("Clientes"); break;
            case 3: Console.WriteLine("Vendas"); break;
            default: Console.WriteLine("Opção invalida"); break;
        }
    }
}

static void Produtos(string stringConnection)
{

    while (true)
    {
        Console.WriteLine(
            @"Escolha a ação: 
            [0] Sair
            [1] Cadastrar Produtos
            [2] Listar Produtos
            [3] Atualizar Produtos
            [4] Deletar Produtos
");
        var opcao = int.Parse(Console.ReadLine());
        var cadastroProd = new CadastrarProdutos();

        if (opcao == 0) break;
    
        switch (opcao)
        {
            case 1:
                using (var connection = new SqlConnection(stringConnection))
                {
                    cadastroProd.cadastrarProduto(connection);
                }
                break;
            case 2:
                using (var connection = new SqlConnection(stringConnection))
                {
                    cadastroProd.ListarProdutos(connection);
                }
                break;
            case 3:
                using (var connection = new SqlConnection(stringConnection))
                {
                    cadastroProd.AlterarProduto(connection);
                }
                break;
            case 4:
                using (var connection = new SqlConnection(stringConnection))
                {
                    cadastroProd.DeletarProduto(connection);
                }
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }
}