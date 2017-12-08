using UnityEngine;

namespace Assets.Scripts
{
    public class Cosmonaut : MonoBehaviour, ICosmonaut {
        public string CosmonautName { get; set; }

        public int Adrenalin { get; set; }
        public int Endorfines { get; set; }
        public int Alcohol { get; set; }

        public int AmmoLeft { get; set; }
        public int HealthLeft { get; set; }

        public int Accuracy { get; set; }
        public float Speed { get; set; }

        public int maxValue { get; set; }
        public int maxHealth { get; set; }
        public float maxSpeed { get; set; }
        public int maxAmmo { get; set; }

        public Rigidbody2D CosmoRigidbody { get; set; }

        // Use this for initialization
        void Start ()
        {
            maxValue = 100;
            maxHealth = 100;
            maxAmmo = 100;
            maxSpeed = 30f; //TODO: sprawdzic czy wartosc jest ok

            Adrenalin = maxValue / 2;
            Endorfines = maxValue / 2;
            Alcohol = maxValue / 2;

            AmmoLeft = maxAmmo / 2;
            HealthLeft = maxHealth;
            Speed = maxSpeed / 2;

            Accuracy = 1;

            CosmoRigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate() {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            if(Speed < maxSpeed)
                CosmoRigidbody.AddForce(movement * Speed);
        }
    }
}
