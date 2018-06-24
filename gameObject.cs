using System;
using SwinGameSDK;
namespace MyGame
{
    /// <summary>
    /// Game object is abstract class which is inherited
    /// by game objects like player, enmie, powerup, bullet etc
    /// </summary>
    public abstract class gameObject
    {
      
        public gameObject ()
        {
        }
        public abstract void Draw ();
        public abstract void Update ();
        public abstract Point2D Point2D{
            get;
            set;
        }
    
        public abstract Bitmap Bitmap{
            get;
            set;
        }
        public abstract int Health{
            get;
            set;
        }
    }
}
