using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private int bulletSpeed = 75;
    public int bulletForce = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
	}
}
