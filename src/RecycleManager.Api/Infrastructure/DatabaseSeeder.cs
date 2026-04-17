using RecycleManager.Api.Domain;

namespace RecycleManager.Api.Infrastructure;
public static class DatabaseSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Materials.Any())
        {
            db.Materials.Add(new Material { Name = "Plástico PET", Category = "Plástico", IsRecyclable = true });
            db.Materials.Add(new Material { Name = "Papel", Category = "Papel", IsRecyclable = true });
            db.SaveChanges();
        }
    }
}
