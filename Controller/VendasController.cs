using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Services;

namespace SistemaVendasConsole.Controller;

public class VendasController
{
    public void Vendas(string stringConnection)
    {
        while (true)
        {
            Console.WriteLine(
                @"Escolha a ação: 
            [0] Sair
            [1] Cadastrar Venda
            [2] Listar Vendas
            ");
            
            var opcao = int.Parse(Console.ReadLine());
            var vendasService = new VendasService();
            
            if (opcao == 0) break;

            switch (opcao)
            {
                case 1:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        vendasService.CadastrarVendas(connection);
                    }
                    break;
                case 2:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        vendasService.ListarVendas(connection);
                    }
                    break;
            }
        }
    }
}