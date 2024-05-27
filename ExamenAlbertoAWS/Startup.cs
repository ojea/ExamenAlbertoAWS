using Amazon.Lambda.Annotations;
using ExamenAlbertoAWS.Data;
using ExamenAlbertoAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExamenAlbertoAWS;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<RepositoryPeliculas>();
        string connectionString = @"server=awsmysqlojea.chemawumk14d.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=television";
        services.AddDbContext<PeliculasContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
