using Microsoft.AspNetCore.Authentication.Cookies;

namespace CookSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(opt =>
                            { // k�kten iitibaren gideceksen ba��na / koymal�s�n 
                                opt.LoginPath = "/Account/Login";
                                opt.LogoutPath = "/Account/Logout";
                                opt.AccessDeniedPath = "/Account/AccessDenied";
                                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);// kullan�c�n�n giri� s�reci (ubys)
                                opt.SlidingExpiration = true; // her i�lemde s�ren yenilenir (30 dk)
                                opt.Cookie.Name = "UserData";
                                opt.Cookie.HttpOnly = true; // eri�imler sadece http ile eri�ilir .
                                opt.Cookie.SameSite = SameSiteMode.Strict; // i�lemler sadece bu domain �zerinden yap�l�r.
                            });









            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            //tek rota (route) kullan�lacaksa bu kalmal�
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=contact}/{id?}");





            //biden fazla rota kullan�lacaksa bu �ekilde yaz�lmal�
            app.UseEndpoints(endpoints => {

            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"); //aRea varsa bunu kullan 

		   endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                       name:"iletisim",
                       pattern:"iletisim",
                       defaults: new {controller="Home",action="Contact" }
                    );


                endpoints.MapControllerRoute(
                    name:"yemek",
                    pattern:"Yemek/{numara:int}",
                    defaults: new {controller="Cook",action="Detail" }
                    );

                endpoints.MapControllerRoute(
                    name: "yemek2",
                    pattern: "Yemek/{ad:alpha}",
                    defaults: new { controller = "Cook", action = "Detail" }
                    );

                endpoints.MapControllerRoute(
                    name:"sabit-anasayfa",
                    pattern:"anasayfa",
                    defaults: new { controller="Home",action="Index" });

                endpoints.MapControllerRoute(
                   name: "Tarif",
                   pattern: "Tarif/{tip}/{no}",
                   defaults: new { controller = "Cook", action = "Detail2" }
                   );


			    
		

			});


            app.Run();
        }
    }
}
