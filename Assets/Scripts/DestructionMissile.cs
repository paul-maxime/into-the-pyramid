using UnityEngine;

public class DestructionMissile : MonoBehaviour
{
    public GameObject Explosion;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<DestructibleObject>() == null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
