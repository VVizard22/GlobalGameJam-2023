using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Hooks
{
    public class JointManager : MonoBehaviour
    {
        [SerializeField] SpringJoint2D joint1;
        [SerializeField] SpringJoint2D joint2;

        public void TriggerJoint1()
        {
            joint1.enabled = true;
        }

        public void TriggerJoint2()
        {
            joint2.enabled = true;
        }

        public void DisableJoints()
        {
            joint1.enabled = false;
            joint2.enabled = false;
        }
    }
}
