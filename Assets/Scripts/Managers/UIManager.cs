using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Cosmonaut;

public class UIManager : MonoBehaviour {

	private GameObject cosmonaut ;
	private Cosmonaut cosmoscript;
	private int adrenalin;
	private int health;
	private int happiness;


	void Start () {
		cosmonaut = GameObject.Find("Cosmonaut");
		
	}
	
	private void updateValue (ref int someValue) {

		if (someValue <= 0)
			someValue = 0;
		if (someValue >= 100)
			someValue = 100;
	}

	void Update () {

		adrenalin = cosmonaut.GetComponent<Cosmonaut> ().Adrenalin;
		health = cosmonaut.GetComponent<Cosmonaut> ().Alcohol;
		happiness = cosmonaut.GetComponent<Cosmonaut> ().HealthLeft;
		updateValue (ref adrenalin);
		updateValue (ref health);
		updateValue (ref happiness);

		Debug.Log ("adrenalin: " + adrenalin + " health: " + health + "happiness: " + happiness); 

	}
}
