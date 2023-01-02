using ApiCatalogo02.ApiEndpoints;
using ApiCatalogo02.AppServicesExtensions;
using ApiCatalogo02.Context;
using ApiCatalogo02.Models;
using ApiCatalogo02.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

//----------------------------------------------------------------------------------------------------------------
var app = builder.Build();

app.MapAutenticacaoEndPoins();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

// Configure the HTTP request pipeline.// Configure
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

var enveroment = app.Environment;
app.useExceptionHandling(enveroment).UseSwaggerMiddleware().useAppCors();


//app.UseHttpsRedirection();
app.UseAuthentication(); // requisitos para a chave
app.UseAuthorization(); // requisitos para a chave

app.Run();