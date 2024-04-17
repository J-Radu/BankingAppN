namespace BankingAppN.Database.Data;

public class ConnectionStringManager
{
    private static ConnectionStringManager? _instance;
    private readonly string _connectionString;

    private ConnectionStringManager()
    {
        _connectionString = LoadConnectionStringFromJson();
    }

    public static ConnectionStringManager? Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConnectionStringManager();
            }
            return _instance;
        }
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }

    private static string LoadConnectionStringFromJson()
    {
        string connectionString = "";

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        connectionString = configuration.GetConnectionString("BankDB")!;
        
        return connectionString;
    }
}
