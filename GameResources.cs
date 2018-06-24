using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;
using SwinGameSDK;
namespace MyGame
{
    /// <summary>
    /// Game resources handles all the resources
    /// </summary>
    public static class GameResources
    {
        private static Dictionary<string, Bitmap> _images = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect> ();
        private static Dictionary<string, Bitmap> _backGroundImages = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, Bitmap> _powerups = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, Bitmap> _playerBitmaps = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, Bitmap> _bulletBitmaps = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, Bitmap> _menuBackGround = new Dictionary<string, Bitmap> ();
        private static Dictionary<string, Bitmap> _explosions = new Dictionary<string, Bitmap> ();
        private static Dictionary<String, Font> _fonts = new Dictionary<string, Font> ();

        //
        /// <summary>
        /// Loads the resources.
        /// </summary>
        public static void LoadResources(){
            LoadImages ();
        }
        /// <summary>
        /// Adds the bitmaps to _image <list
        /// which is been used by enmie classß
        /// </summary>
		private static void AddNewImages () //string imageName, string filename
        {
            _images.Add ("halima", SwinGame.LoadBitmap("halima.png"));
            _images.Add ("cherish",SwinGame.LoadBitmap ( "cherish.png"));
            _images.Add ("sahib",SwinGame.LoadBitmap ( "sahib.png"));
            _images.Add ("bigfella",SwinGame.LoadBitmap ( "bigfella.png"));
            _images.Add ("charn",SwinGame.LoadBitmap ( "charn.png"));
            _images.Add ("jo",SwinGame.LoadBitmap ( "jo.png"));
            _images.Add ("fatima",SwinGame.LoadBitmap ( "fatima.png"));
            _images.Add ("rabita",SwinGame.LoadBitmap ( "rabita.png"));
            _images.Add ("chowdery",SwinGame.LoadBitmap ( "chowdery.png"));
            _images.Add ("sky", SwinGame.LoadBitmap ("sky.png"));
            _images.Add ("kaylah",SwinGame.LoadBitmap ( "kaylah.png"));
            _images.Add ("richa",SwinGame.LoadBitmap ( "richa.png"));
            _images.Add ("amrit", SwinGame.LoadBitmap ("amrit.png"));

        }
        //
        // background for main game

		private static void AddNewBackground() //string imageName, string filename
        {
            _backGroundImages.Add ("map", SwinGame.LoadBitmap ("abc5.png"));         
        }
		//
        // this will load all the powerups
        // used by powerup class
        private static void AddNewPowerUps ()// 
        {
           
            _powerups.Add ("blackberry", SwinGame.LoadBitmap ("Blackberry.png"));
            _powerups.Add ("apricot", SwinGame.LoadBitmap ("Apricot.png"));
            _powerups.Add ("currant", SwinGame.LoadBitmap ("Currant.png"));
            _powerups.Add ("cherry", SwinGame.LoadBitmap ("Cherry.png"));
            _powerups.Add ("blueberry", SwinGame.LoadBitmap ("Blueberry.png"));
            _powerups.Add ("strawberry", SwinGame.LoadBitmap ("Strawberry.png"));
            _powerups.Add ("pomegrante", SwinGame.LoadBitmap ("Pomegranate.png"));
            _powerups.Add ("gooseberry", SwinGame.LoadBitmap ("Gooseberry.png"));
            _powerups.Add ("raspberry", SwinGame.LoadBitmap ("Raspberry.png"));
            
        }
        //
        // this will load player bitmaps, incase we need to add more than bitmap of player
        private static void AddNewPlayer () // string imageName, string filename
        {
            _playerBitmaps.Add ("charnP", SwinGame.LoadBitmap ("charnP.png"));

        }
        //
        // this will load bullets bitmaps, incase we need to add more than bitmap of bullets
        private static void AddNewBullet () //string imageName, string filename
        {
            _bulletBitmaps.Add ("b",  SwinGame.LoadBitmap ("b.png"));
            _bulletBitmaps.Add ("a", SwinGame.LoadBitmap ("a.png"));

        }
        //
        /// <summary>
        ///  this contains backgrounds for different states of the game
        /// </summary>
        private static void AddNewMainMenuBackGround(){
            _menuBackGround.Add ("main_page", SwinGame.LoadBitmap ("main_page.png"));
            _menuBackGround.Add ("main_page1", SwinGame.LoadBitmap ("main.png"));
            _menuBackGround.Add ("crashed", SwinGame.LoadBitmap ("carcrashed.png"));
            _menuBackGround.Add ("cool", SwinGame.LoadBitmap ("cool.png"));
            
        }
        //
        /// <summary>
        /// Adds the explosion.
        /// which is been used when ever enmie car get destroyed
        /// </summary>
        private static void AddExplosion(){
            _explosions.Add ("explosion0", SwinGame.LoadBitmap ("explosion0.png"));
        }
        //
        /// <summary>
        /// Adds the sound for game
        /// </summary>
        private static void AddSound(){
            _sounds.Add("hit",SwinGame.LoadSoundEffect("hit.wav"));
            _sounds.Add ("car", SwinGame.LoadSoundEffect ("car.wav"));
            _sounds.Add ("music", SwinGame.LoadSoundEffect ("backgroundmusic.wav"));
            _sounds.Add ("pick", SwinGame.LoadSoundEffect ("pick.wav"));
           
        }
		// loading images
        private static void LoadImages(){

            AddNewImages ();
            AddNewBullet ();
            AddNewPowerUps ();
            AddNewPlayer ();
            AddNewBackground ();
            AddNewMainMenuBackGround ();
            AddExplosion ();
            AddSound ();

        }
     
