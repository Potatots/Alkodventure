using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float FireRate;
    public float Damage;
    public float TimeToFire;

    public Transform FirePoint;

    public Cosmonaut cosmo;

    [SerializeField]
    public Transform bulletPrefab;

	// Use this for initialization
	void Start ()
	{
	    FireRate = 0f;
	    Damage = 1f;
	    TimeToFire = 0f;

	}
	
	// Update is called once per frame
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
	        if(Input.GetMouseButtonDown(0) && Time.deltaTime > TimeToFire)
	        {
	            TimeToFire = Time.time + 1 / FireRate;
	            shoot();
	        }
        }
	    FirePoint = cosmo.cosmoTransform;
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
