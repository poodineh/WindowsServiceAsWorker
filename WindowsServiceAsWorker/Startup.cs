namespace WindowsServiceAsWorker
{
    public class Startup
    {
        public Startup()
        {

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", () => "Hello World!");
            });

        }
    }
}
