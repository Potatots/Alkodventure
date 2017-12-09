using UnityEngine;

namespace Assets.Scripts.Cosmonaut
{
    public class Shooting : MonoBehaviour
    {
        public float FireRate;
        public float Damage;
        public float TimeToFire;

        public Transform FirePoint;
        public Transform bulletPrefab;
        public Cosmonaut cosmo;

        void Start ()
        {
            FireRate = 0f;
            Damage = 1f;
            TimeToFire = 0f;
        }
	
        void Update () {
            if (FireRate == 0f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    shoot();
                }
            }
            else
            {
                if(Input.GetMouseButtonDown(0) && Time.time > TimeToFire)
                {
                    TimeToFire = Time.time + FireRate;
                    shoot();
                }
            }
            FirePoint = cosmo.CosmoTransform;
        }

        private void shoot()
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            createBullet();

            Vector2 firePP = new Vector2(FirePoint.position.x, FirePoint.position.y);
            RaycastHit2D hit = Physics2D.Raycast(firePP, mousePosition, 100);
        }

        private void createBullet()
        {
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }
    }
}
