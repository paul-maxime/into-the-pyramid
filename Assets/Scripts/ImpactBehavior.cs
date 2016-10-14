using UnityEngine;

public class ImpactBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            float impactForce = rigidbody.velocity.sqrMagnitude * rigidbody.mass;
            if (impactForce > 80.0f)
            {
                GameManager.GetInstance().Die();
            }
        }
    }
}