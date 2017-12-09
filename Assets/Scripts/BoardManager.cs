using UnityEngine;

namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour {

		public GameObject wall;
		public GameObject[] floors;
		public int width = 10;
		public int height = 10;
		public int tileSize = 5;
	

		void Start() {
			initialize ();
		}

		void initialize() {
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
