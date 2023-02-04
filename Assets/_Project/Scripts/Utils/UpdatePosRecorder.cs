using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Utils
{
    public class UpdatePosRecorder : PositionRecorder
    {

        // Update is called once per frame
        void Update()
        {
            RecordPosition(transform.position.x, transform.position.y);
        }
    }
}
