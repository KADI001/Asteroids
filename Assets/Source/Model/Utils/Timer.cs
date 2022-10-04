using System;

namespace Assets.Source.Model.Utils
{
    public class Timer : IUpdatable
    {
        public readonly float EndTime;

        public event Action Finished;
        public event Action Ticked;

        public Timer(float endTime) => 
            EndTime = endTime;

        public bool IsRunning { get; private set; }
        public float AccumulatedTime { get; private set; }
        public bool IsStopped => IsRunning == false && AccumulatedTime > 0;

        public void Start(Action onFinished)
        {
            IsRunning = true;
            Finished += onFinished;
        }

        public void Update(float deltaTime)
        {
            if(IsRunning == false)
                return;

            AccumulatedTime += deltaTime;

            if (AccumulatedTime >= EndTime)
            {
                IsRunning = false;
                Finished?.Invoke();
            }

            Ticked?.Invoke();
        }

        public void Restart()
        {
            AccumulatedTime = 0f;
            IsRunning = true;
        }

        public void Reset()
        {
            AccumulatedTime = 0f;
            IsRunning = false;
            Finished = null;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}