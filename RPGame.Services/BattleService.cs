using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;
using System.Data.SqlClient;

namespace RPGame.Services
{
    public class BattleService
    {
        string connectionString = @"Data Source=ICT-202-08\SQL2019DEV;Initial Catalog=RPGame;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void RegisterBattle(Hero hero, Monster monster, bool hasHeroWon)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Battle (HeroName, MonsterName, HasHeroWon) VALUES (@HeroName, @MonsterName, @HasHeroWon);";
                    command.Parameters.AddWithValue("HeroName", hero.Name);
                    command.Parameters.AddWithValue("MonsterName", monster.Name);
                    command.Parameters.AddWithValue("HasHeroWon", hasHeroWon);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
