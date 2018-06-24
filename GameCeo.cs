using System;
using System.Collections.Generic;
namespace MyGame
{
    public class GameCeo
    {
        //
        /// <summary>
        /// The game ceo manages all the game manages
        ///
        /// </summary>
        private static GameCeo gameCeo= null;
 
        private List<GameManagerObj> _gameManagers = new List<GameManagerObj> ();
        //
        //
        private GameCeo ()
        {
            _gameManagers.Add (GameSceneManager.GetInstance());
            _gameManagers.Add (EnmeyManager.GetInstance());
            _gameManagers.Add (PlayerManager.GetInstance());
           _gameManagers.Add (BulletManager.GetInstance());
           _gameManagers.Add (PowerUpsManager.GetInstance());
           _gameManagers.Add (new CollisonManager ());

        }
        //
        //
        public static GameCeo GetInctance(){
            if(gameCeo==null){

                gameCeo = new GameCeo ();
            } 
                return gameCeo;  
        }
        //
        // will go over each manager in managers list and ask them to execute
        public void Execute(){
            foreach(GameManagerObj manager in _gameManagers){
                manager.Execute ();   
            }
            
        }
        //
        /// <summary>
        /// Adds the game manager to list
        /// </summary>
        /// <param name="obj">Object.</param>
        public void AddManager(GameManagerObj obj){
            _gameManagers.Add (obj);
        }
    }
}
