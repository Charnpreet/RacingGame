using System;
namespace MyGame
{
    /// <summary>
    /// Game manager object is abstract class which is inherited by all the managers
    /// </summary>
    public abstract class GameManagerObj
    {
        public GameManagerObj ()
        {
        }

        public abstract void Execute ();
    }
}
