﻿using UnityEngine;

namespace Assets.Scripts
{
    public class CameraManager : MonoBehaviour
    {
        public GameObject player;
        private Vector3 offset;

        // Use this for initialization
        void Start ()
        {
            offset = transform.position - player.transform.position;
        }
	
        // Update is called once per frame
        void LateUpdate ()
        {
            transform.position = player.transform.position + offset;
        }
    }
}