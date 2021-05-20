using System;
using UnityEngine;
using UnityEngine.UI;

namespace planTopia.Controllers.Player
{
    public class PlayerHealth : MonoBehaviour
    {

        [SerializeField]
        [Range(1, 100)]
        private float MaxHealth = 100;
        [SerializeField]
        [Range(1, 60)]
        private float TimeOfDecreaseHealth=2;
        [SerializeField]
        [Range(0.1f, 10)]
        private float DecrementHealth=1;
        private float CurrentHealth;

        [SerializeField]
        private Slider HealthSlider;
        [SerializeField]
        private Text HealthText;

        private PlayerAnimationController Animator { get; set; }
        private PlayerController Controller { get; set; }

        private float NextDecreaseHealth;

        [SerializeField]
        private Vector3 StartPosition = new Vector3(-6.5f, 0, -39);

        private bool isDeath=false;


        private void Start()
        {
            Animator = this.GetComponent<PlayerAnimationController>();
            Controller = this.GetComponent<PlayerController>();
            HealthText.text = CurrentHealth.ToString() + "%";
        }
        private void OnEnable()
        {
            CurrentHealth = MaxHealth;
            NextDecreaseHealth = Time.time+TimeOfDecreaseHealth;
        }

        private void Update()
        {
            DecreaseHealthOnTime();
            if (CurrentHealth >= 0)
                HealthText.text = CurrentHealth.ToString() + "%";
            else HealthText.text = "0%";
            Debug.Log(CurrentHealth);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constants.Tag.Water)
            {
                CurrentHealth = 0;
                CheckDeath();
            }
        }

        private void DecreaseHealthOnTime()
        {
            if (Time.time > NextDecreaseHealth&&!isDeath)
            {
                CurrentHealth -= DecrementHealth;
                HealthSlider.value = CurrentHealth;
                NextDecreaseHealth = Time.time + TimeOfDecreaseHealth;
                CheckDeath();
            }
        }

        public void DecreaseHealth(float damage)
        {
            CurrentHealth -= damage;
            HealthSlider.value = CurrentHealth;
            CheckDeath();
        }

        private void CheckDeath()
        {
            if (CurrentHealth <= 0 && !isDeath)
            {
                Controller.startMove = false;
                isDeath = true;
                Animator.SetTriggerDeath();
                Invoke(nameof(RespawnPlayer), 3.5f);
            }
        }

        private void RespawnPlayer()
        {
            this.transform.position = StartPosition;
            this.transform.rotation = Quaternion.Euler(Vector3.zero);
            CurrentHealth = MaxHealth;
            HealthSlider.value = MaxHealth;
            HealthText.text = MaxHealth.ToString()+"%";
            Animator.SetTriggerIDLE();
            Controller.startMove = true;
            isDeath = false;
        }

    }
}
