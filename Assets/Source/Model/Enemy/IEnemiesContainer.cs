using System;
using System.Collections.Generic;

namespace Source.Model.Enemy
{
    public interface IEnemiesContainer
    {
        public event Action<Enemy> EnemyRegistered;

        public IReadOnlyCollection<Enemy> Enemies { get; }

        public Enemy GetEnemyByIndex(int index);
        public void Register<T>(T enemy) where T : Enemy;
        public void UnRegister<T>(T enemy) where T : Enemy;
        public void DestroyAll();
    }
}