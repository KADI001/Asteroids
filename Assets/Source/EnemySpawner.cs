using System;
using Assets.Source.Model;
using Assets.Source.Model.Enemy;
using Assets.Source.Model.Factory;
using Assets.Source.Model.Pause;
using Assets.Source.Model.Score;
using Assets.Source.Model.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Source
{
    public class EnemySpawner : MonoBehaviour, IPauseable
    {
        private const float SpawnIntervalInSeconds = 1f;
        private const float SpawnRadius = 15f;

        [SerializeField] private ShipCompositeRoot _shipCompositeRoot;

        private readonly Timer _timer = new Timer(SpawnIntervalInSeconds);
        private IEnemyPresenterFactory _enemyFactory;
        private EnemyDestroyer _enemyDestroyer;
        private bool _isPaused;

        private static DIContainer Container => DIContainer.Container;
        private static IPauseRegister PauseRegister => Container.GetSingle<IPauseRegister>();
        private static IEnemiesContainer EnemiesContainer => Container.GetSingle<IEnemiesContainer>();
        
        private static Camera Camera => Camera.main;
        private static Vector2 LeftTopBound => Camera.ViewportToWorldPoint(Vector2.up);
        private static Vector2 RightDownBound => Camera.ViewportToWorldPoint(Vector2.right);

        public bool IsPaused => _isPaused;

        private void Awake()
        {
            _enemyFactory = Container.GetSingle<IEnemyPresenterFactory>();
            _enemyDestroyer = new EnemyDestroyer(EnemiesContainer, Vector2.one * SpawnRadius, LeftTopBound, RightDownBound);
            PauseRegister.Register(this);
        }

        private void Start() =>
            _timer.Start(OnTimerFinished);

        private void Update()
        {
            if(IsPaused) 
                return;

            _timer.Update(Time.deltaTime);
            _enemyDestroyer.Update(Time.deltaTime);
        }

        public void Pause()
        {
            _isPaused = true;
            _timer.Stop();
        }

        public void Resume()
        {
            _isPaused = false;
            _timer.Restart();
        }

        private void OnTimerFinished()
        {
            if(_shipCompositeRoot.Ship == null)
                return;

            Vector2 position = GetRandomPositionInCircleWithExceptedBoxZone(Vector2.zero, SpawnRadius, LeftTopBound, RightDownBound);
            int range = Random.Range(1, 4);

            Enemy enemy = null;

            switch (range)
            {
                case 1:
                case 2:
                {
                    Vector2 flyDirection = GetDirectionThroughScreen(position, LeftTopBound, RightDownBound);
                    Asteroid asteroid = new Asteroid(position, flyDirection, 2);
                    asteroid.FellApart += OnAsteroidFellApart;
                    enemy = asteroid;
                    _enemyFactory.CreateAsteroid(asteroid);
                    break;
                }

                case 3:
                {
                    Ufo ufo = new Ufo(position, 0.6f, _shipCompositeRoot.Ship);
                    enemy = ufo;
                    _enemyFactory.CreateUfo(ufo);
                } 
                    break;
            }

            if(enemy is IPauseable pauseable)
                PauseRegister.Register(pauseable);

            EnemiesContainer.Register(enemy);

            _timer.Restart();
        }

        private void OnAsteroidFellApart(AsteroidPart[] asteroidParts)
        {
            foreach (AsteroidPart asteroidPart in asteroidParts)
            {
                PauseRegister.Register(asteroidPart);
                EnemiesContainer.Register(asteroidPart);
            }

            _enemyFactory.CreateAsteroidParts(asteroidParts);
        }

        private static Vector2 GetRandomPositionInCircle(Vector2 at, float radius) =>
            at + Random.insideUnitCircle * radius;

        private static Vector2 GetRandomPositionInCircleWithExceptedBoxZone(Vector2 at, float radius, Vector2 leftTopBound, Vector2 rightDownBound)
        {
            Vector2 position = GetRandomPositionInCircle(at, radius);

            position.x = ExtendedMathf.Except(position.x, leftTopBound.x, rightDownBound.x);
            position.y = ExtendedMathf.Except(position.y, rightDownBound.y, leftTopBound.y);

            return position;
        }

        private static Vector2 GetDirectionThroughScreen(Vector2 position, Vector2 leftTopBound, Vector2 rightDownBound) => 
            (GetRandomPointInBox(leftTopBound, rightDownBound) - position).normalized;

        private static Vector2 GetRandomPointInBox(Vector2 leftTopBound, Vector2 rightDownBound) =>
            new Vector2(Random.Range(leftTopBound.x, rightDownBound.x + 1), Random.Range(rightDownBound.y, leftTopBound.y + 1));
    }
}
