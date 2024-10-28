using API.GraphQl;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<OMAContext>(opt => {
    opt.UseInMemoryDatabase("InmemboryDb");
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services Register
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

//graphQl
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

//Cors
builder.Services.AddCors(opt =>{
    opt.AddPolicy(name:AllowSpecificOrigins, policy =>{
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Cors
app.UseCors(AllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyger", new GraphQL.Server.Ui.Voyager.VoyagerOptions{
    GraphQLEndPoint = "/graphql"
});
app.Run();

