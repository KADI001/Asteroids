using Source.Model.Pause;
using Source.Model.Ship;
using Source.Presenters.Enemy;
using UnityEngine;

namespace Source.Presenters
{
    [RequireComponent(typeof(ShipController))]
    public class ShipPresenter : Presenter
    {
        private ShipController _controller;
        public new Ship Model => base.Model as Ship;

        private static DIContainer DiContainer => DIContainer.Container;
        private static IPauseManger PauseManger => DiContainer.GetSingle<IPauseManger>();

        public ShipController Controller => _controller;

        protected override void OnInitialized() => 
            _controller = GetComponent<ShipController>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isEnemy = collision.gameObject.TryGetComponent(out EnemyPresenter enemy);

            if (isEnemy == false) 
                return;

            _controller.DisableShipControl();
            PauseManger.PauseAll();
        }
    }
}
