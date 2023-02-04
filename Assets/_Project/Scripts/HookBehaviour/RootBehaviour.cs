using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace GGJ.Hooks
{
    public class RootBehaviour : MonoBehaviour
    {
        [SerializeField]
        FloatReference[] _playerPosition = new FloatReference[2];
        [SerializeField]
        LineRenderer _lineRenderer;
        [SerializeField]
        FloatReference _animationTime;
        public bool _finishedAnimation { get; private set; }
        bool _animationRunning = false;
        float _currentTime = 0f;
        Vector3 _targetPos;
        public void StartAnimation(Vector3 pos)
        {
            _targetPos = pos;

            _currentTime = 0f;
            _animationRunning = true;
        }

        private void Update()
        {
            if (!_animationRunning)
                return;

            _currentTime += Time.deltaTime;
            UpdateImage();
        }

        void UpdateImage()
        {
            RotateToPoint(_targetPos);
            _lineRenderer.SetPosition(0, new Vector3(_playerPosition[0].Value,_playerPosition[1].Value,0));
            _lineRenderer.SetPosition(1, _targetPos);

        }
        public bool Animate()
        {
            
            return _finishedAnimation;
        }

        void RotateToPoint(Vector3 pos)
        {
            Vector2 directionVector = (pos - transform.position).normalized;

            transform.up = directionVector;
        }
    }
}
