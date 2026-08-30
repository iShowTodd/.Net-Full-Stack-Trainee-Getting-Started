namespace ASP.NET_MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // These are Custom Middlewares in Middlewares
        /*
            USE → Execute and call next middleware
            Map → Execute and Route
            Run → Execute and Terminate
         */

        //app.Use(async (HttpContext, next) =>
        //{
        //    await HttpContext.Response.WriteAsync("1) Write Custom Middleware");
        //    await next.Invoke();
        //});
        //// No Next as it terminates
        //app.Run(async (HttpContext) =>
        //{
        //    await HttpContext.Response.WriteAsync("2) Write and Terminate Custom Middleware");
        //});

        // Built-In Middlewares

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //app.UseStaticFiles(); // used to manage the views Default (HTML , CSS , JS , IMAGES , VIDEOS ) in the wwwroot (Has alternatives in .Net 9)
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();
        app.UseSession();

        app.MapStaticAssets(); // Alt : for UseStaticFiles
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}