using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    //
    /// <summary>
    /// Power ups manager is class which manages powerup class
    /// 
    /// </summary>
    public class PowerUpsManager:GameManagerObj
    {
        /// <summary>
        /// The power ups has list which store which different types of powerup objects 
        ///
        /// </summary>
        private List<PowerUps> _powerUps = new List<PowerUps> ();
        private static int _counter = 0;
        private static PowerUpsManager powerUpsManager = null;
        //
        /// <summary>
        /// The timer is been used to call powerup class object after every few seconds
        /// </summary>
        Timer timer = new Timer ();
        private float timeInteveral = 10000.40f;
        //
        //

        private PowerUpsManager ()
        {
            timer.Start ();
        }
        //
        //
        /// <summary>
        /// Gets the instance of powerup class
        /// </summary>
        /// <returns>The instance.</returns>
        public static PowerUpsManager GetInstance(){
            if(_counter==0){
                _counter++;
                powerUpsManager = new PowerUpsManager ();
            } 
                return  powerUpsManager;   
        }
        //
        //
        /// <summary>
        /// Draw _powerups on the screen
        /// </summary>
        private void Draw ()
        {
            if (_powerUps.Count > 0) {
                foreach (PowerUps p in _powerUps) {
                    p.Draw ();
                }
            }
        }
        //
        /// <summary>
        /// Execute calls private update and draw methods
        /// </summary>
        public override void Execute ()
        {
            Draw ();
            Update ();
        }
        //
        /// <summary>
        /// Updates powerups
        /// </summary>
        private void Update ()
        {
            TimerCounter ();
            if(_powerUps.Count>0){
                foreach(PowerUps p in _powerUps){
                    p.Update ();
                }
                PowerUpUpdate ();
            }
        }
        /// <summary>
        /// Powers up update check if powerup object position is of the screen
        /// it removes it from the list
        /// </summary>
        //
        //
        private void PowerUpUpdate ()
        {
            for (int i = _powerUps.Count - 1; i >= 0; --i) {
                if (_powerUps [i].Health < 1) {
                    _powerUps.Remove (_powerUps [i]);
                }
            }
        }
        //
        /// <summary>
        /// returns <list of Powerups
        /// </summary>
        /// <returns>The ups.</returns>
        public List<PowerUps> PowerUps(){
            return _powerUps;
        }
     
        //
        // 
        /// <summary>
        /// used to add powerups to the list
        /// </summary>
        /// <param name="powerUps">Power ups.</param>
        private void AddPowerUps(PowerUps powerUps){
            _powerUps.Add (powerUps);
        }
        //
        //
        /// <summary>
        /// this compares the time if condition matches calls another method and reset the timer
        /// </summary>
        private void TimerCounter ()
        {
            float timeElapsed = timer.Ticks;
            if (timeElapsed >= timeInteveral) {
                TimesUp ();
                timer.Reset ();
            }
        }
        //
        //
        //
        /// <summary>
        /// Timeses up is used to call ADDpowerup method
        /// </summary>
        private void TimesUp ()
        {
            AddPowerUps (UtilityFunctions.CreatePowerUps ());
        }

    }
}
