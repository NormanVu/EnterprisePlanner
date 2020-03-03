using APIGateway.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIGateway.Contexts
{
    public class ApiGatewayContext : DbContext
    {
        public ApiGatewayContext(DbContextOptions<ApiGatewayContext> options) : base(options) { }
        public DbSet<Endpoint> Endpoints { get; set; }
    }
}
