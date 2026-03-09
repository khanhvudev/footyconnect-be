namespace FootyConnect.Infrastructure.ConfigurationOptions;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
    public JwtOptions JwtOptions { get; set; } = new JwtOptions();
}
