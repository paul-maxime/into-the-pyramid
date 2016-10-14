using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public GameObject Explosion;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<DestructionMissile>() != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
