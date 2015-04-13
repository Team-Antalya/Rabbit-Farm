using RabbitFarm.Data;
using RabbitFarm.Data.Migrations;

namespace RabbitFarm.Console
{
    using Models;

    public class Program
    {
        public static void Main()
        {
            new Configuration().Seeder();
        }
    }
}
