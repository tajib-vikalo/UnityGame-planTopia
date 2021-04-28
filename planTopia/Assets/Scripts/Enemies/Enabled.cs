using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Enemies
{
    public class Enabled : MonoBehaviour
    {
        // Start is called before the first frame update
        private void OnEnable()
        {
            Invoke("Disable", 2);
        }
        private void Disable()
        {
            if (this.gameObject.activeInHierarchy)
                this.gameObject.SetActive(false);
        }
    }
}
