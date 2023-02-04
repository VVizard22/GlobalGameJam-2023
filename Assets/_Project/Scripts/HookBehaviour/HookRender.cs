using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace GGJ.Hooks
{
    public class HookRender : MonoBehaviour
    {
        [SerializeField]
        FloatReference[] _playerPosition = new FloatReference[2];

        [SerializeField] LineRenderer _lineRenderer;

        //[SerializeField] FloatReference _hookLenght;
        [SerializeField] HookAnimationController _hookAnimationController;

        bool _isRendering = false;
        Vector3 _finalPoint;
        Vector3 _playerPos;
        private void Awake()
        {
            if (_lineRenderer == null)
            {
                Debug.LogError("Line Renderer not assigned, cashig through code");
                _lineRenderer = GetComponent<LineRenderer>();
            }

            if (_hookAnimationController == null)
            {
                Debug.LogError("Animation Controller not assigned, cashig through code");
                _hookAnimationController = GetComponent<HookAnimationController>();
            }
        }

        public void StartRendering()
        {
            SetEndpoint();
        }

        private void Update()
        {
            if (!_isRendering)
                return;

            Animate();
        }

        public void SetEndpoint()
        {

            _playerPos = new Vector3(_playerPosition[0].Value, _playerPosition[1].Value, 0);
            //Vector3 _hookPos = new Vector3 (_hookPosition[0].Value, _hookPosition[1].Value, 0);

            /*if (Vector3.Distance(_playerPos, _hookPos) > _hookLenght.Value)
            {
                Vector3 _directionVector = _hookPos - _playerPos;
                _directionVector.z = 0;
                _directionVector.Normalize();
                _hookPos = _playerPos + _directionVector * _hookLenght.Value;
            }*/
            //_finalPoint = _hookPos;
            _lineRenderer.SetPosition(0, _playerPos);
            _lineRenderer.SetPosition(1, _finalPoint);

            _lineRenderer.enabled = true;
            _isRendering = true;
        }

        void Animate()
        {
            float percentage = _hookAnimationController.AnalizeGraph();
            _lineRenderer.SetPosition(1, _finalPoint);
        }

        public void CancelRender()
        {
            _isRendering = false;
            _hookAnimationController.EndAnimation();
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
            _lineRenderer.enabled = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            //Gizmos.DrawWireSphere(transform.position, _hookLenght.Value);
        }
    }
}
