using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Cosmonaut;

public class UIManager : MonoBehaviour {

	private GameObject cosmonaut ;
	private Cosmonaut cosmoscript;
	private int alcohol;
	private int health;
	private int ammo;
	private int happiness;
	public Slider alcobar;
	public Slider healthbar;
	public Slider ammobar;
	public Slider happyBar;

	void Start () {
		cosmonaut = GameObject.Find("Astronaut");
	}



	void Update () {
		alcohol = cosmonaut.GetComponent<Cosmonaut> ().Alcohol;
		health = cosmonaut.GetComponent<Cosmonaut> ().HealthLeft;
		ammo = cosmonaut.GetComponent<Cosmonaut> ().AmmoLeft;
		happiness = cosmonaut.GetComponent<Cosmonaut> ().Happiness;

		if (alcohol <= 0)
			alcohol = 0;
		if (alcohol >= 100)
			alcohol = 100;

		if (health <= 0)
			health = 0;
		if (health >= 100)
			health = 100;

		if (ammo <= 0)
			ammo = 0;
		if (ammo >= 100)
			ammo= 100;

		if (happiness <= 0)
			happiness = 0;
		if (happiness >= 100)
			happiness= 100;

		alcobar.value = alcohol / 100.0f;
		healthbar.value = health/ 100.0f;
		ammobar.value = ammo / 100.0f;
		happyBar.value = happiness / 100.0f;

	}
}
