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

        public float MovementSpeed { get; set; }
        public float RotationSpeed { get; set; }

        public int MaxValue { get; set; }
        public int MaxHealth { get; set; }
        public float MaxSpeed { get; set; }
        public int MaxAmmo { get; set; }

        public Rigidbody2D CosmoRigidbody { get; set; }

        public Transform cosmoTransform { get; set; }

        private void setVariables()
        {
            MaxValue = 100;
            MaxHealth = 100;
            MaxAmmo = 100;
            MaxSpeed = 50f; //TODO: sprawdzic czy wartosc jest ok

            Adrenalin = MaxValue / 2;
            Endorfines = MaxValue / 2;
            Alcohol = MaxValue / 2;

            AmmoLeft = MaxAmmo / 2;
            HealthLeft = MaxHealth;

            MovementSpeed = MaxSpeed / 2;
            RotationSpeed = 10f;

            Accuracy = 1;
        }

        // Use this for initialization
        void Start ()
        {
            setVariables();

            CosmoRigidbody = GetComponent<Rigidbody2D>();
            cosmoTransform = GetComponent<Transform>();
        }

        void FixedUpdate() {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            if(MovementSpeed < MaxSpeed)
                CosmoRigidbody.AddForce(movement * MovementSpeed);

            rotareToMouse();
        }

        void rotareToMouse()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);

            transform.rotation = rotation;
        }
    }
}
