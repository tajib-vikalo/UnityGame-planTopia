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


                this.gameObject.GetComponent<BaseBehaviour>().startMove = false;
                if (this.gameObject.GetComponent<EnemyBehaviour>() != null)
                {
                    this.gameObject.GetComponent<EnemyBehaviour>().Damage.AmountOfDamage = this.gameObject.GetComponent<EnemyBehaviour>().Damage.StartingDamage;
                
                }
                Animator.SetBool(Constants.Tag.Die, true);

                Invoke(nameof(ObjectDisable), 2);
            }
        }
        private void ObjectDisable()
        {

            Animator.SetBool(Constants.Tag.Die, false);

            this.gameObject.SetActive(false);

            if (this.gameObject.GetComponent<EnemyBehaviour>() != null)
            {
                this.gameObject.GetComponent<EnemyBehaviour>().Damage.AmountOfDamage = 1;
            
            }
        }

    }
}
