using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace planTopia.Enemies
{
    public class EnemieController : MonoBehaviour
    {
        [SerializeField]
        [Range(0.1f, 100f)]
        private float Speed;
  
        public Transform Player { get; set; }
        private Rigidbody Rigidbody { get; set; }
    
        
        private void Start()
        {
            Rigidbody = this.GetComponent<Rigidbody>();
        }

        public void MoveAndRotate()
        {
            Vector3 direction = Player.position-this.transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            direction.Normalize();
            Vector3 movement = direction;
            Rigidbody.MoveRotation(Quaternion.Euler(0f, angle, 0f));
            Rigidbody.MovePosition(this.transform.position + (movement * Time.deltaTime));
           

        }
    }
}
