using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    //
    //
    /// <summary>
    ///  player class manages player 
    /// </summary>
    public class Player : gameObject
    {
        Point2D point2D;
        Bitmap bitmap;
        int health;
        static int score = 0;
        public Player (Point2D _point2D)
        {
            health = 100;
            point2D = _point2D;
            bitmap = GameResources.GamePlayerImage ("charnP");
        }
        //
        //
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public static int Score{
            get{
                 return score;
            }
            set{
                score = value;
            }
        }
        //
        /// <summary>
        /// Gets or sets the point2 d.
        /// </summary>
        /// <value>The point2 d.</value>
        public override Point2D Point2D {
            get {
                return point2D;
            }
            set {
                Point2D = value;
            }
        }
        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        //
        public override Bitmap Bitmap {
            get {
                return bitmap;
            }

            set {
                bitmap = value;
            }

        }
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>The health.</value>
        //Player' health
        public override int Health { 
            get {
                return health;
            } 
            set{
                health = value;
            }
        }
        /// <summary>
        /// Draw this instance.
        /// </summary>
        // draws the player
        public override void Draw ()
        {
            SwinGame.DrawBitmap (Bitmap, Point2D.X, Point2D.Y);
        }


         /// <summary>
        //// updates player's locations
         /// </summary>

        public override void Update ()
        {
            this.point2D.Y -= .2f;
            if(this.point2D.Y <450){
                this.point2D.Y = 450;
            }
            if (SwinGame.KeyDown (KeyCode.LeftKey)) {
                this.point2D.X -= 20;
            }
         else if (SwinGame.KeyDown (KeyCode.RightKey)) {
                this.point2D.X += 20;
            }

            if(this.Point2D.X<50)
            {
                this.point2D.X = 50;
            }
            if(this.Point2D.X>SwinGame.ScreenWidth()-450)
            {
                this.point2D.X = SwinGame.ScreenWidth ()-450;

            }
            if(this.Health>99){
                health = 100;
            }
            if (this.health < 1) {
                GameController.SwitchState (GameStates.Ending);
            }
        }

       
    }
}
