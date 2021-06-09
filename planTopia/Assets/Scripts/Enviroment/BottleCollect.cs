using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia
{
    public class BottleCollect : MonoBehaviour
    {
        [SerializeField]
        private AudioSource CollectSound;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.Tag.PLAYER))
            {
                CollectSound.Play();
                Invoke(nameof(SetDisable), 0.5f);
               
            }
        }

        private void SetDisable()
        {
            this.gameObject.SetActive(false);
        }
    }
}
