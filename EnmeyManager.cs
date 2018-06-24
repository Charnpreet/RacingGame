using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// Enmey manager manges all the enmies
    /// </summary>
    public class EnmeyManager :GameManagerObj
    {
        private List<Enmey> _enmies = new List<Enmey> ();
        Timer timer = new Timer ();
        private static int _counter = 0;
        private static EnmeyManager enmeyManager = null;
        private float timeInteveral = 1000;


        private EnmeyManager ()
        {
           timer.Start ();
          
        }
        //
        /// <summary>
        /// returns list of enmies
        /// </summary>
        /// <returns>The list.</returns>
        //
        public List<Enmey> EnmieList ()
        {
            return _enmies;
        }
        //
        //
        public static EnmeyManager GetInstance(){
            if(_counter==0){
                enmeyManager = new EnmeyManager ();
                _counter++;
            }
            return enmeyManager;
        }
        //
        //
        /// <summary>
        /// ask enmies which are in the list
        /// to draw themself on the screen
        /// </summary>
        private void Draw ()
        {
            if(_enmies.Count>0){
                foreach (Enmey e in _enmies) {
                    e.Draw ();
                }
            }

        }
        //
        //
        /// <summary>
        /// Execute call update and draw method
        /// </summary>
        public override void Execute ()
        {
            Draw ();
            Update ();
        }
        //
        // it will also checks if enmey health is zero 
        // then it will remove that enmey from the list
        private void Update ()
        {
           TimerCounter ();
            if (_enmies.Count > 0)
            {
             
                foreach (Enmey e in _enmies)
                {
                    e.Update ();
                  
                }
                EnmieUpdate ();
            }
        }
        //
        //remove enemy from the enmie list

        private void EnmieUpdate(){

            for (int i = _enmies.Count - 1; i >= 0; --i) {
                if (_enmies [i].Health < 1) {
                    UtilityFunctions.AddExplosion (_enmies [i].Point2D);
                    UtilityFunctions.PlaySoundEffects ("hit");
                    _enmies.Remove (_enmies [i]);
                }
            }
        }
 
        /// <summary>
        /// Timers the counter is used to create new enmies 
        /// </summary>
        //
        private void TimerCounter(){
            float timeElapsed = timer.Ticks;
            if (timeElapsed >= timeInteveral) {
                TimesUp ();
                timer.Reset ();
            }
        }
        //
        //
        /// <summary>
        /// Timeses up call add enmie method
        /// </summary>
        private void TimesUp ()
        {
            
            AddEnmie (UtilityFunctions.CreateEnmey ());
        }
        //
        //
        /// <summary>
        /// Adds the enmie to enmie list
        /// </summary>
        /// <param name="enmey">Enmey.</param>
        private void AddEnmie(Enmey enmey)
        {
                _enmies.Add (enmey);

        }
       
    }
}
