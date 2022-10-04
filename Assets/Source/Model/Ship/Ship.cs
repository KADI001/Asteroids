using System;
using UnityEngine;

namespace Assets.Source.Model.Ship
{
    public class Ship : Transformable
    {
        public Ship(Vector2 position, float rotation) : base(position, rotation)
        {
        }

        public void Rotate(float direction, float delta)
        {
            if (direction == 0)
                throw new ArgumentException("Rotation direction is zero");

            direction = Mathf.Clamp(direction, -1, 1);

            Rotate(direction * delta);
        }
    }
}