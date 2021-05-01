using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Enemies
{
    public class Enabled : MonoBehaviour
    {

        private bool startMove { get; set; } = false;
        private EnemieController EnemieController { get; set; }
        [SerializeField]
        private Animator Animator;

        private void Start()
        {
            EnemieController = this.GetComponent<EnemieController>();
            Animator = this.GetComponent<Animator>();

        }

        private void FixedUpdate()
        {
            if (startMove)
            {

                EnemieController.MoveAndRotate();


            }

        }
        private void OnEnable()
        {
            Animator.SetBool("Run", true);
            startMove = true;
            Invoke("Disable", 4);
        }
        private void Disable()
        {

            if (this.gameObject.activeInHierarchy)
            {
                startMove = false;
                this.gameObject.SetActive(false);
                Animator.SetBool("Run", false);



            }
        }
    }
}
