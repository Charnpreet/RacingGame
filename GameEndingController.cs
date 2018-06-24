using System;
using SwinGameSDK;
namespace MyGame
{
    public static class GameEndingController
    {
		/// <summary>
    /// Draw the end of the game screen message
    /// </summary>
    public static void DrawEndOfGame()
        {
            Bitmap bitmap = GameResources.GameMenuBackgroundBitmap ("crashed");
            SwinGame.DrawBitmap (bitmap, 0, 0);
            SwinGame.DrawText("Your car Has Been Destroyed By Your Enmies!", Color.Black, 30, 100);
    }
		/// <summary>
    /// Handle the input during the end of the game. Any interaction
    /// will result in it reading in the score.
    /// </summary>
    public static void HandleEndOfGameInput()
    {
            if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
                ScoreController.ReadHighScore (Player.Score);
                GameController.SwitchState (GameStates.Quiting);
            }
        }
    }
}
