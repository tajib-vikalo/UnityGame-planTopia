using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public class SwordAttack : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.Tag.PLAYER))
            {
                Debug.Log("Health--");
            }
        }
    }
}
