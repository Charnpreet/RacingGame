using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    //
    /// <summary>
    /// Game menu controller controlls the menu of the game
    /// </summary>
    public static class GameMenuController
    {

        private static readonly string [] _menuStructure = new string [] { "PLAY", "SCORE" };

        private const int MENU_TOP = 730;
        private const int MENU_LEFT = 100;
        private const int MENU_GAP = 20;
        private const int BUTTON_WIDTH = 60;
        private const int BUTTON_HEIGHT = 20;
        private const int BUTTON_SEP = BUTTON_WIDTH + MENU_GAP;
        //    //
        //    // after clicking this button
        //    // user should be able to play the game
        //    //
        private const int MAIN_MENU_PLAY_BUTTON = 0;
        //
        // after clicking this button it should display list of scores
        private const int MAIN_MENU_TOP_SCORES_BUTTON = 1;
        //
        /// <summary>
        /// this will quit the game 
        /// </summary>



        private const int TEXT_OFFSET = 0;
        private static readonly Color MENU_COLOR = Color.Black;
        private static readonly Color HIGHLIGHT_COLOR = Color.Blue;
        //
        /// <summary>
        /// Handles the main menu input.
        /// </summary>
        // this will handle menu input 
        public static void HandleMainMenuInput ()
        {
            HandleMenuInput (0, 0);
        }
        //
        //
        /// <summary>
        /// Handles the menu input.
        /// </summary>
        /// <returns><c>true</c>, if menu input was handled, <c>false</c> otherwise.</returns>
        /// <param name="level">Level.</param>
        /// <param name="xOffset">X offset.</param>
        private static bool HandleMenuInput ( int level, int xOffset)
        {
            if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
                int i = 0;
                for (i = 0; i <= _menuStructure.Length - 1; i++) {
                    //IsMouseOver the i'th button of the menu
                    if (IsMouseOverMenu (i, level, xOffset)) {
                        PerformMenuAction (i);
                        return true;
                    }
                }
            }

            return false;
        }
        //
        //
        /// <summary>
        /// Ises the mouse over menu.
        /// </summary>
        /// <returns><c>true</c>, if mouse over menu was ised, <c>false</c> otherwise.</returns>
        /// <param name="button">Button.</param>
        /// <param name="level">Level.</param>
        /// <param name="xOffset">X offset.</param>
        private static bool IsMouseOverMenu (int button, int level, int xOffset)
        {
            int btnTop = MENU_TOP - (MENU_GAP + BUTTON_HEIGHT) * level;
            int btnLeft = MENU_LEFT + BUTTON_SEP * (button + xOffset);

            return UtilityFunctions.IsMouseInRectangle (btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT);
        }
   
        //
        /// <summary>
        /// Performs the menu action.
        /// </summary>
        /// <param name="button">Button.</param>
        private static void PerformMenuAction (int button)
        {
                PerformMainMenuAction (button);
        }

        /// <summary>
        /// Performs the main menu action.
        /// </summary>
        /// <param name="button">Button.</param>
        private static void PerformMainMenuAction (int button)
        {
            switch (button) {
            case MAIN_MENU_PLAY_BUTTON:
                GameController.AddNewState (GameStates.Playing);
                break;
            case MAIN_MENU_TOP_SCORES_BUTTON:
                GameController.AddNewState (GameStates.HighScore);
                break;
            }
        }

        //
        //
        // Draw menu
        public static void DrawMenu ()
        {
            Bitmap bitmap = GameResources.GameMenuBackgroundBitmap ("main_page");
            SwinGame.DrawBitmap (bitmap, 0, 0);
            DrawButtons ();
        }
        //
        // Draws buttons
        public static void DrawButtons ()
        {
            DrawButtons ( 0, 0);
        }
        //
        // method over loading 
        public static void DrawButtons (int level, int xoffset)
        {
            int btnTop = 0;
            btnTop = MENU_TOP - (MENU_GAP + BUTTON_HEIGHT) * level;
            int i = 0;
            for (i = 0; i <= _menuStructure.Length - 1; i++) {
                int btnLeft = 0;
                btnLeft = MENU_LEFT + BUTTON_SEP * (i + xoffset);
                SwinGame.FillRectangle (MENU_COLOR, btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT);
                SwinGame.DrawText (_menuStructure [i], Color.White, btnLeft, btnTop);
                if (SwinGame.MouseDown (MouseButton.LeftButton) & IsMouseOverMenu (i, level, xoffset)) {
                    SwinGame.DrawRectangle (HIGHLIGHT_COLOR, btnLeft, btnTop, BUTTON_WIDTH - 10, BUTTON_HEIGHT);
                }
            }
        }
    }

}
