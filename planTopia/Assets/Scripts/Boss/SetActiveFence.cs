using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public class SetActiveFence: MonoBehaviour
    {
        [SerializeField]
        private GameObject Fence;
        [SerializeField]
        private GameObject Boss;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == Constants.Tag.PLAYER)
            {
                Fence.SetActive(true);
            }
        }
        private void Update()
        {
            if (Boss.activeInHierarchy == false)
                Fence.SetActive(false);
        }
    }
}
