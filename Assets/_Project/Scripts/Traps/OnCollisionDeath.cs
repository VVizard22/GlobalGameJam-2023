using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class OnCollisionDeath : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        void Start()
        {
           spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Kill"))
                Die();
        }

        private void Die()
        {
            spriteRenderer.enabled = false;
            Debug.Log("Te moriste papa");
      
        }

        IEnumerator Waiter()
        {
            yield return new WaitForSeconds(3);
        }
    }
}
