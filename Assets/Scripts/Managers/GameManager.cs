using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        private BoardManager boardScript;

        public int AlcoholStrength;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if(instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            boardScript = GetComponent<BoardManager>();

            initGame();
        }

        private void initGame()
        {
            
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
