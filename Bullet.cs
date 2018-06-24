using System;
using SwinGameSDK;
namespace MyGame
{
    //
    /// <summary>
    /// Bullet base class for enmie and player bullets
    /// </summary>
    public class Bullet : gameObject
    {
        protected Point2D point2D;
        Bitmap bitmap;
        int health;
        public float dx = 0;
        public float dy = 0;
        //
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyGame.Bullet"/> class.
        /// </summary>
        /// <param name="point2D">Point2D is x and y conrdiantes.</param>
        //
        public Bullet (Point2D point2D)
        {
            health = 100;
            this.point2D = point2D;

        }
        //
        /// <summary>
        /// Gets or sets the point2 d.
        /// </summary>
        /// <value>The point2 dis x and y conrdiantes.</value>
        public override Point2D Point2D {
            get {
                return point2D;
            }
            set {
                Point2D = value;
            }
        }
        //
        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        //
        public override Bitmap Bitmap {
            get {
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
        //
        public override int Health {
            get{
                return health;
            } 
            set{
                health = value;
            }
        }
        //
        /// <summary>
        /// Draw current instance
        /// </summary>
        //
        public override void Draw ()
        {
            SwinGame.DrawBitmap (Bitmap, Point2D.X, Point2D.Y);
        }
        //
        /// <summary>
        /// Update this instance.
        /// it is been implemented by enmie and player bullet classes
        /// </summary>
        public override void Update ()
        {

        } 
    }
}
