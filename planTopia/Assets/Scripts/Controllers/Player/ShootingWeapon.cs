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
        private InputManagment InputManagment;
        [SerializeField]
        private Transform RaycastOrigin;
        [SerializeField]
        private Transform RaycastDestination;
        [SerializeField]
        private Text UIAmmunationText;
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
            if (Time.time > NextRate && shootingAttributes.CurrentAmmunation > 0)
            {
                NextRate = Time.time + shootingAttributes.FireRate;
                ray.origin = RaycastOrigin.position;
                ray.direction = RaycastDestination.position - RaycastOrigin.position;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == Constants.Tag.Enemy)
                    {
                        Object = hitInfo.collider.gameObject;
                        var BaseGenericsEnemy = Object.GetComponent<BaseBehaviour>();
                        if (Vector3.Distance(Object.transform.position, this.transform.position) < shootingAttributes.ShootingDistance)
                        {
                            if (!Object.GetComponent<Animator>().GetBool(Constants.Tag.Dizzy))
                            {
                                hitInfo.collider.gameObject.GetComponent<EnemyHealthRegulator>()?.DecreaseHealth(shootingAttributes.Damage);
                                BaseGenericsEnemy.startMove = false;
                                Object.GetComponent<DizzyActivator>().StartDizzy();
                            }
                        }
                    }
                    Audio.Play();
                    DecreaseAmmunation();
                    Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 4f);
                }
            }

        }
        private void DecreaseAmmunation()
        {
            shootingAttributes.CurrentAmmunation -= 1;
            UIAmmunationText.text = $"{shootingAttributes.CurrentAmmunation.ToString()}/{shootingAttributes.MaxAmmunation.ToString()}";
        }
        public void SetShootingAttributes(ShootingAttributes Gun) => shootingAttributes = Gun;
    }
}
