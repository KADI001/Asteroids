using Source.Presenters.Enemy;
using UnityEngine;

namespace Source.Presenters.Bullet
{
    public sealed class DefaultBulletPresenter : BulletPresenter
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isEnemy = collision.gameObject.TryGetComponent(out EnemyPresenter enemy);

            if (isEnemy)
            {
                Model.Dispose();
            }
        }
    }
}
