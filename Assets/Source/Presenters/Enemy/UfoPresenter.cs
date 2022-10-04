﻿using Assets.Source.Model.Enemy;
using Assets.Source.Presenters.Bullet;
using UnityEngine;

namespace Assets.Source.Presenters.Enemy
{
    public class UfoPresenter : EnemyPresenter
    {
        protected override void OnCollidedWithBullet() => 
            Model.Die();
    }
}