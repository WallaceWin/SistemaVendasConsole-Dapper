using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Services;

namespace SistemaVendasConsole.Controller;

public class ProdutosController
{
    public void Produtos(string stringConnection)
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
}