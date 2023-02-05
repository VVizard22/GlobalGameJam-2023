using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ
{
    public class OnCollisionDeath : MonoBehaviour
    {
        [SerializeField]
        GameEvent playerDie;
        [SerializeField]
        GameEvent resetOnDie;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private Animator _animator;
        void Start()
        {
           _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject current = collision.gameObject;

            if (current == null)
                return;

            if (!current.CompareTag("Kill"))
                return;

            Die();
        }

        private void Die()
        {
            _rb.bodyType = RigidbodyType2D.Static;
            _animator.SetBool("Die", true);
            playerDie.Raise();
            //Debug.Log("Te moriste papa");
            StartCoroutine(Waiter());
      
        }

        IEnumerator Waiter()
        {
            yield return new WaitForSeconds(3);
            resetOnDie.Raise();
        }
    }
}
