using UnityEngine;

namespace planTopia.Controllers.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private float StartingHealt = 10;
   
        public float CurrentHealth { get; set; }
 






        private void OnEnable()
        {
            CurrentHealth = StartingHealt;
         
        }

        public void OnShoot(float damage)
        {
            CurrentHealth -= damage;
            Debug.Log("Health--");
           

            if (CurrentHealth <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
 

    }
}
