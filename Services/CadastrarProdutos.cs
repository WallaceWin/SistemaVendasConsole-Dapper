using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Models;

namespace SistemaDeVendasConsole.Services;

public class CadastrarProdutos
{
    public string cadastrarProduto(SqlConnection connection)
    {
        var produto = new Produtos();
        produto.Codigo = Guid.NewGuid().ToString();
        Console.Write("Digite o nome do produto: ");
        produto.Nome = Console.ReadLine();
        Console.WriteLine("Digite o valor do produto: R$ ");
        produto.Valor = float.Parse(Console.ReadLine());
        produto.CreatedAt = DateTime.Now;

        var sqlCommand = "INSERT INTO [Produtos] VALUES (@codigo,@nome,@valor,@createdAt)";

        var rows = connection.Execute(sqlCommand, new
        {
            codigo = produto.Codigo,
            nome = produto.Nome,
            valor = produto.Valor,
            createdAt = produto.CreatedAt
        });
        
        return @"Cadastro realizado com sucesso!
                 Linhas Afetadas" + rows;
    }

    public void ListarProdutos(SqlConnection connection)
    {
        var sqlCommand = "SELECT * FROM Produtos";
        var produtos = connection.Query<Produtos>(sqlCommand);

        foreach (var item in produtos)
        {
            Console.WriteLine($"{item.Codigo} - {item.Nome} - R$ {item.Valor} - {item.CreatedAt}");
        }
    }
}