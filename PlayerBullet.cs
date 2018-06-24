using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    /// <summary>
    /// Player bullet checking collison b/w player bullet and enemy
    /// </summary>
    public class PlayerBullet : Bullet, ICollidableWith<Enmey>
    {
        public PlayerBullet (Point2D point2D) : base (point2D)
        {
            Bitmap = SwinGame.LoadBitmap ("a.png");
        }

        //
        //
        /// <summary>
        /// Update this instance.
        /// </summary>
        public override void Update ()
        {
            this.point2D.Y -= 10;
            if (this.Point2D.Y < 0) {
                this.Health = 0;
            }
        }
        /// <summary>
        /// Icollided the specified _iCollidableWith
        /// it check if player has collided with enemie or not
        /// </summary>
        /// <returns>The icollided.</returns>
        /// <param name="_iCollidableWith">I collidable with.</param>
        public bool Icollided (List<Enmey> _iCollidableWith)
        {
            foreach (Enmey e in _iCollidableWith) {
                if (SwinGame.BitmapCollision (Bitmap, Point2D, e.Bitmap, e.Point2D)) {
                    e.Health -= 15;
                    return true;
                }
            }
            return false;
        }
    }
}
