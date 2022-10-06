using Source.Presenters.Bullet;
using UnityEngine;

namespace Source.Presenters.Enemy
{
    public abstract class EnemyPresenter : Presenter
    {
        protected new Model.Enemy.Enemy Model => base.Model as Model.Enemy.Enemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isBullet = collision.gameObject.TryGetComponent(out BulletPresenter bullet);

            if (isBullet)
                OnCollidedWithBullet();
        }

        protected virtual void OnCollidedWithBullet() {}
    }
}