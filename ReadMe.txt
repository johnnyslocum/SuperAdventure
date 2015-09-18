//This is the read me file for the SuperAdventure type along tutorial.

//9/9/15 (1)
added constructor to 'Location' class. Also had to recreate repo because the .git file mysteriously disappeared. Also renamed 'SuperAdventureReadMe.txt' to just 'ReadMe.txt' for faster access.

9/9/15 (2)
added constructor to 'Quest' class.

9/9/15 (3)
added constructors to 'Item' and 'Quest' classes.

9/9/15 (4)
added constructors to 'Weapon', 'Monster', 'Player' and 'LivingCreature' classes.

9/9/15 (5)
added some properties to 'Location' class and updated its constructor.

9/9/15 (6)
added a property to 'Quest' class.

9/10/15 (1)
added 'InventoryItem', 'PlayerQuest', 'QuestCompletion', and 'LootItem' classes. added a couple of IList<> properties to the  'Player' class and updated its constructor.

9/10/15 (2)
added IList<> properties to 'Quest' and 'Monster' classes and updated their constructors.

9/10/15 (3)
added and populated a 'World' class with a couple hundred lines of code for several methods setting up the locations and monsters and items.

9/10/15 (4)
added controls to the form.


9/10/15 (5)
added a 'RandomNumberGenerator' class.

9/10/15 (6)
worked on player movement in the 'SuperAdventure' class. Left off at lesson 16.1

9/15/15 (1)
finished up player movement in the 'SuperAdventure' class from lesson 16.1

9/15/15 (2)
refactored some functions from the 'SuperAdventure' and 'Player' classes from lesson 16.2.

9/15/15 (3)
refactored some more functions from the 'SuperAdventure' and 'Player' classes finishing up lesson 16.2.

9/16/15 (1)
did some more refactoring. finished lesson 16.3 filling in the functions for using potions and using weapons. Did some bug fixes. found some others. also found and fixed some mistakes in the source code that prevented game from working as intended. game not working fully as intended. movement in the game was wrong from missing source code. buttons that should have not been visible were visible and vice versa. Double checked my code against source code, and source code was incorrect. made some fixes, still working on others. movement in game is working properly but monsters are not spawning at all to complete the quests. 

9/18/2015 (1)
refactored several lines of code, mostly changes foreach loops into linq statements for better readability. Worked on fixing several bugs. Still have bugs regarding monsters not generating when going in to areas that should have monsters. Also data grid view tables in the UI are not populating properly. Double checked my code against the source code and all appears correct. Will probably just delete them and rewrite them to see if it is just a hiccup in Visual Studio.

9/18/15 (2)
fixed the dgv issue not populating properly on the UI. I had given the dgvQuests both values for quests and inventory. duh!