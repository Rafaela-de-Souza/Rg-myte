using MyTe.Models.Contexts;

namespace MyTe.Models.Startup
{    public class DbInitializer
    {
        public static void Initialize(MyTeContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
