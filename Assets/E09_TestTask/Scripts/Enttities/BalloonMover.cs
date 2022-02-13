using UnityEngine;

namespace E09_TestTask
{
    public class BalloonMover : EntityMover
    {
        private float _verticalSpeed;

        private float _topLimit;

        private void Start()
        {
            base.Start();
            _verticalSpeed = _settings.EnemyVerticalSpeed;
            _topLimit = _settings.EntityTopLimit;
        }

        private void Update()
        {
            base.Update();
            MoveVertical();
        }

        private void MoveVertical()
        {
            transform.Translate(_verticalSpeed * Time.deltaTime * Vector3.up);

            if (IsWentAbroadVertical())
            {
                _entity.Die();
            }
        }

        private bool IsWentAbroadVertical()
        {
            return transform.position.y > _topLimit;
        }
    }
}