using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICosmonaut {

    string CosmonautName { get; set; }

    int Adrenalin { get; set; }
    int Endorfines { get; set; }
    int Alcohol { get; set; }
    int Accuracy { get; set; }

    int AmmoLeft { get; set; }
    int HealthLeft { get; set; }

    float MovementSpeed { get; set; }
    float RotationSpeed { get; set; }

    float MaxSpeed { get; set; }
    int MaxValue { get; set; } //max Value of adrenalin/endorfines/alcohol
    int MaxHealth { get; set; }
    int MaxAmmo { get; set; }

    Rigidbody2D CosmoRigidbody { get; set; }
}
