using Source.Model;
using Source.Model.Enemy;
using Source.Model.Pause;
using Source.Model.Utils;
using Source.Presenters.Factory;
using UnityEngine;

namespace Source
{
    public class EnemySpawner : IEnemySpawner, IUpdatable, IPauseable
    {
        private const float SpawnIntervalInSeconds = 1f;
        private const float SpawnRadius = 15f;

        private readonly Timer _timer = new Timer(SpawnIntervalInSeconds);

        private readonly Camera _camera;
        private readonly Vector2 _leftTopBound;
        private readonly Vector2 _rightDownBound;

        private readonly Transformable _ship;
        private readonly EnemyDestroyer _enemyDestroyer;
        private readonly IEnemyPresenterFactory _enemyFactory;
        private readonly IPauseRegister _pauseRegister;
        private readonly IEnemiesContainer _enemiesContainer;

        private bool _isPaused;

        public bool IsPaused => _isPaused;

        public EnemySpawner(Camera camera, Transformable ship, IEnemyPresenterFactory enemyFactory, IPauseRegister pauseRegister, IEnemiesContainer enemiesContainer)
        {
            _camera = camera;
            _leftTopBound = _camera.ViewportToWorldPointFromCamera(Vector2.up);
            _rightDownBound = _camera.ViewportToWorldPointFromCamera(Vector2.right);

            _ship = ship;

            _enemyFactory = enemyFactory;
            _pauseRegister = pauseRegister;
            _enemiesContainer = enemiesContainer;

            _enemyDestroyer = new EnemyDestroyer(_enemiesContainer, Vector2.one * SpawnRadius, _leftTopBound, _rightDownBound);

            _pauseRegister.Register(this);
        }

        public void Start() =>
            _timer.Start(OnTimerFinished);

        public void Update(float deltaTime)
        {
            if(IsPaused) 
                return;

            _timer.Update(deltaTime);
            _enemyDestroyer.Update(deltaTime);
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
            Vector2 position = GetRandomPositionInCircleWithExceptedBoxZone(Vector2.zero, SpawnRadius, _leftTopBound, _rightDownBound);
            int range = Random.Range(1, 4);

            Enemy enemy = null;

            switch (range)
            {
                case 1:
                case 2:
                {
                    Vector2 flyDirection = GetDirectionThroughScreen(position, _leftTopBound, _rightDownBound);
                    Asteroid asteroid = new Asteroid(position, flyDirection, 2);
                    asteroid.FellApart += OnAsteroidFellApart;
                    enemy = asteroid;
                    _enemyFactory.CreateAsteroid(asteroid, _camera);
                    break;
                }

                case 3:
                {
                    Ufo ufo = new Ufo(position, 0.6f, _ship);
                    enemy = ufo;
                    _enemyFactory.CreateUfo(ufo, _camera);
                } 
                    break;
            }

            if(enemy is IPauseable pauseable)
                _pauseRegister.Register(pauseable);

            _enemiesContainer.Register(enemy);

            _timer.Restart();
        }

        private void OnAsteroidFellApart(AsteroidPart[] asteroidParts)
        {
            foreach (AsteroidPart asteroidPart in asteroidParts)
            {
                _pauseRegister.Register(asteroidPart);
                _enemiesContainer.Register(asteroidPart);
            }

            _enemyFactory.CreateAsteroidParts(asteroidParts, _camera);
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

    public static class CameraExtension
    {
        public static Vector3 ViewportToWorldPointFromCamera(this Camera camera, Vector2 viewportPoint) => 
            camera.ViewportToWorldPoint(viewportPoint) - camera.transform.position;
    }
}
