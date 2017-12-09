using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Aliens;

namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour {

		public GameObject wall;
		public GameObject bottle;
        public GameObject[] aliensList;
		public GameObject[] floors;
		public  int width = 10;
		public  int height = 10;
		public 	int  bottleFactor = 7;
        private int numberOfAliens = 150;
		private int bottleFrequency;
		private  float tileSize = 2.58f;
		private static int maxWidth = 1000;
		private static int maxHeight = 1000;
		bool[,] isObstacle;
	
		void Awake() {
			bottleFrequency = (width * height) / bottleFactor;
			isObstacle = new bool[maxWidth , maxHeight];
		}
		 
		void Start() {
			initialize ();
		}

        void generateAliens()
        {
            for (int i = 0; i < numberOfAliens; i++)
            {
                int x = Random.Range(1, width - 1);
                int y = Random.Range(1, height - 1);
                Instantiate(aliensList[Random.Range(0,aliensList.Length)], new Vector3(x * tileSize, y * tileSize,0), Quaternion.identity);
                isObstacle[(int)x, (int)y] = false;
            }
        }

		void initialize() {

			//some broken scaling
			/*wall.transform.localScale = new Vector3 (1/tileSize, 1/tileSize, 1);
			wall.transform.localScale = new Vector3 ((0.2f * tileSize), (0.2f * tileSize), 1);
			for (int i = 0; i < floors.Length; i++) {
				floors[i].transform.localScale = new Vector3 ((1.0f * tileSize), (1.0f * tileSize), 1);
			}*/


			//instatitating walls
			for (int x = 0; x < width; x++) {
				Instantiate(wall, new Vector3(x*tileSize, 0, 0), Quaternion.identity);
				Instantiate(wall, new Vector3(x*tileSize, height*tileSize, 0), Quaternion.identity);	
			}
				
			for (int y = 1; y < height; y++) {
				Instantiate(wall, new Vector3(0, y * tileSize, 0), Quaternion.identity);
				Instantiate(wall, new Vector3((width - 1) * tileSize, y * tileSize, 0), Quaternion.identity);
			}


			//filling the bstacle bool array and instantiating the floor
		    for (int x = 1; x < width - 1; x++)
		    {
		        for (int y = 1; y < height; y++)
		        {
		            int random = Random.Range(0, floors.Length + 1);
		            if (random >= floors.Length)
		            {
		                isObstacle[x, y] = true;
		            }
		            Instantiate(floors[Random.Range(0, floors.Length - 1)], new Vector3(x * tileSize, y * tileSize, 1),
		                Quaternion.identity);

		        }
		    }
		    //preventing from instatinating obstacles where the player is.
			isObstacle [1, 1] = false;
			isObstacle [1, 2] = false;
			isObstacle [2, 1] = false;
			isObstacle [2, 2] = false;

		    generateAliens();

            //initiating obstacles (inside walls)
            for(int x = 1; x < width - 1 ; x++) {
				for (int y = 1; y < height; y++) {
					if(isObstacle[x,y])
						Instantiate(wall, new Vector3(x*tileSize, y*tileSize, 0), Quaternion.identity);
				}
			}
				
			//instantiating bottles, where ther is no obstacle
			for (int i = 0; i < bottleFrequency; i++) {
				int x = Random.Range (1, width - 1);
				int y = Random.Range (1, height - 1);
				if(!isObstacle[x , y]) {
					Instantiate(bottle, new Vector3(x * tileSize, y * tileSize, 0.5f), Quaternion.identity); 
				}
			}
		}
    }
}
