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
                if (Input.GetMouseButtonDown(0) && cosmo.AmmoLeft > 0)
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
            float minRange = -cosmo.Alcohol + cosmo.Adrenalin / 2;
            float maxRange = cosmo.Alcohol - cosmo.Adrenalin / 2;
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x + Random.Range(minRange, maxRange), Input.mousePosition.y + Random.Range(minRange, maxRange)));
            Vector2 currentPos = new Vector2(transform.position.x,transform.position.y);

            Vector2 direction = target - currentPos;
            direction.Normalize();

            Quaternion rotation = Quaternion.Euler(0,0,Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg);

            Instantiate(bulletPrefab, currentPos, rotation);

            cosmo.AmmoLeft--;
        }
    }
}
