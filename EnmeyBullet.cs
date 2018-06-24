using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    //
    /// <summary>
    /// Enmey bullet class manages enmie bullet
    /// </summary>
    public class EnmeyBullet : Bullet, ICollidableWith<Player>
    {
        public EnmeyBullet (Point2D point2D): base(point2D)
        {
            Bitmap = SwinGame.LoadBitmap ("b.png");
        }
        //
        /// <summary>
        /// Icollided the specified _iCollidableWith.
        /// check if it hads collided with playe or not
        /// </summary>
        /// <returns>The icollided.</returns>
        /// <param name="_iCollidableWith">I collidable with.</param>
        //
        public bool Icollided (List<Player> _iCollidableWith)
        {
            foreach (Player p in _iCollidableWith) {
                if (SwinGame.BitmapCollision (Bitmap, point2D, p.Bitmap, p.Point2D)) {
                    p.Health -= 4;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update itself
        /// </summary>
        //
        public override void Update ()
        {
            this.point2D.Y += 10;
            if (this.Point2D.Y > SwinGame.ScreenWidth ()) {
                this.Health = 0;
            }
        }
       
    }
}
