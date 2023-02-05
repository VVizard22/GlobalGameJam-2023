using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class OnCollisionDeath : MonoBehaviour
    {
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Kill"))
                Die();
        }

        private void Die()
        {
            rb.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
