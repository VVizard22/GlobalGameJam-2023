using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ
{
    public class WinLevel : MonoBehaviour
    {
        [SerializeField] GameEvent winGame;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject current = collision.gameObject;

            if (current == null)
                return;

            if (!current.CompareTag("Player"))
                return;

            winGame.Raise();
        }
    }
}
