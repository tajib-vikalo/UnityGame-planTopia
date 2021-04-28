using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Controllers.Core
{
    public class InputManagment : MonoBehaviour
    {
        public Action<float, float> OnInputChanged;
        public Action OnJump;

        private void FixedUpdate()
        {
            OnInputChanged?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
        }
    }
}