        /// <summary>
        /// Games the sound.
        /// </summary>
        /// <returns>The sound.</returns>
        /// <param name="sound">Sound.</param>
        public static SoundEffect GameSound (string sound)
        {
            return _sounds [sound];
        }
        //
        /// <summary>
        /// Games the explosions.
        /// </summary>
        /// <returns>The explosions.</returns>
        /// <param name="name">Name.</param>
        public static Bitmap GameExplosions(string name){
            return _explosions [name];
        }

        /// <summary>
        /// Games the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="name">Name.</param>
		// this will get an enmie images loaded in resources
        public static Bitmap GameImage(string name){
            return _images [name];
        }
        //
        /// <summary>
        /// Games the powerups.
        /// </summary>
        /// <returns>The powerups.</returns>
        /// <param name="name">Name.</param>
        // this will get an images loaded in resources
        public static Bitmap GamePowerups (string name)
        {
            return _powerups [name];
        }
        //
        /// <summary>
        /// Games the background.
        /// </summary>
        /// <returns>The background.</returns>
        /// <param name="name">Name.</param>
        // this will get an images loaded in resources
        public static Bitmap GameBackground (string name)
        {
            return _backGroundImages [name];
        }
        //
        /// <summary>
        /// Games the player image.
        /// </summary>
        /// <returns>The player image.</returns>
        /// <param name="name">Name.</param>
        // this will get an images loaded in resources
        public static Bitmap GamePlayerImage (string name)
        {
            return _playerBitmaps [name];
        }
        //
        /// <summary>
        /// Games the bullet image.
        /// </summary>
        /// <returns>The bullet image.</returns>
        /// <param name="name">Name.</param>
        // this will get an images loaded in resources
        public static Bitmap GameBulletImage (string name)
        {
            return _bulletBitmaps[name];
        }
        /// <summary>
        /// Games the menu background bitmap.
        /// </summary>
        /// <returns>The menu background bitmap.</returns>
        /// <param name="name">Name.</param>
		public static Bitmap GameMenuBackgroundBitmap(string name){
            return _menuBackGround[name];
        }
        //
        /// <summary>
        /// Releases the resources.
        /// </summary>
        public static void ReleaseResources(){
            
            foreach (Bitmap item in _images.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _powerups.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _playerBitmaps.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _backGroundImages.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _bulletBitmaps.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach(Bitmap item in _explosions.Values){
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _menuBackGround.Values) {
                SwinGame.FreeBitmap (item);
            }
            foreach (var item in _sounds.Values) {
                SwinGame.FreeSoundEffect (item);
            }
        }

           
    }
}
