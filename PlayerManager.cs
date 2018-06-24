using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// Player manager class manages player class
    /// </summary>
    public class PlayerManager:GameManagerObj
    {
        private List<Player> _player = new List<Player> ();
        private static int _counter = 0;
        private static PlayerManager playerManager = null;
        //
        /// <summary>
        /// 
        /// </summary>
        private PlayerManager ()
        {
            Point2D point2D = new Point2D ();
            point2D.X = 300;
            point2D.Y = 550;
            _player.Add (new Player(point2D));
        }
        //
        //
        /// <summary>
        /// Gets the instance of player manager class
        /// </summary>
        /// <returns>The instance.</returns>
        public static PlayerManager GetInstance(){
            if(_counter==0){
                playerManager = new PlayerManager ();
                _counter++;
            }
            return playerManager;
        }
        //
        /// <summary>
        /// Player'slist.
        /// </summary>
        /// <returns>The list.</returns>
        //
        public List<Player> PlayerList(){
            return _player;
        }
        //
        //
        /// <summary>
        /// Draw player on the screen
        /// </summary>
        private void Draw ()
        {
            if (_player.Count > 0) {
                foreach (Player p in _player) {
                    p.Draw ();
                }
            }
        }
        //
        /// <summary>
        /// Execute draw and update method
        /// </summary>
        public override void Execute ()
        {
            Draw ();
            Update ();
        }
        /// <summary>
        /// Update player objects in list
        /// </summary>
        private void Update ()
        {
            if(_player.Count>0){
                foreach(Player p in _player){
                    p.Update ();
                }
                PlayerUpdate ();
            }
        }
        //
        //
        /// <summary>
        /// Players the update removes the player from the player list
        /// </summary>
        private void PlayerUpdate ()
        {
            for (int i = _player.Count - 1; i >= 0; --i) {
                if (_player [i].Health < 1) {
                    _player.Remove (_player [i]);
                }
            }
        }

        /// <summary>
        /// add player to list
        /// </summary>
        /// <param name="player">Player.</param>
        //
        private void AddPlayer(Player player){
            _player.Add (player);
        }

    }
}
