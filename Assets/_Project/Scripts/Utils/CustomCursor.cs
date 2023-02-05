using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class CustomCursor : MonoBehaviour
    {
        public bool visible = false;
        public Transform mCursorVisual;
        public Vector3 mDisplacement;
        void Start()
        {
            // this sets the base cursor as invisible
            Cursor.visible = visible;
        }

        void Update()
        {
            if (visible)
                return;

            mCursorVisual.position = Input.mousePosition + mDisplacement;

        }
    }
}
