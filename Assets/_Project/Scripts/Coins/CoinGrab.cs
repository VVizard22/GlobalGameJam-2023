using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace GGJ
{
    public class CoinGrab : MonoBehaviour
    {
        [SerializeField] private FloatReference SO;
   
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SO.Variable.ApplyChange(1);
                Destroy(gameObject);
            }
                
        }
    }
}
