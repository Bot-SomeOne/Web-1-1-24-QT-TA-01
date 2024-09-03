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
            pattern: "{controller=Home}/{action=Index}/{id?}",
            defaults: new { controller = "Home", action = "Index" }
        );

        /**
         * Add a route for BufferedFileUploadController
         */
        app.MapControllerRoute(
            name: "upload small file",
            pattern: "upload/1",
            defaults: new { controller = "BufferedFileUpload", action = "Index" }
        );

        /**
         * Add a route for StreamFileUploadLocalService
         */
        app.MapControllerRoute(
            name: "upload small large",
            pattern: "upload/2",
            defaults: new { controller = "StreamFileUpload", action = "Index" }
        );

        /**
         * Add a route for Areas
         */
        app.MapAreaControllerRoute(
            name: "areas",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
            defaults: new { areas="Admin", controller = "Home", action = "Index" }
        );

        app.Run();
    }
}