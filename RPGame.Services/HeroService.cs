using RPGame.Entities.Characters.Heroes;
using System.Data.SqlClient;

namespace RPGame.Services
{
    public class HeroService
    {
        string connectionString = @"Data Source=ICT-202-08\SQL2019DEV;Initial Catalog=RPGame;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void InsertHero(Hero hero)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Hero (Name, Stamina, MaxHealth, MaxMana, ManaPotion, Strength, Block, Experience, Level, Incarnation, Gold) output inserted.Id VALUES (@Name, @Stamina, @MaxHealth, @MaxMana, @ManaPotion, @Strength, @Block, @Experience, @Level, @Incarnation, @Gold);";
                    command.Parameters.AddWithValue("Name", hero.Name);
                    command.Parameters.AddWithValue("Stamina", hero.Stamina);
                    command.Parameters.AddWithValue("MaxHealth", hero.MaxHealth);
                    command.Parameters.AddWithValue("MaxMana", hero.MaxMana);
                    command.Parameters.AddWithValue("ManaPotion", hero.ManaPotion);
                    command.Parameters.AddWithValue("Strength", hero.Strength);
                    command.Parameters.AddWithValue("Block", hero.Block);
                    command.Parameters.AddWithValue("Experience", hero.Experience);
                    command.Parameters.AddWithValue("Level", hero.Level);
                    command.Parameters.AddWithValue("Incarnation", hero.Incarnation);
                    command.Parameters.AddWithValue("Gold", hero.Gold);
                    connection.Open();
                    hero.Id = (int) command.ExecuteScalar();
                }
            }
        }

        public void UpdateHero(Hero hero)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Hero SET Stamina = @Stamina, MaxHealth = @MaxHealth, MaxMana = @MaxMana, ManaPotion = @ManaPotion, Strength = @Strength, Block = @Block, Experience = @Experience, Level = @Level, Incarnation = @Incarnation, Gold = @Gold WHERE Id = @Id;";
                    command.Parameters.AddWithValue("Stamina", hero.Stamina);
                    command.Parameters.AddWithValue("MaxHealth", hero.MaxHealth);
                    command.Parameters.AddWithValue("MaxMana", hero.MaxMana);
                    command.Parameters.AddWithValue("ManaPotion", hero.ManaPotion);
                    command.Parameters.AddWithValue("Strength", hero.Strength);
                    command.Parameters.AddWithValue("Block", hero.Block);
                    command.Parameters.AddWithValue("Experience", hero.Experience);
                    command.Parameters.AddWithValue("Level", hero.Level);
                    command.Parameters.AddWithValue("Incarnation", hero.Incarnation);
                    command.Parameters.AddWithValue("Gold", hero.Gold);
                    command.Parameters.AddWithValue("Id", hero.Id);
                    connection.Open();
                    int linesModified = command.ExecuteNonQuery();
                    Console.WriteLine($"Lines modified : {linesModified}");
                }
            }
        }
    }
}
