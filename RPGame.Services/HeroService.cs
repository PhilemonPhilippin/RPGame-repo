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
        public void DisplayHeroes()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Name, Level FROM Hero WHERE Incarnation > 0;";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Hero ID number : {reader["Id"]}, Hero name : {reader["Name"]}, Hero level : {reader["Level"]}");
                        }
                    }
                }
            }
        }
        public Hero GetHero(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                Hero hero = new Hero();
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Hero WHERE Id = @Id;";
                    command.Parameters.AddWithValue("Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            hero.Id = (int)reader["Id"];
                            hero.Name = (string)reader["Name"];
                            hero.Stamina = (double)reader["Stamina"];
                            hero.MaxHealth = (double)reader["MaxHealth"];
                            hero.Health = hero.MaxHealth;
                            hero.MaxMana = (double)reader["MaxMana"];
                            hero.Mana = hero.MaxMana;
                            hero.ManaPotion = (int)reader["ManaPotion"];
                            hero.Strength = (double)reader["Strength"];
                            hero.Damage = hero.Strength;
                            hero.Block = (double)reader["Block"];
                            hero.Experience = (double)reader["Experience"];
                            hero.Level = (int)reader["Level"];
                            hero.Incarnation = (int)reader["Incarnation"];
                            hero.Gold = (int)reader["Gold"];
                        }
                    }
                }
                return hero;
            }

        }
    }
}
