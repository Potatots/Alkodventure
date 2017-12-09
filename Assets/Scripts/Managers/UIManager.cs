using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Cosmonaut;

public class UIManager : MonoBehaviour {

	private GameObject cosmonaut ;
	private Cosmonaut cosmoscript;
	private int a;

	void Start () {
		cosmonaut = GameObject.Find("Cosmonaut");
		a = cosmonaut.GetComponent<Cosmonaut> ().Adrenalin;

		Debug.Log("adrenalin " + a);
		
	}
	

	void Update () {
		Debug.Log(a);
	}
}
