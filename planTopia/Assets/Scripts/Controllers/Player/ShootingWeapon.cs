using planTopia.Controllers.Core;
using planTopia.Core;
using planTopia.Enemies;
using planTopia.ScriptabileObjects;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace planTopia.Controllers.Player
{
    public class ShootingWeapon : MonoBehaviour
    {
        [SerializeField]
        private AudioSource EmptyGunSound;
        [SerializeField]
        private InputManagment InputManagment;
        [SerializeField]
        private Transform RaycastOrigin;
        [SerializeField]
        private Transform RaycastDestination;
        [SerializeField]
        private Text UIAmmunationText;
        [SerializeField]
        private ParticleSystem ParticleShoot;
        private ShootingAttributes shootingAttributes { get; set; }
        private GameObject Object { get; set; }
        private AudioSource Audio { get; set; }

        private float NextRate;
        private Ray ray;
        private RaycastHit hitInfo;

        private void Start()
        {
            InputManagment.OnShooting += OnStartFiring;
            Audio = this.GetComponent<AudioSource>();
        }

        private void OnStartFiring()
        {

            if (Time.time > NextRate)
            {
                if (shootingAttributes.CurrentAmmunation > 0)
                {
                    NextRate = Time.time + shootingAttributes.FireRate;
                    ray.origin = RaycastOrigin.position;
                    ray.direction = RaycastDestination.position - RaycastOrigin.position;
                    ParticleShoot.Play();
                    Invoke(nameof(ParticleStop),0.15f);

                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.collider.gameObject.tag == Constants.Tag.Enemy)
                        {
                            Object = hitInfo.collider.gameObject;
                            var BaseGenericsEnemy = Object.GetComponent<BaseBehaviour>();
                            if (Vector3.Distance(Object.transform.position, this.transform.position) < shootingAttributes.ShootingDistance)
                            {
                                hitInfo.collider.gameObject.GetComponent<EnemyHealthRegulator>()?.DecreaseHealth(shootingAttributes.Damage);
                                BaseGenericsEnemy.startMove = false;
                                Object.GetComponent<DizzyActivator>().StartDizzy();
                            }
                        }
                        Audio.Play();
                        DecreaseAmmunation();
                        Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 4f);
                    }
                }
                else EmptyGunSound.Play();
            }

        }

        private void ParticleStop()
        {
            ParticleShoot.Stop();
        }

        private void DecreaseAmmunation()
        {
            shootingAttributes.CurrentAmmunation -= 1;
            UIAmmunationText.text = $"{shootingAttributes.CurrentAmmunation.ToString()}/{shootingAttributes.MaxAmmunation.ToString()}";
        }
        public void SetShootingAttributes(ShootingAttributes Gun) => shootingAttributes = Gun;
    }
}
