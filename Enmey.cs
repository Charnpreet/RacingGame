using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    //
    //
    /// <summary>
    /// this class checking collsion between player and enmey car 
    ///used by enmie
    /// </summary>
    public class Enmey:gameObject, ICollidableWith<Player>
    {
        Point2D point2D;
        int health;
        Bitmap bitmap;
        private EnmieKind _kind;
        private List<EnmeyBullet> _enmeyBullets = new List<EnmeyBullet> ();
        Timer enmieTimer = new Timer ();
        private float enmieTimeInteveral = 400f;

        public Enmey (Point2D _point2D)
        {
            enmieTimer.Start ();
            health = 100;
            point2D = _point2D;
            _kind = (EnmieKind)SwinGame.Rnd (13); 
            bitmap = GameResources.GameImage (_kind.ToString ());
        }

        /// <summary>
        /// Gets or sets the point2 d.
        /// </summary>
        /// <value>The point2 d is X and Y cordinates of the Enmie.</value>
        public override Point2D Point2D
        {
            get{
                return point2D;
            } 
            set{
                Point2D = value;
            }
        }
        //
        //
        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
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
        /// <summary>
        /// Draws the builets from the bullet list
        /// </summary>
        private void DrawBuilets(){
            if(_enmeyBullets.Count>0){
                foreach (EnmeyBullet b in _enmeyBullets) {
                    b.Draw ();
                }
            }
        }
        //
        /// <summary>
        /// Draw current enmie and also calls draw bullet
        /// </summary>
        //
        public override void Draw ()
        {
            SwinGame.DrawBitmap (Bitmap, Point2D.X, Point2D.Y);
            UtilityFunctions.DrawGameData (this.Point2D, this.Health);
            DrawBuilets ();
        }
        //
        // it only checking if enemy car has collided with player car
        // 
        public bool Icollided (List<Player> _iCollidableWith)
        {
            foreach (Player p in _iCollidableWith) {
                if (SwinGame.BitmapCollision (Bitmap, point2D, p.Bitmap, p.Point2D)) {
                    p.Health -= 10;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// List of enmie bullets
        /// </summary>
        /// <returns>The bullets.</returns>
        public List<EnmeyBullet> Bullets(){
            return _enmeyBullets;
        }
        //
        //
        /// <summary>
        /// Bullets the update check bullet state
        /// </summary>
        private void BulletUpdate(){
            try {
                if (_enmeyBullets.Count > 0) {
                    foreach (EnmeyBullet b in _enmeyBullets) {
                        b.Update ();
                    }
                    RemoveEnmieBullets ();
                }
            } catch (NullReferenceException) {
                Console.WriteLine ("no bullets");
            }

        }
        ////
        ////
        /// used to create new bullet after certain time
        private void BulletTimerCounter ()
        {
            float timeElapsed = enmieTimer.Ticks;
            if (timeElapsed >= enmieTimeInteveral) {
                BulletTimesUp ();
                enmieTimer.Reset ();
            }
        }
        //
        // remove enmie bullets from the bullet list
        ////
        ////
        private void RemoveEnmieBullets(){
            for (int i = _enmeyBullets.Count - 1; i >= 0; --i) {
                if (_enmeyBullets [i].Health < 1) {
                    _enmeyBullets.Remove (_enmeyBullets [i]);
                }
            }
        }
        ////
        // it will be called to add bullets at enmey x and y location
        private void BulletTimesUp(){
            AddEnmieBullets (UtilityFunctions.CreateEnmieBullets());
        }
        ////
        ////it will add BULLET AT PLAYERS LOCATIONS
        private void AddEnmieBullets(EnmeyBullet bullet){
            _enmeyBullets.Add (bullet);   
        }
        /// 
        /// this will check if enmey location is greater than 
        ///  screen height it will Set the Health to Zero
        /// if 
        public override void Update ()
        {
            BulletTimerCounter ();
            BulletUpdate ();
            this.point2D.Y += 5;
            if(this.Point2D.Y>700){
                this.Health = 0;
            }
        }


       
    }
}
