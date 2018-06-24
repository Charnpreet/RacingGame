using System;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// Collision detector manages all the collison b/w game objecs
    /// </summary>
    public class CollisionDetector
    {
		//
        //
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyGame.CollisionDetector"/> class.
        /// </summary>
        public CollisionDetector ()
        {
        }
      
        //
        // this will be used for used to check if player car has collided with rocket
        // it is not emplemented yet
        //private void CheckPlayerCollison(){

        //}
        ////
        //// this will be implemented to check if enmie bullet has collided with player or not
        private void CheckEnmieBulletCollsion (EnmeyManager enmey, PlayerManager playerManager)
        {
            foreach(Enmey e in enmey.EnmieList()){
                foreach(EnmeyBullet b in e.Bullets()){
                    if(b.Icollided(playerManager.PlayerList())){
                        b.Health = 0;
                    }
                }
            }
        }
        //
        //
        /// <summary>
        /// Checks the player bullet collison with enmie
        /// </summary>
        /// <param name="enmey">Enmey.</param>
        /// <param name="bulletManager">Bullet manager.</param>
        private void CheckPlayerBulletCollison(EnmeyManager enmey,BulletManager bulletManager ){
            foreach(PlayerBullet b in bulletManager.PlayerBulletList ()){
                if(b.Icollided(enmey.EnmieList ())){
                    b.Health = 0;
                    Player.Score += 2;
                }
            }
        }
      
        /// <summary>
        /// Checks the power up collison with player
        /// </summary>
        /// <param name="playerManager">Player manager.</param>
        /// <param name="powerUpsManager">Power ups manager.</param>
        private void CheckPowerUpCollison(PlayerManager playerManager,PowerUpsManager powerUpsManager){
            foreach(PowerUps p in powerUpsManager.PowerUps ()){
                
                if(p.Icollided (playerManager.PlayerList ())){
                    p.Health = 0;
                }
            }

        }
      /// <summary>
      /// Checks the enmie collison with player
      /// </summary>
      /// <param name="enmey">Enmey.</param>
      /// <param name="playerManager">Player manager.</param>
        private void CheckEnmieCollison(EnmeyManager enmey, PlayerManager playerManager){
            foreach (Enmey e in enmey.EnmieList ()) {
                if (e.Icollided (playerManager.PlayerList ())) {
                    e.Health = 0;
                }

            }

        }
        //
        /// <summary>
        /// Checks the collison method calls all local collison methods
        /// </summary>
        //
        public void CheckCollison(){
            BulletManager bulletManager = BulletManager.GetInstance ();
            EnmeyManager enmey = EnmeyManager.GetInstance ();
            PlayerManager playerManager = PlayerManager.GetInstance ();
            PowerUpsManager powerUpsManager = PowerUpsManager.GetInstance ();
            CheckEnmieCollison (enmey, playerManager);
            CheckPowerUpCollison (playerManager,powerUpsManager);
            CheckPlayerBulletCollison (enmey,bulletManager);
            CheckEnmieBulletCollsion (enmey, playerManager);
        }
    }
        
}
