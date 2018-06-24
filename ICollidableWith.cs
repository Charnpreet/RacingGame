using System;
using System.Collections.Generic;
namespace MyGame
{
    /// <summary>
    /// Collidable with interface will be implemented by object which can collide with other objects
    /// </summary>
    public interface ICollidableWith<T>
    {
        /// <summary>
        /// Icollided the specified _iCollidableWith
        /// List of collidable objects will be passed 
        /// will vary obj to obj
        /// </summary>
        /// <returns>The icollided.</returns>
        /// <param name="_iCollidableWith">I collidable with.</param>
        bool Icollided(List<T> _iCollidableWith);
    }
}
