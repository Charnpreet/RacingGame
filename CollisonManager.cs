using System;
using System.Collections.Generic;
namespace MyGame
{
    //

    /// <summary>
    /// Collison manager manages collison detector class
    /// </summary>
	public class CollisonManager : GameManagerObj
    {
        //private static int _counter = 0;
        List<CollisionDetector> collisionDetectors = new List<CollisionDetector> ();
        public CollisonManager ()
        {
            collisionDetectors.Add (new CollisionDetector ());
        }

        public override void Execute ()
        {
            foreach(CollisionDetector c in collisionDetectors){
                c.CheckCollison ();
            }
        }

    }
}
