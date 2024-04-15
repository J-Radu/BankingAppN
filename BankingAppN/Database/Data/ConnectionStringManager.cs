using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankingApp.Data;

public class ConnectionStringManager
{
    private static ConnectionStringManager instance;
    private string connectionString;

    private ConnectionStringManager()
    {
        connectionString = LoadConnectionStringFromJson();
    }

    public static ConnectionStringManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConnectionStringManager();
            }
            return instance;
        }
    }

    public string GetConnectionString()
    {
        return connectionString;
    }

    private string LoadConnectionStringFromJson()
    {
        string connectionString = "";

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        connectionString = configuration.GetConnectionString("BankDB");
        
        return connectionString;
    }
}
