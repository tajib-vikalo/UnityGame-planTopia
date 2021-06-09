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


        [SerializeField]
        private AudioSource DeathSound;
        [SerializeField]
        private AudioSource DecreaseHealthSound;

        private PlayerAnimationController Animator { get; set; }
        private PlayerController Controller { get; set; }
        private Weapon Weapons { get; set; }
        public Transform StartPosition;
     
        private float NextDecreaseHealth;
        public bool isDeath=false;

        private void Start()
        {
            Animator = this.GetComponent<PlayerAnimationController>();
            Controller = this.GetComponent<PlayerController>();
            Weapons = this.GetComponent<Weapon>();
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
            DecreaseHealthSound.Play();
        }

        private void CheckDeath()
        {
            if (CurrentHealth <= 0 && !isDeath)
            {
                Controller.startMove = false;
                isDeath = true;
                Animator.SetTriggerDeath();
                DeathSound.Play();
                Invoke(nameof(RespawnPlayer), 3.5f);
            }
        }

        private void RespawnPlayer()
        {
            SetPosition();
            SetDefaultSettings();
        }

        public void SwitchLevel(Transform newLevel)
        {
            StartPosition = newLevel;
            SetPosition();
            SetDefaultSettings();
        }

        private void SetPosition()
        {
            this.transform.position = StartPosition.position;
            this.transform.rotation = StartPosition.rotation;
        }

        private void SetDefaultSettings()
        {
            CurrentHealth = MaxHealth;
            HealthSlider.value = MaxHealth;
            HealthText.text = MaxHealth.ToString() + "%";
            Animator.SetTriggerIDLE();
            Controller.startMove = true;
            isDeath = false;
            Weapons.SetGreenWeapon();
        }
    }
}
