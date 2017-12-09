using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IAlien
    {
        int HealthLeft { get; set; }
        int Accuracy { get; set; }
        float MovementSpeed { get; set; }
        int RotationSpeed { get; set; }
        int AlienForce { get; set; }

        bool WasPlayerDetected { get; set; }

        Transform Target { get; set; }

        void OnTriggerEnter2D(Collider2D collider);
    }
}
