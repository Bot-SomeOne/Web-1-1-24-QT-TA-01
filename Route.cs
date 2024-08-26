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
         * Add a route
         * Namespace default
         * Controller: Student
         */
        app.MapControllerRoute(
            name: "student",
            pattern: "{controller=Student}/{action=Index}/{id?}",
            defaults: new { controller = "Student", action = "Index" }
        );

        /**
         * Add a route for student/index to admin/student/list
         */
        app.MapControllerRoute(
            name: "studentIndex",
            pattern: "admin/student/list/{id?}",
            defaults: new { controller = "Student", action = "Index" }
        );

        /**
         * Add a route for student/create to admin/student/add
         */
        app.MapControllerRoute(
            name: "studentCreate",
            pattern: "admin/student/add/{id?}",
            defaults: new { controller = "Student", action = "Create" }
        );

        /**
         * Add a route for BufferedFileUploadController
         */
        app.MapControllerRoute(
            name: "upload small file",
            pattern: "upload/image/",
            defaults: new { controller = "BufferedFileUpload", action = "Index" }
        );
    }
}