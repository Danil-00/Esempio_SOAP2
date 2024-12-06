using Esempio_SOAP2.ServizioSOAP;
using SoapCore;

namespace Esempio_SOAP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ICalcolatrice, Calcolatrice>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ICalcolatrice>("/ServiceCalcolatrice.wsdl",
                    new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run();
        }
    }
}