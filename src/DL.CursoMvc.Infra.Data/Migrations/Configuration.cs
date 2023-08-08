using DL.CursoMvc.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace DL.CursoMvc.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CursoMvcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
