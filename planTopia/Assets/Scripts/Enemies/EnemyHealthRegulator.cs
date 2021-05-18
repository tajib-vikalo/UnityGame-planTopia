using planTopia.Core;
using planTopia.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace planTopia.Enemies
{
    public class EnemyHealthRegulator : MonoBehaviour
    {
  
        [SerializeField]

        private Slider slider;
        public Health Health;
        private float CurrentHealth { get; set; }
        private Animator Animator { get; set; }
  





        private void OnEnable()
        {
            CurrentHealth = Health.StartingHealt;
            Animator = this.GetComponent<Animator>();
            slider.maxValue = Health.StartingHealt;
            slider.value = Health.StartingHealt;
        }

        public void DecreaseHealth(float damage)
        {
            CurrentHealth -= damage;
            slider.value -= damage;

            if (CurrentHealth <= 0)
            {


                this.gameObject.GetComponent<BaseGenerics>().startMove = false;
                if (this.gameObject.GetComponent<Enabled>() != null)
                {
                    this.gameObject.GetComponent<Enabled>().Damage.AmountOfDamage = this.gameObject.GetComponent<Enabled>().Damage.StartingDamage;
                
                }
                Animator.SetBool("Die", true);

                Invoke("ObjectDisable", 2);
            }
        }
        private void ObjectDisable()
        {

            Animator.SetBool("Die", false);

            this.gameObject.SetActive(false);

            if (this.gameObject.GetComponent<Enabled>() != null)
            {
                this.gameObject.GetComponent<Enabled>().Damage.AmountOfDamage = 1;
            
            }
        }

    }
}
