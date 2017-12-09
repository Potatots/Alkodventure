using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Cosmonaut;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private GameObject cosmonaut ;
	private Cosmonaut cosmoscript;
	private int adrenalin;
	private int health;
	private int alcohol;
	private int happiness;
	public Slider adrenalinImage;
	public Slider healthImage;
	public Slider happinessImage;
	public Slider alcoImage;


	[SerializeField]
	private float  fill = 0.2f;


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
		alcohol = cosmonaut.GetComponent<Cosmonaut> ().Alcohol;
		updateValue (ref adrenalin);
		updateValue (ref health);
		updateValue (ref happiness);
		updateValue (ref alcohol);

		Debug.Log ("adrenalin: " + adrenalin + " health: " + health + "happiness: " + happiness); 

		adrenalinImage.value = (float) (adrenalin / 100.0f);
		healthImage.value =(float)  (health / 100.0f);
		happinessImage.value =(float)  (happiness / 100.0f);
		alcoImage.value =(float) ( alcohol/ 100.0f);


	}
}
