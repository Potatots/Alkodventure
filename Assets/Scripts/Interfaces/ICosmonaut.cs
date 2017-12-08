using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICosmonaut {

    string CosmonautName { get; set; }

    int Adrenalin { get; set; }
    int Endorfines { get; set; }
    int Alcohol { get; set; }

    int AmmoLeft { get; set; }
    int HealthLeft { get; set; }

    int Accuracy { get; set; }
    int Speed { get; set; }
}
