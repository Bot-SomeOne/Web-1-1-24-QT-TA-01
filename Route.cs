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
        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}",
        //     defaults: new { controller = "Home", action = "Index" }
        // );

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
         * Add a route for Test 
         */
        app.MapControllerRoute(
            name: "Test",
            pattern: "{controller=Test}/{action=Index}/{id?}",
            defaults: new { controller = "Test", action = "Index" }
        );

        /**
         * Add a route for Learner
         */
        app.MapControllerRoute(
            name: "Learner",
            pattern: "admin/learner/list/{id?}",
            defaults: new { controller = "Learner", action = "Index" }
        );

        app.Run();
    }
}