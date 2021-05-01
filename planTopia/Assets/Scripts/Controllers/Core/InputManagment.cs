using System;
using UnityEngine;

namespace planTopia.Controllers.Core
{
    public class InputManagment : MonoBehaviour
    {
        public Action<float, float> OnInputChanged;
        public Action OnJump;
        public Action<bool> ZoomCamera;
        public Action OnRotationCamera;
        public Action OnShooting;

        private void FixedUpdate()
        {
            OnInputChanged?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButton("Fire1"))
            {
                OnRotationCamera?.Invoke();
                OnShooting.Invoke();
            }

            if (Input.GetMouseButton(1))
            {
                ZoomCamera?.Invoke(true);
                OnRotationCamera?.Invoke();
            }
            else
                ZoomCamera?.Invoke(false);

            if (Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
        }
    }
}
