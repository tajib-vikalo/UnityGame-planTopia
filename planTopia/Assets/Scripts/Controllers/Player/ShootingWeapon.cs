using planTopia.Controllers.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
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
        [Range(1f, 10f)]
        private float Damage = 2;
        [SerializeField]
        [Range(0.1f, 1.5f)]
        private float FireRate = 0.6f;
        private float NextRate;

        private Ray ray;
        private RaycastHit hitInfo;

        private void Start()
        {
            InputManagment.OnShooting += OnStartFiring;
        }
        private void OnStartFiring()
        {
            if (Time.time>NextRate)
            {
                NextRate = Time.time+ FireRate;
                ray.origin = RaycastOrigin.position;
                ray.direction = RaycastDestination.position - RaycastOrigin.position;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "Enemy")
                        hitInfo.collider.gameObject.GetComponent<EnemyHealth>()?.OnShoot(Damage);
                        Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 4f);
                }
            }
        }
    }
}
