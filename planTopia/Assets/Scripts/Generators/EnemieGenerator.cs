using planTopia.Generators.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Generators
{
    public class EnemieGenerator : MonoBehaviour
    {
        [SerializeField]
        private float GenerationSpeed;
        [SerializeField]
        private ParticleSystem particle;
        [SerializeField]
        private GameObject EnemiesPlane;
        [SerializeField]
        private float percentageOfUsage;





        private Vector3 origin;
        private Vector3 range;
        private int counter = 0;
        private bool started = false;
        private int NumberOfEntries = 0;
        private float precisionX;
        private float precisionZ;



        private float NextEnemy { get; set; } = 0;
        [SerializeField]
        private Generator EnemiesPool;

        //calculating a scale of EnemiesPlane
        private void Start()
        {
            particle.Stop();
            
            origin = EnemiesPlane.transform.position;
            range = EnemiesPlane.transform.localScale / 2.0f;
            counter = EnemiesPool.Size;
            precisionX = CalculatePrecision(range.x);
            precisionZ = CalculatePrecision(range.y);
        }
        //generate enemies in wanted amount
        private void Update()
        {
            if (started && counter > 0)
            {
                if (Time.time > NextEnemy)
                {

                    NextEnemy = Time.time + GenerationSpeed;
                    if (EnemiesPool.Next(
                        Random.Range(-range.x + precisionX,range.x-precisionX) ,   0f,
                        Random.Range(-range.z + precisionZ, range.z - precisionZ),  origin))
                    {
                        counter--;
                        particle.Play();
                    }
                }
            }
            particle.Stop();
        }

        //Cheching if a player is finally entering enemies plane
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                if (NumberOfEntries > 0)
                    return;
                
                started = true;
                NumberOfEntries++;
            }
        }
        //calculate percentage out of boundaries 
        private float CalculatePrecision(float coordinate)
        {
            return coordinate * percentageOfUsage;
        }

    }
}
