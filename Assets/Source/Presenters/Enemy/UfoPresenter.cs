using Source.Model.Enemy;
using Source.Presenters.Bullet;
using UnityEngine;

namespace Source.Presenters.Enemy
{
    public class UfoPresenter : EnemyPresenter
    {
        protected override void OnCollidedWithBullet() => 
            Model.Die();
    }
}