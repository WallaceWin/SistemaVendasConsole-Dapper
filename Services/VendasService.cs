using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeVendasConsole.Models;

namespace SistemaDeVendasConsole.Services;

public class VendasService
{
    public void CadastrarVendas(SqlConnection connection)
    {
        Console.WriteLine("Digite os codigos de Vendas");
        Console.WriteLine("Digite [0] para Salvar a venda");

        var vendas = new List<string>();
        
        while (true)
        {
            var read = Console.ReadLine();
            if (read == "0") break;
            
            vendas.Add(read);
        }
        
        Console.WriteLine("Digite o CPF do cliente");
        var cpf = Console.ReadLine();

        var sql = "INSERT INTO Vendas VALUES (@Id_venda, @CodigoProd, @CPF, @CreatedAt)";
        
        var venda = new Vendas();
        venda.Id_venda = Guid.NewGuid().ToString();
        venda.CPF = cpf;
        venda.CreatedAt = DateTime.Now;
        

        foreach (var item in vendas)
        {
            Console.WriteLine(item);
            connection.Execute(sql, new
            {
                Id_venda = venda.Id_venda,
                CodigoProd = item,
                CPF = venda.CPF,
                CreatedAt = venda.CreatedAt
            });
        }
        
        Console.WriteLine("Venda feita com sucesso!");
    }

    public void ListarVendas(SqlConnection connection)
    {
        var sql = "SELECT * FROM Vendas";
        var rows = connection.Query<Vendas>(sql);

        foreach (var item in rows)
        {
            Console.WriteLine($"{item.Id_venda} - {item.CodigoProd} - {item.CPF}");
        }
    }
}