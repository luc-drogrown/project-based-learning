using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        //public int CurrentHitPoints { get; set; }
        //public int MaximumHitPoints {  get; set; }
        public int Gold {  get; set; }
        public int ExperiencePoints { get; set; }
        public int Level {  get; set; }

        public Location CurrentLocation { get; set; }

        //lists
        public List<InventoryItem> Inventory {  get; set; }
        public List<PlayerQuest> Quests { get; set; }

        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            //set the lists to empty lists
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

        }
    }
}
