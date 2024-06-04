using inventoryApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace inventoryApiRest.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Buscar si ya existen usuarios
                if (context.Login.Any())
                {
                    return; // Ya se ha realizado la inicialización
                }

                // Crear un usuario de ejemplo
                var passwordHash = BCrypt.Net.BCrypt.HashPassword("contraseña");
                context.Login.Add(new LoginModel { Username = "usuario", Password = passwordHash });
                context.SaveChanges();
            }
        }
    }
}