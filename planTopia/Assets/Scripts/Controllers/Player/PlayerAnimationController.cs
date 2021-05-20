using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Controllers.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int IDLE = Animator.StringToHash("IDLE");
        private static readonly int Running = Animator.StringToHash("Running");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Death = Animator.StringToHash("Dying");
        private Animator PlayerAnimator { get; set; }

        private void Start()
        {
            PlayerAnimator = this.GetComponent<Animator>();
        }

        public void SetRunningTrue() => PlayerAnimator.SetBool(Running, true);
        public void SetRunningFalse() => PlayerAnimator.SetBool(Running,false);
        public void SetTriggerJump() => PlayerAnimator.SetTrigger(Jump);
        public void SetTriggerDeath() => PlayerAnimator.SetTrigger(Death);
        public void SetTriggerIDLE() => PlayerAnimator.SetTrigger(IDLE);
        
    }
}
