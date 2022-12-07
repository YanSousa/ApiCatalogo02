using ApiCatalogo02.Context;
using ApiCatalogo02.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo02.ApiEndpoints
{
    public static class CategoriasEndpointscs
    {
        public static void MapCategoriasEndpoints(this WebApplication app)
        {
            //app.MapGet("/", () => "Catalogo de Produtos - 2022").ExcludeFromDescription(); // EXCLUI DA LISTA

            app.MapPost("/categorias", async (Categoria categoria, AppDbContext db) =>
            {
                db.Categorias.Add(categoria);
                await db.SaveChangesAsync();

                return Results.Created($"/categorias/{categoria.CategoriaId}", categoria);
            });

            app.MapGet("/categorias", async (AppDbContext db) => await db.Categorias.ToListAsync()).WithTags("Categorias").RequireAuthorization(); //precisa de authorization ainda colocado o WithTags para separar o endpoint

            app.MapGet("/categorias/{id:int}", async (int id, AppDbContext db) =>
            {
                return await db.Categorias.FindAsync(id)
                             is Categoria categoria
                             ? Results.Ok(categoria)
                             : Results.NotFound();
            });

            app.MapPut("/categorias/{id:int}", async (int id, Categoria categoria, AppDbContext db) =>
            {
                if (categoria.CategoriaId != id)
                {
                    return Results.BadRequest();
                }

                var categoriaDB = await db.Categorias.FindAsync(id); //localizar

                if (categoriaDB is null) return Results.NotFound(); //não achou

                categoriaDB.Nome = categoria.Nome;
                categoriaDB.Descricao = categoria.Descricao;

                await db.SaveChangesAsync();
                return Results.Ok(categoriaDB);
            });



            app.MapDelete("/categorias/{id:int}", async (int id, AppDbContext db) =>
            {
                var categoria = await db.Categorias.FindAsync(id); //localizar

                if (categoria is null)
                {
                    return Results.NotFound();
                }

                db.Categorias.Remove(categoria);
                await db.SaveChangesAsync();


                return Results.NoContent();
            });
        }

    }
}
