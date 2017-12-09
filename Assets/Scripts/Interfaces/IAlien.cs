using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IAlien
    {
        int healthLeft { get; set; }
        int accuracy { get; set; }
        int speed { get; set; }

        void OnTriggerEnter(Collider collider);
    }
}
