using System;
using UnityEngine;

namespace Source.Model
{
    public abstract class Transformable : IDisposable
    {
        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }

        public Action Moved;
        public Action Rotated;
        public Action Destroyed;

        protected Transformable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector2.up;

        public void Move(Vector2 delta) => 
            MoveTo(Position + delta);

        public void MoveTo(Vector2 target)
        {
            Position = target;

            Moved?.Invoke();
        }

        public void Rotate(float delta) => 
            SetRotation(Rotation + delta);

        public void SetRotation(float rotation)
        {
            Rotation = rotation;

            Rotation = Mathf.Repeat(Rotation, 360f);

            Rotated?.Invoke();
        }

        public void Dispose() => 
            Destroyed?.Invoke();
    }
}