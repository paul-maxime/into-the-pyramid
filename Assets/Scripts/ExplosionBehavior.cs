using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float LifeSpan;
    public float KillDistance;

    private float _age;

    private Light _light;

    void Start()
    {
        Destroy(gameObject, LifeSpan);

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < KillDistance)
            {
                GameManager.GetInstance().Die();
            }
        }

        _light = GetComponent<Light>();
    }

    void Update()
    {
        _light.intensity -= Time.deltaTime * 1.5f;
        _light.range -= Time.deltaTime * 15f;
    }
}
