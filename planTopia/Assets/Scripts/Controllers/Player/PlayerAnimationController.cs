using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Controllers.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int Running = Animator.StringToHash("Running");
        private Animator PlayerAnimator { get; set; }

        private void Start()
        {
            PlayerAnimator = this.GetComponent<Animator>();
        }

        public void SetRunningTrue() => PlayerAnimator.SetBool(Running, true);
        public void SetRunningFalse() => PlayerAnimator.SetBool(Running,false);
    }
}
