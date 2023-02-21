namespace FootballService.Models
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
