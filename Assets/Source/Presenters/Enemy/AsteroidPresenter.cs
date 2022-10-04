using Assets.Source.Model.Enemy;
using Assets.Source.Model.Factory;
using Assets.Source.Model.Pause;
using Assets.Source.Presenters.Bullet;
using UnityEngine;

namespace Assets.Source.Presenters.Enemy
{
    public class AsteroidPresenter : EnemyPresenter
    {
        public new Asteroid Model => base.Model as Asteroid;

        protected override void OnCollidedWithBullet()
        {
            Model.FallApart();
            Model.Die();
        }
    }
}