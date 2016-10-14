using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpotlightBehavior : MonoBehaviour
{
    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Spotlight"))
        {
            _light.enabled = !_light.enabled;
        }
    }
}
