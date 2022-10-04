using Assets.Source.Presenters.Enemy;
using UnityEngine;

namespace Assets.Source.Presenters.Bullet
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
