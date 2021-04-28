using planTopia.Controllers.Core;
using planTopia.Controllers.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputManagment InputManagment;
        [SerializeField] private Transform Camera;
        [SerializeField] private Transform GroundCheckTransfrom;
        [SerializeField] public float JumpHeight;

        [SerializeField]
        [Range(0.1f, 100f)]
        public float Speed;

        private Rigidbody Rigidbody;
        private SphereCollider Collider;
        private PlayerAnimationController PlayerAnimator { get; set; }

        private float turnSmoothTime = 0.1f;
        float turnSmoothVelicoty;

        private void Start()
        {
            InputManagment.OnInputChanged += OnInputChanged;
            InputManagment.OnJump += Jump;

            Rigidbody = this.GetComponent<Rigidbody>();
            Collider = this.GetComponent<SphereCollider>();
            PlayerAnimator = this.GetComponent<PlayerAnimationController>();
        }
        private void OnInputChanged(float horizontal, float vertical)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >0)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelicoty, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);


                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                Rigidbody.MovePosition(transform.position + moveDir.normalized * Speed * Time.deltaTime);


                PlayerAnimator.SetRunningTrue();
            }
            else
                PlayerAnimator.SetRunningFalse();
        }
        private void Jump()
        {
            if (Physics.OverlapSphere(GroundCheckTransfrom.position, 0.01f).Length > 1)
                this.Rigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);
        }
    }
}
