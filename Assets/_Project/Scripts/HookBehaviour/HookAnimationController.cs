using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine.Animations;

namespace GGJ.Hooks
{
    public class HookAnimationController : MonoBehaviour
    {
        [SerializeField] FloatReference _animationTime;
        [SerializeField] AnimationCurve _animationFlow;
        float _hookTime = 0;
        float _currentGraphPoint = 0;

        public float _pointInGraph = 0;
        // Update is called once per frame
        public float AnalizeGraph()
        {
            _currentGraphPoint = 100f * _hookTime / _animationTime;
            _pointInGraph = _animationFlow.Evaluate(_currentGraphPoint);
            _hookTime += Time.deltaTime;
            return _pointInGraph;
        }

        public void EndAnimation()
        {
            _hookTime = 0;
            _pointInGraph = _animationFlow.Evaluate(_hookTime);
        }
    }
}
