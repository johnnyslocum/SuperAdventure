﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }

        public Weapon CurrentWeapon { get; set; }
        public Location CurrentLocation { get; set; }

        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; } 

        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level)
            : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                //There is no required item for this location, so return "true".
                return true;
            }

            //See if the player has the required for this location in their inventory.
            return Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Any(playerQuest => playerQuest.Details.ID == quest.ID);
        }

        public bool CompletedThisQuest(Quest quest)
        {
            return (from playerQuest in Quests where playerQuest.Details.ID == quest.ID select playerQuest.IsCompleted).FirstOrDefault();
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            //See if the player has all the items needed to complete the quest here.
            foreach (QuestCompletionItem qci  in quest.QuestCompletionItems)
            {

                //Check each item in the player's inventory, to see if they have it, and enough of it.
                if(!Inventory.Exists(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                {
                    return false;
                }
            }

            //If we got here then the player must have all the required items, and enough of them to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                
                if (item != null)
                {
                    //Subtract the quantity from the player's inventory that was needed to complete the quest.
                    item.Quantity -= qci.Quantity;
                    break;
                } 
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

            if (item == null)
            {
                //They didn't have the item, so add it to their inventory, with a quantity of one.
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                //They have the item in their inventory, so increase the quantity by 1.
                item.Quantity++;
            }
        }

        public void MarkQuestCompleted(Quest quest)
        {
            //Find the quest in the player's quest list.
            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);

            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
    }
}
