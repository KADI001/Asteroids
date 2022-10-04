using System;
using System.Collections.Generic;

namespace Assets.Source.Model.Enemy
{
    public class EnemiesContainer : IEnemiesContainer
    {
        private readonly List<Enemy> _enemies;

        public event Action<Enemy> EnemyRegistered;

        public EnemiesContainer() => 
            _enemies = new List<Enemy>();

        public IReadOnlyCollection<Enemy> Enemies => _enemies;

        public void Register<T>(T enemy) where T : Enemy
        {
            _enemies.Add(enemy);
            enemy.Dead += OnEnemyDead;

            EnemyRegistered?.Invoke(enemy);
        }

        public void UnRegister<T>(T enemy) where T : Enemy
        {
            _enemies.Remove(enemy);
            enemy.Dead -= OnEnemyDead;
        }

        public Enemy GetEnemyByIndex(int index) => 
            _enemies[index];

        private void OnEnemyDead(Enemy enemy) => 
            UnRegister((Enemy)enemy);
    }
}