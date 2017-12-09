﻿using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour {

		public GameObject wall;
		public GameObject bottle;
		public GameObject[] floors;
		public  int width = 10;
		public  int height = 10;
		private  int tileSize = 5;
		public 	int  bottleFactor = 10;
		private int bottleFrequency;

	

	
		void Awake() {

			bottleFrequency = (width * height) / bottleFactor;
		}
		 
		void Start() {
			initialize ();
		}

		void initialize() {
			
			/*wall.transform.localScale = new Vector3 (1/tileSize, 1/tileSize, 1);
			wall.transform.localScale = new Vector3 ((0.2f * tileSize), (0.2f * tileSize), 1);
			for (int i = 0; i < floors.Length; i++) {
				floors[i].transform.localScale = new Vector3 ((1.0f * tileSize), (1.0f * tileSize), 1);
			}*/


			for (int i = 0; i < bottleFrequency; i++) {
				int x = Random.Range (1, width - 1);
				int y = Random.Range (1, height - 1);
				Instantiate(bottle, new Vector3(x * tileSize, y * tileSize, 0.5f), Quaternion.identity); 
					
			}

			for (int x = 0; x < width; x++) {
				Instantiate(wall, new Vector3(x*tileSize, 0, 1), Quaternion.identity);
				Instantiate(wall, new Vector3(x*tileSize, height*tileSize, 1), Quaternion.identity);	
			}
				
			for (int y = 1; y < height; y++) {
				Instantiate(wall, new Vector3(0, y * tileSize, 1), Quaternion.identity);
				Instantiate(wall, new Vector3((width - 1) * tileSize, y * tileSize, 1), Quaternion.identity);
			}

			for (int x = 1; x < width - 1 ; x++) {
				for (int y = 1; y < height; y++) {
					Instantiate(floors[Random.Range(0, floors.Length)], new Vector3(x*tileSize, y*tileSize, 1), Quaternion.identity);
				}
			}
	
		
		}
        
	
        
    }
}