using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        static public bool close = false;
        public static void Main ()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow ("GameMain", 500, 750);
           
            //SwinGame.ShowSwinGameSplashScreen();

            GameResources.LoadResources ();
 
            SwinGame.ClearScreen (Color.White);

            //Run the game loop
            while (false == close) {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents ();
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen (Color.Black);
                SwinGame.DrawFramerate (0,0);
                GameController.HandleUserView ();
                GameController.DrawScreen ();
                //Draw onto the screen
                SwinGame.RefreshScreen (60);
            }
        }
    }
}


/*


*/