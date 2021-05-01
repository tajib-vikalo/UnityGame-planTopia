using planTopia.Enemies;
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
        private Transform Player;
        [SerializeField]
        private PositionGenerator PositionGenerator;
        [SerializeField]
        private Generator EnemiesPool;


        private int counter { get; set; } = 0;
        private bool started { get; set; } = false;
        private float NextEnemy { get; set; } = 0;

        //calculating a scale of EnemiesPlane
        private void Start()
        {
            particle.Stop();
            counter = EnemiesPool.Size;


        }
        //generate enemies in wanted amount
        private void FixedUpdate()
        {
            if (started && counter > 0)
            {
                if (Time.time > NextEnemy)
                {

                    NextEnemy = Time.time + GenerationSpeed;
                    GameObject enemy = EnemiesPool.Next(
                        Random.Range(-PositionGenerator.range.x, PositionGenerator.range.x), PositionGenerator.range.y,
                        Random.Range(-PositionGenerator.range.z, PositionGenerator.range.z),
                            PositionGenerator.origin);
                    if (enemy != default(GameObject))
                    {
                        enemy.GetComponent<EnemieController>().Player = Player;

                        enemy.SetActive(enabled);

                        counter--;
                        particle.Play();
                    }
                }
            }
            particle.Stop();
        }

        //Cheching if a player is finally entering enemies plane
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag(Constants.Tag.PLAYER))
            {
                started = true;
            }
        }

    }
}
