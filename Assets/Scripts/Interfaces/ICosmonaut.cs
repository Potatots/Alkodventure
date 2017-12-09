using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ICosmonaut {
        string CosmonautName { get; set; }

        int Adrenalin { get; set; }
        int Happiness { get; set; }
        int Alcohol { get; set; }

        int AmmoLeft { get; set; }
        int HealthLeft { get; set; }

        float MovementSpeed { get; set; }
        float RotationSpeed { get; set; }

        float MaxSpeed { get; set; }
        int MaxValue { get; set; } //max Value of adrenalin/endorfines/alcohol
        int MaxHealth { get; set; }
        int MaxAmmo { get; set; }

        float MoveVertical { get; set; }
        float MoveHorizontal { get; set; }

        Color StandardLightColor { get; set; }

        Rigidbody2D CosmoRigidbody { get; set; }
        Transform CosmoTransform { get; set; }
        Vector2 Movement { get; set; }

        void OnTriggerEnter2D(Collider2D collider);
    }
}
