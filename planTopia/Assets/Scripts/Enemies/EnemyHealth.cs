using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private float StartingHealt = 10;
        private float CurrentHealth { get; set; }

        private void OnEnable()
        {
            CurrentHealth = StartingHealt;
        }

        public void OnShoot(float damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
