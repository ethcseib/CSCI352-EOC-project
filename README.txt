Names: Ethan Seiber, Hunter Haislip and Jamel Warren
Purpose: To create a game that is entertaining and of quality.
Files Needed: BurningChoices code folder
How to run: Open the .sln in Visual Studio or run the .exe file.
Challenges: Collision checking was hard and was a problem for the longest time
	Then the story implementation was difficult because of the amount of 
	time it takes to implement.
Design Decisions: We used two design patterns. The abstract factory pattern
	and the observer pattern
Bugs: If you walk to corners of the screen you can Walk out of bounds of the 
	game. In level 1 if you save the lady you can still collect the money 
	off the ground adding it to your inventory. When you beat the game a 
	message pops up telling you that you beat it; however, if you were 
	running through the level or if you press a button while this message
	is up it modifies the code that is pulled up behind the message 
	window potentially breaking the game from being playable going
	forward until fixed. If you complete the mission in a level and close
	the window instead it will pop up the next level like you walked 
	through a door to advance in levels. This is because of how the story
	is implemented.


What was Accomplished: We finished the project with the majority of the 
	goals we set out to accomplish. We have a branching story line
	with multiple endings. We implemented several levels for the player 
	to enjoy; however, we didn't get the save system finished or the pause menu 
	quit to work. The save prints your place in the story to a .txt file
	and loads the appropriate place in the story; however, you cannot 
	advance the story from the save it just closes the game.

If we had more time: We would spend the time smoothing out the bugs as well 
	as reaching our other unreached goals. These including the save 
	system and the quit in the pause menu.