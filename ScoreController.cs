using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using SwinGameSDK;
namespace MyGame
{ //
    //
    /// <summary>
    ///  this class will handle all the score 
    // it will alow you to save score to file and read score from file
    // you can save player name as well with high score
    // it compare scores and will bring high score player on top
    /// </summary>
    public static class ScoreController
    {
        private static List<Score> _Scores = new List<Score> ();
        private const int NAME_WIDTH = 4; 
        private static string filePath = "/Users/charnpreet/desktop/racegame/highscores.txt";
        private const int SCORES_LEFT = 150;


        //
        /// <summary>
        /// /// The score structure is used to keep the name and
        /// score of the top players together.
        /// </summary>
        private struct Score : IComparable
        {
            public string name;
            public int score; 
            public int CompareTo (object obj)
            {
                if (obj is Score) {
                    Score other = (Score)obj;

                    return other.score - this.score;
                } else {
                    return 0;
                }
            }
        }
        //
        /// <summary>
        ///  Loads the scores from the highscores text file.
        /// </summary>

        public static void  LoadScores()
        {
            StreamReader input = default (StreamReader);
            input = new StreamReader (filePath);

            //Read in the # of scores
            int numScores = 0;
            numScores = Convert.ToInt32 (input.ReadLine ());

            _Scores.Clear ();

            int i = 0;

            for (i = 1; i <= numScores; i++) {
                Score s = default (Score);
                string line = null;

                line = input.ReadLine ();

                s.name = line.Substring (0, NAME_WIDTH);
                s.score = Convert.ToInt32 (line.Substring (4));
                _Scores.Add (s);
            }
            input.Close ();
        }
        //
        //
        /// <summary>
        /// Saves the scores back to the highscores text file.
        /// </summary>
        public static void SaveScores(){


            StreamWriter output = default (StreamWriter);
            output = new StreamWriter (filePath);
            output.WriteLine (_Scores.Count);

            foreach (Score s in _Scores) {
                output.WriteLine (s.name + s.score);
            }

            output.Close ();
        }
        /// <summary>
    /// Read the user's name for their high score.
    /// </summary>
    /// <param name="value">the player's score.</param>
        public static void ReadHighScore(int value){
            Bitmap bitmap=  GameResources.GameMenuBackgroundBitmap ("cool"); 
            SwinGame.DrawBitmap (bitmap, 0, 0);
            const int ENTRY_TOP = 700;

            if (_Scores.Count == 0){
                LoadScores ();
            }
                
            //is it a high score
            if (value > _Scores [_Scores.Count - 1].score) {
                Score s = new Score ();
                s.score = value;
                GameController.AddNewState (GameStates.HighScore);
                int x = 0;
                x = SCORES_LEFT + SwinGame.TextWidth (SwinGame.FontNamed ("cour.ttf", 14), "Name: ");
                SwinGame.StartReadingText (Color.WhiteSmoke, NAME_WIDTH, SwinGame.FontNamed ("cour.ttf", 14), x, ENTRY_TOP);
                while (SwinGame.ReadingText ()) {
                    SwinGame.ProcessEvents ();
                    DrawHighScore ();
                    SwinGame.FillRectangle (Color.Black, SCORES_LEFT, ENTRY_TOP, 100, 50);
                    SwinGame.DrawText ("Name: ", Color.White, SwinGame.FontNamed ("cour.ttf", 14), SCORES_LEFT, ENTRY_TOP);
                    SwinGame.RefreshScreen ();
                }
                s.name = SwinGame.TextReadAsASCII ();

                if (s.name.Length < 3) {
                    s.name = s.name + new string (Convert.ToChar (" "), 3 - s.name.Length);
                }

                _Scores.RemoveAt (_Scores.Count - 1);
                _Scores.Add (s);
                _Scores.Sort ();
                SaveScores ();

                GameController.EndCurrentState ();
            }  
        }
        //
        //
        /// <summary>
        /// Draws the high score on the screen
        /// </summary>
        public static void DrawHighScore(){
            const int SCORES_HEADING = 40;
            const int SCORES_TOP = 80;
            const int SCORE_GAP = 30;
            if (_Scores.Count == 0){
                LoadScores ();
            }
            //
            // change this for different background
            Bitmap bitmap=  GameResources.GameMenuBackgroundBitmap ("main_page1"); 
            SwinGame.DrawBitmap (bitmap, 0, 0);
            SwinGame.FillRectangle (Color.Black, SCORES_LEFT - 20, SCORES_TOP - 50, 150, 350);
            SwinGame.DrawRectangle (Color.Black, SCORES_LEFT - 20, SCORES_TOP - 50, 150, 350);
            SwinGame.DrawText ("   High Scores   ", Color.White, SCORES_LEFT, SCORES_HEADING);
            //For all of the scores
            int i = 0;
            for (i = 0; i <= _Scores.Count - 1; i++) {
                Score s = default (Score);

                s = _Scores [i];

                //for scores 1 - 9 use 01 - 09
                if (i < 9) {
                    SwinGame.DrawText (" " + (i + 1) + ":   " + s.name + "   " + s.score, Color.White, SCORES_LEFT, SCORES_TOP + i * SCORE_GAP);
                } else {
                    SwinGame.DrawText (i + 1 + ":   " + s.name + "   " + s.score, Color.White, SCORES_LEFT, SCORES_TOP + i * SCORE_GAP);
                }
            }
        }
        //
        /// <summary>
        /// Handles the game data input.
        /// </summary>
        public static void HandleGameDataInoput ()
        {
            if (SwinGame.KeyTyped (KeyCode.ReturnKey)) {
                GameController.EndCurrentState ();
            }
        }
    }
   
}
