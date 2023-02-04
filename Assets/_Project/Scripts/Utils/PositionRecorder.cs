using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace GGJ.Utils
{
    public class PositionRecorder : MonoBehaviour
    {
        [SerializeField] FloatVariable _positionX;
        [SerializeField] FloatVariable _positionY;

        public void RecordPosition(float x, float y)
        {
            _positionX.SetValue(x);
            _positionY.SetValue(y);
        }
    }
}
