using UnityEngine;

public class PowerUnlockerBehavior : MonoBehaviour
{
    public string PowerType;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            ((MonoBehaviour)collider.GetComponent(PowerType)).enabled = true;
            Destroy(gameObject);
            GameManager.GetInstance().PlayUpgrade();
        }
    }
}
