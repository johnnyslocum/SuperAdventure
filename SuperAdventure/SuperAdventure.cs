using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            //Location location = new Location(1, "Home", "This is your house.");
            //location.ID = 1;
            //location.Name = "Home";
            //location.Description = "This is your house.";

            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items?
            if (newLocation.ItemRequiredToEnter != null)
            {
                //See if the player has the required item in their inventory.
                bool playerHasRequiredItem = false;

                foreach (InventoryItem ii in _player.Inventory)
                {
                    if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        //We found the required item.
                        playerHasRequiredItem = true;
                        break; //Exits out of the foreach loop.
                    }
                }

                if (!playerHasRequiredItem)
                {
                    //WE didn't find the required item in their inventory, so display a message and stop trying to move.
                    rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name +
                                        " to enter this location." + Environment.NewLine;
                    return;
                }
            }

            //Update the player's current location.
            _player.CurrentLocation = newLocation;

            //Show/Hide available movement buttons.
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnWest.Visible = (newLocation.LocationToWest != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);

            //Display current location and description.
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            //Completely heal the player.
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            //Update hit points in UI.
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            //Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                //See if the player already has the quest, and if they've completely it.
                bool playerAlreadyHasQuest = false;
                bool playerAlreadyCompletedQuest = false;

                foreach (PlayerQuest playerQuest in _player.Quests)
                {
                    if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
                    {
                        playerAlreadyHasQuest = true;

                        if (playerQuest.IsCompleted)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }
                }

                //See if the player already has the quest.
                if (playerAlreadyHasQuest)
                {
                    //If the player has not completed the quest yet.
                    if (!playerAlreadyCompletedQuest)
                    {
                        //See if the player has all the items needed to complete the quest.
                        bool playerHasAllItemsToCompleteQuest = true;

                        foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                        {
                            bool foundItemInPlayersInventory = false;

                            //Check each item in the player's inventory, to see if they have it, and enough of it.
                            foreach (InventoryItem ii in _player.Inventory)
                            {
                                //The player has this item in their inventory.
                                if (ii.Details.ID == qci.Details.ID)
                                {
                                    foundItemInPlayersInventory = true;

                                    if (ii.Quantity < qci.Quantity)
                                    {
                                        //The player does not have enough of this item to complete the quest.
                                        playerHasAllItemsToCompleteQuest = false;

                                        //There is no reason to continue checking for the other quest completion items.
                                        break;
                                    }

                                    //We found the item, so don't check the rest of the player's inventory.
                                    break;
                                }
                            }

                            //If we didn't find the required item, set our variable and stop looking for other items.
                            if (!foundItemInPlayersInventory)
                            {
                                //The player does not have this item in their inventory.
                                playerHasAllItemsToCompleteQuest = false;

                                //There is no reason to continue checking for the other quest completion items.
                                break;
                            }
                        }

                        //The player has all items required to complete the quest.

                        /*
                         * 
                         * 
                         * 
                         * I Left off here!!!!!!!!!!!!!!!!!!!!!!! lesson 16.1
                         * 
                         * 
                         * 
                         * 
                         * 
                         * */

                        
                    }
                }
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }
    }
}
