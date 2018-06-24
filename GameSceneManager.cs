using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
    //
    /// <summary
    /// Game scene manager manges scene class
    /// </summary>
	public class GameSceneManager : GameManagerObj
    {
        List<Scene> _scenes = new List<Scene> ();
        private static int _counter = 0;
        private static GameSceneManager gameSceneManager= null;
        Timer timer = new Timer ();
        private float timeInteveral = 500f;


        private GameSceneManager ()
        {
            timer.Start ();
            Point2D point2D = new Point2D ();
            point2D.X = 0;
            point2D.Y = 0;
            _scenes.Add (new Scene (point2D));

        }
        //
        //
        public static GameSceneManager GetInstance(){
            if(_counter==0){
                gameSceneManager = new GameSceneManager ();
            }
            return gameSceneManager;
        }

        /// <summary>
        /// Execute local timer draw and update methods
        /// </summary>
        public override void Execute ()
        {
            TimerCounter ();
            Draw ();
            Update ();
           
        }
        /// <summary>
        /// call scene obj to draw on the screen
        /// </summary>
        private void Draw(){
            foreach (Scene s in _scenes) {
                s.Draw ();
                s.Update ();
            }
        }
        /// <summary>
        /// Update scene obj
        /// </summary>
        private void Update(){
            foreach (Scene s in _scenes) {
                s.Update ();
            }
            SceneUpdate ();
        }

        private void SceneUpdate ()
        {
            for (int i = _scenes.Count - 1; i >= 0; --i) {
                if (_scenes [i].Health < 1) {
                    _scenes.Remove (_scenes [i]);
                }
            }
        }
        //
        //
        /// <summary>
        /// Adds the scene obj to list
        /// </summary>
        /// <param name="scene">Scene.</param>
        public void AddScene(Scene scene){
            _scenes.Add (scene);
        }
        //
        /// <summary>
        /// Timers used to create scene object
        ///
        /// </summary>
        private void TimerCounter ()
        {
            float timeElapsed = timer.Ticks;
            if (timeElapsed >= timeInteveral) {
                TimesUp ();
                timer.Reset ();
            }
        }
        /// <summary>
        /// Timeses up make calls to ADDscene method
        /// </summary>
        private void TimesUp (){
            AddScene (UtilityFunctions.CreateBackGround ());
        }
    }
}
