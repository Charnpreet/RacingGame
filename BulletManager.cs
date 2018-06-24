using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// Bullet manager manages player bullets ATOM
    /// </summary>
    public class BulletManager :GameManagerObj
    {
        private List<PlayerBullet> _playerBullets = new List<PlayerBullet> ();
        private static int _counter = 0;
        private static BulletManager bulletManager = null;
        Timer playerTimer = new Timer ();
        private float playerTimeInteveral = 80f;

        private  BulletManager ()
        {
           playerTimer.Start ();
        }
        //
        //
        // return player bullets as a list
        public List<PlayerBullet> PlayerBulletList (){
            return _playerBullets;
        }


        public static BulletManager GetInstance(){
            if(_counter==0){
                bulletManager = new BulletManager ();
                _counter++;
            }
            return bulletManager;
        }

        //
        /// <summary>
        /// ask the bulets to Draw itself on the screen
        /// </summary>
        //
        private void Draw ()
        {
            if(_playerBullets.Count>0){
                foreach (PlayerBullet b in _playerBullets) {
                    b.Draw ();
                }
            }

        }
        //
        //
        /// <summary>
        /// Execute draw and update method
        /// </summary>
        public override void Execute ()
        {
            Draw ();
            Update ();
        }
        //
        //
        /// <summary>
        ///calls player timer cunter na player update method
        /// </summary>
        private void Update ()
        {
            PlayerTimerCounter ();
            PlayerBulletUpdate ();
 
        }
       /// <summary>
        ///  ask the bulets to updates their current state itself 
       /// </summary>
        private void PlayerBulletUpdate(){
            if (_playerBullets.Count > 0) {
                foreach (PlayerBullet b in _playerBullets) {
                    b.Update ();
                }
                RemovePlayerBullets ();
            }
        }
        //    
        //
        /// <summary>
        /// Players the timer counter used to create new player bullets
        /// </summary>
        private void PlayerTimerCounter ()
        {
            float timeElapsed = playerTimer.Ticks;
            if (timeElapsed >= playerTimeInteveral) {
                PlayerTimesUp ();
                playerTimer.Reset ();
            }
        }

        //
        /// <summary>
        /// Removes the player bullets.
        /// </summary>
        //
        private void RemovePlayerBullets ()
        {
            for (int i = _playerBullets.Count - 1; i >= 0; --i){
                if(_playerBullets[i].Health<1){
                    _playerBullets.Remove (_playerBullets [i]);
                }
            }

        }
        //
        // it will be called to add bullets at players x and y location
        private void PlayerTimesUp(){
            AddPlayerBullet (UtilityFunctions.CreatePlayerBullets ());
        }
       
        //
        // add bullet to player list
        private void AddPlayerBullet(PlayerBullet playerBullet){
            _playerBullets.Add (playerBullet);
        }
    }
}
