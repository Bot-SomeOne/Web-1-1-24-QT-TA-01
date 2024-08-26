namespace lab1;

class Route
{
    public static void RouteConfig(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        /**
         * Add a route 
         * Namespace default
         * Controller: Home
         */
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        /**
         * Add a route
         * Namespace default
         * Controller: Student
         */
        app.MapControllerRoute(
            name: "student",
            pattern: "{controller=Student}/{action=Index}/{id?}"
        );
    }
}