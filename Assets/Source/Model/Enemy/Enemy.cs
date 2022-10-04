using System;
using UnityEngine;

namespace Assets.Source.Model.Enemy
{
    public abstract class Enemy : Transformable
    {
        public readonly float Velocity;

        public event Action<Enemy> Dead;

        protected Enemy(Vector2 position, float rotation, float velocity) : base(position, rotation) => 
            Velocity = velocity;

        public abstract int GetAward();

        public void Die()
        {
            Dead?.Invoke(this);
            Dispose();
        }
    }
}
