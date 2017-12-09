using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Aliens
{
    public class SimpleAlien : MonoBehaviour, IAlien 
    {
        public int healthLeft { get; set; }
        public int accuracy { get; set; }
        public int speed { get; set; }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "bullet")
            {
                healthLeft -= collider.gameObject.GetComponent<Bullets>().bulletForce;
                if(healthLeft <=0)
                    Destroy(gameObject);
                Destroy(collider.gameObject);
            }
        }

        // Use this for initialization
        void Start ()
        {
            healthLeft = 100;
            accuracy = 10;
            speed = 5;
        }
	
        // Update is called once per frame
        void Update () {
        }
    }
}
