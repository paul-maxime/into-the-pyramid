using UnityEngine;

public class PoisonBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            GameManager.GetInstance().Die();
        }
    }
}
