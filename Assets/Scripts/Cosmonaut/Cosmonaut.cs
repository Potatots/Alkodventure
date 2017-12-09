using Assets.Scripts.Aliens;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Assets.Scripts.Cosmonaut {
    public class Cosmonaut : MonoBehaviour, ICosmonaut {
        public string CosmonautName { get; set; }

        private int adrenalin;
        private int happiness;
        private int alcohol;
        private int ammoLeft;
        public int healthLeft;

        public int Adrenalin {
            get { return adrenalin; }
            set { adrenalin = value < MaxValue ? value : MaxValue; }
        }
        public int Happiness {
            get { return happiness; }
            set { happiness = value < MaxValue ? value : MaxValue; }
        }
        public int Alcohol {
            get { return alcohol; }
            set { alcohol = value < MaxValue ? value : MaxValue; }
        }
        public int AmmoLeft {
            get { return ammoLeft; }
            set { ammoLeft = value < MaxValue ? value : MaxAmmo; }
        }
        public int HealthLeft {
            get { return healthLeft; }
            set { healthLeft = value < MaxValue ? value : MaxHealth; }
        }

        public float MovementSpeed { get; set; }
        public float RotationSpeed { get; set; }

        public int MaxValue { get; set; }
        public int MaxHealth { get; set; }
        public float MaxSpeed { get; set; }
        public int MaxAmmo { get; set; }

        public float MoveVertical { get; set; }
        public float MoveHorizontal { get; set; }
        public Color StandardLightColor { get; set; }

        public Rigidbody2D CosmoRigidbody { get; set; }
        public Transform CosmoTransform { get; set; }
        public Vector2 Movement { get; set; }

        public void OnTriggerEnter2D(Collider2D collider) {

            if(collider.tag == "simpleAlien")
            {
                HealthLeft -= 10;//collider.gameObject.GetComponent<SimpleAlien>().AlienForce;
                Happiness -= 10;//collider.gameObject.GetComponent<SimpleAlien>().AlienForce;
                Debug.Log(HealthLeft);
            }
            if(collider.tag == "fastAlien" && GetComponent<BoxCollider2D>().IsTouching(collider))
            {
                HealthLeft -= 3;//collider.gameObject.GetComponent<FastAlien>().AlienForce;
                Happiness -= 3;//collider.gameObject.GetComponent<FastAlien>().AlienForce;
                Debug.Log(HealthLeft);
            }
            if(collider.tag == "strongAlien" && GetComponent<BoxCollider2D>().IsTouching(collider))
            {
                HealthLeft -= 15;//collider.gameObject.GetComponent<StrongAlien>().AlienForce;
                Happiness -= 15;//collider.gameObject.GetComponent<StrongAlien>().AlienForce;
                Debug.Log(HealthLeft);
            }
            if(collider.tag == "fancyAlien" && GetComponent<BoxCollider2D>().IsTouching(collider))
            {
                HealthLeft -= 7;//collider.gameObject.GetComponent<FancyAlien>().AlienForce;
                Happiness -= 7;//collider.gameObject.GetComponent<FancyAlien>().AlienForce;
                Debug.Log(HealthLeft);
            }
            if(collider.tag == "alcohol" && GetComponent<BoxCollider2D>().IsTouching(collider)) {
                int alc = Random.Range(5, 15);

                Alcohol += alc;
                Happiness += alc;

                Destroy(collider.gameObject);
            }
        }

        void Start() {
            setVariables();

            CosmoRigidbody = GetComponent<Rigidbody2D>();
            CosmoTransform = GetComponent<Transform>();

            CosmoTransform.position =
                new Vector3(Camera.main.transform.position.x / 2, Camera.main.transform.position.y / 2, 0);

            StandardLightColor = new Color(190,190,190,255);
        }

        void FixedUpdate() {
            movePlayer();
            rotareToMouse();
            setLight();
            Happiness -= (int)(Happiness * Time.deltaTime);
        }

        private void setLight()
        {
            Light temp = gameObject.GetComponentInChildren<Light>();
            temp.spotAngle = Happiness / 7 + 15;
            temp.intensity = Adrenalin/25+2;
            //temp.color = new Color(150, 150, 150);
            //Debug.Log((healthLeft) * 3 / 2);
            //Debug.Log(StandardLightColor.r + " " + (StandardLightColor.g - (MaxHealth - healthLeft) * 3 / 2) + " " + (StandardLightColor.b - (MaxHealth - healthLeft) * 3 / 2) +" " + StandardLightColor.a);
        }
        private void movePlayer() {
            MoveHorizontal = Input.GetAxis("Horizontal");
            MoveVertical = Input.GetAxis("Vertical");

            if(alcohol != 0) {
                if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
                {
                    MoveVertical = MoveVertical = Mathf.Sin(Time.time * (alcohol / 25));
                }
                else
                {
                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        MoveVertical = Mathf.Sin(Time.time * (alcohol / 25));
                    }
                    if (Input.GetAxis("Vertical") != 0)
                    {
                        MoveHorizontal = Mathf.Cos(Time.time * (alcohol / 25));
                    }
                }
            }

            Movement = new Vector2(MoveHorizontal, MoveVertical);

            if(MovementSpeed < MaxSpeed)
                CosmoRigidbody.AddForce(Movement * MovementSpeed);
        }
        private void rotareToMouse() {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);

            transform.rotation = rotation;
        }
        private void setVariables() {
            MaxValue = 100;
            MaxHealth = 100;
            MaxAmmo = 100;
            MaxSpeed = 50f;

            Adrenalin = MaxValue / 2;
            Happiness = MaxValue / 2;
            Alcohol = MaxValue/2;

            AmmoLeft = MaxAmmo / 2;
            HealthLeft = MaxHealth;

            MovementSpeed = MaxSpeed / 2;
            RotationSpeed = 8f;
        }
    }
}
