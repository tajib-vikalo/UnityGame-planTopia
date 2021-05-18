using planTopia.Controllers.Core;
using planTopia.Core;
using planTopia.Enemies;
using planTopia.ScriptabileObjects;
using UnityEngine;

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
        private ShootingAttributes shootingAttributes;





        private float NextRate;
        private Ray ray;
        private RaycastHit hitInfo;
        private GameObject Object;


        private void Start()
        {
            InputManagment.OnShooting += OnStartFiring;



        }
        private void OnStartFiring()
        {


            if (Time.time > NextRate)
            {
                NextRate = Time.time + shootingAttributes.FireRate;
                ray.origin = RaycastOrigin.position;
                ray.direction = RaycastDestination.position - RaycastOrigin.position;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "Enemy")
                    {

                        Object = hitInfo.collider.gameObject;
                        var BaseGenericsEnemy = Object.GetComponent<BaseGenerics>();
                        if (Vector3.Distance(Object.transform.position, this.transform.position) < shootingAttributes.ShootingDistance)
                        {
                            if (!Object.GetComponent<Animator>().GetBool("Dizzy"))
                            {
                                hitInfo.collider.gameObject.GetComponent<EnemyHealthRegulator>()?.DecreaseHealth(shootingAttributes.Damage);

                                BaseGenericsEnemy.startMove = false;

                                Object.GetComponent<DizzyActivator>().StartDizzy();
                            }
                        }
                    }
                    Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 4f);
                }
            }

        }

    }
}
