using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Models;

namespace SistemaDeVendasConsole.Services;

public class CadastrarCliente
{
    public void CadastroCliente(SqlConnection connection)
    {
        var cliente = new Clietes();
        Console.WriteLine("Digite o CPF do cliente: ");
        cliente.CPF = Console.ReadLine();
        Console.WriteLine("Digite o Nome do cliente: ");
        cliente.Nome = Console.ReadLine();
        Console.WriteLine("Digite a data de aniversario do cliente: ");
        cliente.Birthdate = DateTime.Parse(Console.ReadLine());
        cliente.CreatedAt = DateTime.Now;

        var sqlCommand = "INSERT INTO [Clientes] VALUES (@CPF, @Nome, @Birthdate, @CreatedAt);";
        
        var rows = connection.Execute(sqlCommand, new
        {
            CPF = cliente.CPF,
            Nome = cliente.Nome,
            Birthdate = cliente.Birthdate,
            CreatedAt = cliente.CreatedAt
        });
        
        if(rows > 0) Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    public void ListarCliente(SqlConnection connection)
    {
        var sqlCommand = "SELECT * FROM [Clientes]";
        var clientList = connection.Query<Clietes>(sqlCommand);

        foreach (var item in clientList)
        {
            Console.WriteLine($"CPF: {item.CPF} - Nome do cliente: {item.Nome} - Data de aniversario: {item.Birthdate}");
        }
    }

    public void AlterarCliente(SqlConnection connection)
    {
        var cliente = new Clietes();
        Console.WriteLine("Digite o CPF do cliente a ser alterada: ");
        cliente.CPF = Console.ReadLine();
        Console.WriteLine("Digite o novo Nome do cliente: ");
        cliente.Nome = Console.ReadLine();
        Console.WriteLine("Digite a nova data de nascimento do cliente: ");
        cliente.Birthdate = DateTime.Parse(Console.ReadLine());

        var sqlCommand = "UPDATE [Clientes] SET [Nome] = @Nome, [Birthdate]=@Birthdate WHERE [CPF] = @CPF;";
        var rows = connection.Execute(sqlCommand, new
        {
            CPF = cliente.CPF,
            Nome = cliente.Nome,
            Birthdate = cliente.Birthdate
        });
        
        if (rows > 0) Console.WriteLine("Cliente alterado com sucesso!");
    }

    public void ExcluirCliente(SqlConnection connection)
    {
        var cliente = new Clietes();
        Console.WriteLine("Digite o CPF do cliente a ser excluido: ");
        cliente.CPF = Console.ReadLine();
        
        var sqlCommand = "DELETE FROM [Clientes] WHERE [CPF] = @CPF;";
        var rows = connection.Execute(sqlCommand, new {CPF = cliente.CPF});
        
        if (rows > 0) Console.WriteLine("Cliente excluido com sucesso!");
    }
}