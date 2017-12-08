using UnityEngine;

namespace Assets.Scripts
{
    public class Cosmonaut : MonoBehaviour, ICosmonaut {
        public string CosmonautName { get; set; }

        public int Adrenalin { get; set; }
        public int Endorfines { get; set; }
        public int Alcohol { get; set; }

        public int AmmoLeft { get; set; }
        public int HealthLeft { get; set; }

        public int Accuracy { get; set; }
        public int Speed { get; set; }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
