using DotNetEnv;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Services;
using SistemaVendasConsole.Controller;

Main();

static void Main()
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
            case 1:
                var produtosController = new ProdutosController();
                produtosController.Produtos(stringConnection);
                break;
            case 2: 
                var clienteController = new ClienteController();
                clienteController.Clientes(stringConnection);
                break;
            case 3: Console.WriteLine("Vendas"); break;
            default: Console.WriteLine("Opção invalida"); break;
        }
    }
}
