using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour {

	public int rotationSpeed = 30;
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * rotationSpeed);
	}

}
