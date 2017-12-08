using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class SimpleAlien : MonoBehaviour, IAlien 
    {
        public int healthLeft { get; set; }
        public int accuracy { get; set; }
        public int speed { get; set; }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
