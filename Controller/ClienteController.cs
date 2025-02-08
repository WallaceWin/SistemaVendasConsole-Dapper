using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Services;

namespace SistemaVendasConsole.Controller;

public class ClienteController
{
    public void Clientes(string stringConnection)
    {
        while (true)
        {
            Console.WriteLine(
                @"Escolha a ação: 
            [0] Sair
            [1] Cadastrar Cliente
            [2] Listar Clientes
            [3] Atualizar Cliente
            [4] Deletar Cliente
");
            var opcao = int.Parse(Console.ReadLine());
            var cadatrarCliente = new CadastrarCliente();
            
            if (opcao == 0) break;

            switch (opcao)
            {
                case 1:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        cadatrarCliente.CadastroCliente(connection);
                    }
                    break;
                case 2:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        cadatrarCliente.ListarCliente(connection);
                    }
                    break;
                case 3:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        cadatrarCliente.AlterarCliente(connection);
                    }
                    break;
                case 4:
                    using (var connection = new SqlConnection(stringConnection))
                    {
                        cadatrarCliente.ExcluirCliente(connection);
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            
        }
    }
}