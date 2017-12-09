using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Aliens {
    public class StrongAlien : MonoBehaviour, IAlien {
        public int HealthLeft { get; set; }
        public int Accuracy { get; set; }
        public float MovementSpeed { get; set; }
        public int RotationSpeed { get; set; }
        public int AlienForce { get; set; }

        public bool WasPlayerDetected { get; set; }

        public Transform Target { get; set; }

        public void OnTriggerEnter2D(Collider2D collider) {
            if(collider.tag == "bullet") {
                HealthLeft -= collider.gameObject.GetComponent<Bullets>().bulletForce;
                if(HealthLeft <= 0) {
                    Destroy(gameObject);
                    GameObject.FindWithTag("player").GetComponent<Cosmonaut.Cosmonaut>().Adrenalin++;
                }
                Destroy(collider.gameObject);
            }
            if(collider.tag == "player") {
                WasPlayerDetected = true;
            }
        }

        void Start() {
            HealthLeft = 200;
            Accuracy = 10;
            MovementSpeed = 0.5f;
            RotationSpeed = 1;
            AlienForce = 10;
            WasPlayerDetected = false;

            Target = GameObject.FindWithTag("player").transform;
        }

        private void moveToPlayer() {
            Vector2 direction = Target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);

            transform.rotation = rotation;

            transform.position =
                Vector2.MoveTowards(transform.position, Target.position, MovementSpeed * Time.deltaTime);
        }

        void Update() {
            if(WasPlayerDetected) {
                moveToPlayer();
            }
        }
    }
}
