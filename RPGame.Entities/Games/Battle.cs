﻿namespace RPGame.Entities.Games
{
    public class Battle
    {
        public int Id { get; set; }
        public string HeroName { get; set; }
        public string MonsterName { get; set; }
        public bool HasHeroWon { get; set; }
        public int HeroId { get; set; }
        public DateTime BattleTime { get; set; }
    }
}
