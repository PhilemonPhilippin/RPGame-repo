using RPGame.Entities.Characters.Heroes;
using RPGame.Entities.Characters.Monsters;
using System.Data.SqlClient;

namespace RPGame.Services
{
    public class BattleService
    {
        string connectionString = @"Data Source=DESKTOP-BM3GQ1I;Initial Catalog=RPGame;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void RegisterBattle(IHero hero, IMonster monster, bool hasHeroWon)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Battle (HeroName, MonsterName, HasHeroWon, HeroId, BattleTime) VALUES (@HeroName, @MonsterName, @HasHeroWon, @HeroId, @BattleTime);";
                    command.Parameters.AddWithValue("HeroName", hero.Name);
                    command.Parameters.AddWithValue("MonsterName", monster.Name);
                    command.Parameters.AddWithValue("HasHeroWon", hasHeroWon);
                    command.Parameters.AddWithValue("HeroId", hero.Id);
                    command.Parameters.AddWithValue("BattleTime", DateTime.Now);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
