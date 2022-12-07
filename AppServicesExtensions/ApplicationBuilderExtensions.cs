namespace ApiCatalogo02.AppServicesExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder useExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            
            if (environment.IsDevelopment()) //tratamento de exceção
            {
                app.UseDeveloperExceptionPage();
            }

            return app;

        }

        public static IApplicationBuilder useAppCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin(); //receber requisição de qualquer lugar
                p.WithMethods("GET"); // somente GET
                p.AllowAnyHeader(); // qualquer cabeçario
            });
            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }

    }
}
