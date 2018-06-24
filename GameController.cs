using System;
using System.Collections.Generic;
using System.Threading;
using SwinGameSDK;
namespace MyGame
{
    //
    // update the current state of the game
    public class GameController
    {
        
        private static Stack<GameStates> _state = new Stack<GameStates> ();
        static GameCeo gameCeo = GameCeo.GetInctance ();
        //
        /// <summary>
        /// /
        /// </summary>
        static GameController()
        {
            //_state.Push (GameStates.Quiting);
            _state.Push (GameStates.MainMenu);   
        }
        //
        // it will return the current screen display of the game
        public static GameStates CurrentDisplay{
            get{
                
                    return _state.Peek ();
            }
        }
        //
        //  drawing current state of the game

        public static void DrawScreen ()
        {
            switch (CurrentDisplay) {
            case GameStates.MainMenu:
                GameMenuController.DrawMenu ();
                break;
            case GameStates.HighScore:
                ScoreController.DrawHighScore ();
                break;
            case GameStates.Playing:
                gameCeo.Execute ();
                UtilityFunctions.DrawBackGround ();
                UtilityFunctions.DrawGameData ();
                break;
            case GameStates.Ending:
                GameEndingController.HandleEndOfGameInput ();
                break;
            case GameStates.EnterHighScore:
                Bitmap bitmap = GameResources.GameMenuBackgroundBitmap ("cool");
                SwinGame.DrawBitmap (bitmap, 0, 0);
                break;
        
            }

        }

    /// <summary>
    /// Handles the user view
    /// </summary>
    /// <remarks>
    /// Reads key and mouse input and converts these into
    /// actions for the game to perform. The actions
    /// performed depend upon the state of the game.
    /// </remarks>
        public static void HandleUserView(){
            switch(CurrentDisplay){
            case GameStates.MainMenu:
                GameMenuController.HandleMainMenuInput ();
                break; 
            case GameStates.HighScore:
                ScoreController.HandleGameDataInoput ();
                break;
            case GameStates.Playing:
                SwinGame.ChangeScreenSize (800, 750);
                break;
            case GameStates.Ending:
                SwinGame.ChangeScreenSize (500, 750);
                GameEndingController.DrawEndOfGame ();
                break;
            case GameStates.EnterHighScore:
                SwinGame.ChangeScreenSize (500, 750);
                break;
            case GameStates.Quiting:
                SwinGame.ChangeScreenSize (500, 750);
                GameMain.close = true;
                break;
            }
        }
        /// <summary>
    /// Move the game to a new state. The current state is maintained
    /// so that it can be returned to.
    /// </summary>
    /// <param name="state">the new game state</param>
        public static void AddNewState (GameStates state)
        {
            _state.Push (state);
        }

        /// <summary>
    /// Ends the current state, returning to the prior state
    /// </summary>
        public static void EndCurrentState() 
        {
            _state.Pop();
        }
        /// <summary>
    /// End the current state and add in the new state.
    /// </summary>
    /// <param name="newState">the new state of the game</param>
        public static void SwitchState (GameStates newState)
        {
            EndCurrentState ();
            AddNewState (newState);
        }
         
    }
}
