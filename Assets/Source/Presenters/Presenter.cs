using Assets.Source.Model;
using UnityEngine;

namespace Assets.Source.Presenters
{
    public abstract class Presenter : MonoBehaviour
    {
        public Transformable Model { get; private set; }
        public IUpdatable Updatable { get; private set; }

        public void Init(Transformable model)
        {
            Model = model;

            if (model is IUpdatable updatable)
                Updatable = updatable;

            OnInitialized();

            OnMoved();
            OnRotated();

            enabled = true;
        }

        protected virtual void OnInitialized() { }

        private void Update() => 
            Updatable?.Update(Time.deltaTime);

        private void OnEnable()
        {
            Model.Moved += OnMoved;
            Model.Rotated += OnRotated;
            Model.Destroyed += OnDestroyed;

            OnEnabling();
        }

        private void OnDisable()
        {
            Model.Moved -= OnMoved;
            Model.Rotated -= OnRotated;
            Model.Destroyed -= OnDestroyed;

            OnDisabling();
        }

        protected virtual void OnEnabling() { }

        protected virtual void OnDisabling() { }

        protected void OnMoved() => 
            transform.position = Model.Position;

        protected void OnRotated() => 
            transform.rotation = Quaternion.Euler(0, 0, Model.Rotation);

        protected void OnDestroyed() => 
            Destroy(gameObject);
    }
}