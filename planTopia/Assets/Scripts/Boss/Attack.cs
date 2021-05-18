using planTopia.Core;
using UnityEngine;

namespace planTopia.Boss
{
    public class Attack : BaseGenerics
    {
        
        public void ActivateAttack(Animator animator)
        {

            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);

        }
        public void DeactivateAttack(Animator animator)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }
      

    }
}
