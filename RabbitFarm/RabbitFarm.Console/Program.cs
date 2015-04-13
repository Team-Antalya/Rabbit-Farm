namespace RabbitFarm.Console
{
    using RabbitFarm.Data.Migrations;

    public class Program
    {
        public static void Main()
        {
            new Configuration().Seeder();
        }
    }
}
