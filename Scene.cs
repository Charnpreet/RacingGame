using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{//
    /// <summary>
    /// Scene is used for game background 
    /// ATOM only has one background, which loop every certain seconds
    /// </summary>
	public class Scene : gameObject
    {
        Point2D point2D;
        Bitmap bitmap;
        int health;
        public Scene (Point2D _point2D)
        {
            health = 100;
            point2D = _point2D;
            bitmap = GameResources.GameBackground ("map"); 
        }
        //
        /// <summary>
        /// Gets or sets the point2D of BACKGROUND
        /// </summary>
        /// <value>The point2 d.</value>
        public override Point2D Point2D { 
            get{
                return point2D;
            }
            set{
                point2D = value;
            }
        }
        //
        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        public override Bitmap Bitmap { 
            
            get{
                return bitmap;
            }
            set{
                bitmap = value;
            } 
        }
        //
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>The health.</value>
        public override int Health {
            get{
                return health;
            }
            set{
                health = value;
            }
        }

        /// <summary>
        /// Draw scene bitmap on the screen
        /// </summary>
        public override void Draw ()
        {
            SwinGame.DrawBitmap (bitmap, Point2D.X, Point2D.Y);
          
        }
        //
        /// <summary>
        /// Update this  objects state
        /// </summary>
        public override void Update ()
        {
            point2D.Y += 5;
            if(point2D.Y>=SwinGame.ScreenHeight()){
                this.Health = 0;
            }
        }
    }
}
