using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace planTopia
{
    public class BottleEnable : MonoBehaviour
    {
        [SerializeField]
        private GameObject Boss;
        [SerializeField]
        private GameObject Bottle;
        private int counter=0;
        [SerializeField]
        private List<GameObject> Bosses;
        [SerializeField]
        private AudioSource VictorySound;
        [SerializeField]
        private AudioSource EndSound;
        bool isVisited = false;




        void Update()
        {
           
            if(BosseesDeactivated()&& !Boss.activeInHierarchy && counter==0 && !isVisited)
            {
                Bottle.SetActive(true);
                EndSound.Stop();
                VictorySound.Play();
                isVisited = true;
            }
          
        
        }

       
        private bool BosseesDeactivated()
        {
            return Bosses.Where(x => x.activeInHierarchy == true).ToList().Count == 0;
        }
    }
}
