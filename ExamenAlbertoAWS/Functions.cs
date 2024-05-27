using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using System.Runtime.CompilerServices;
using ExamenAlbertoAWS.Repositories;
using ExamenAlbertoAWS.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ExamenAlbertoAWS;

public class Functions
{
    private RepositoryPeliculas repo;
    
    public Functions(RepositoryPeliculas repo)
    {
        this.repo = repo;
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/GetPeliculas")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        List<Pelicula> peliculas = await this.repo.GetPeliculas();
        return HttpResults.Ok(peliculas);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/GetPeliculasActores/{actor}")]
    public async Task<IHttpResult> Find(string actor, ILambdaContext context)
    {
        context.Logger.LogInformation($"Handling the 'Get' Request");
        List<Pelicula> pelis = await this.repo.GetPeliculasActores(actor);
        return HttpResults.Ok(pelis);
    }
}
