using System;
namespace MyGame
{
    //
    /// <summary>
    /// Different states of the game
    /// </summary>
    public enum GameStates
    {
        /// <summary>
        /// The main menu state used to view main menu of the game
        /// </summary>
		MainMenu,
        /// <summary>
        /// The high score state is used to diplay score on the screen
        /// </summary>
        HighScore,
        //
        /// <summary>
        /// The playing state where game state
        /// </summary>
        Playing,
        //
        /// <summary>
        /// The ending been called when player died
        /// </summary>
        Ending,
        EnterHighScore,
        //
        /// <summary>
        /// The quiting state quits the game 
        /// </summary>
        Quiting
    }
}
