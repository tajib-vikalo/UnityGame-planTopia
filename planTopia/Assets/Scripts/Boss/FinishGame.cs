using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace planTopia
{
    public class FinishGame : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> Bosses;
        [SerializeField]
        private GameObject GameObject;

        private int counter=0;
        

        void Update()
        {
            if (BosseesDeactivated() && counter==0)
            {
                GameObject.SetActive(!GameObject.activeInHierarchy);
                counter++;
            }
       
        }

        private bool BosseesDeactivated()
        {
            return Bosses.Where(x => x.activeInHierarchy == true).ToList().Count == 0;
        }
    }
}
