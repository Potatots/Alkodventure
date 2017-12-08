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

    float Speed { get; set; }

    float maxSpeed { get; set; }
    int maxValue { get; set; } //max Value of adrenalin/endorfines/alcohol
    int maxHealth { get; set; }
    int maxAmmo { get; set; }

    Rigidbody2D CosmoRigidbody { get; set; }
}
