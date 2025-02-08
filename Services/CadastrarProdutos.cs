using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Models;

namespace SistemaDeVendasConsole.Services;

public class CadastrarProdutos
{
    public void cadastrarProduto(SqlConnection connection)
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
        
        if (rows > 0) Console.WriteLine("Produto Criado com sucesso!");
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

    public void AlterarProduto(SqlConnection connection)
    {
        var produto = new Produtos();
        Console.Write("Digite o codigo do produto a alterar: ");
        produto.Codigo = Console.ReadLine();
        Console.Write("Digite o novo nome do produto: ");
        produto.Nome = Console.ReadLine();
        Console.Write("Digite o novo valor do produto: R$ ");
        produto.Valor = float.Parse(Console.ReadLine());
        
        var sqlCommand = "UPDATE [Produtos] SET [Nome] = @Nome, [Valor] = @Valor WHERE [Codigo]=@Codigo";
        var rows = connection.Execute(sqlCommand, new
        {
            Codigo = produto.Codigo,
            Nome = produto.Nome,
            Valor = produto.Valor
        });
        
        if (rows > 0) Console.WriteLine("Produto alterado com sucesso!");
    }

    public void DeletarProduto(SqlConnection connection)
    {
        var produto = new Produtos();
        Console.WriteLine("Digite o codigo do produto a excluir: ");
        produto.Codigo = Console.ReadLine();

        var sqlCommand = "Delete from Produtos WHERE [Codigo]=@Codigo";
        var rows = connection.Execute(sqlCommand, new
        {
            Codigo = produto.Codigo
        });
        
        if (rows > 0) Console.WriteLine("Produto excluido com sucesso!");
    }
}