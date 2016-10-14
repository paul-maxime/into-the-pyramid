using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestructionSpell : MonoBehaviour
{
    public GameObject DestructionMissile;
    public AudioClip ThrowSound;
    public float ReloadTime;

    private AudioSource _audio;
    private float _reloadTime;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (_reloadTime < 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _reloadTime = ReloadTime;
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                GameObject obj = Instantiate(DestructionMissile);
                obj.transform.localPosition = transform.position + ray.direction.normalized * 1.5f;
                obj.GetComponent<BasicMovement>().PositionVelocity = ray.direction.normalized * 20.0f;
                _audio.PlayOneShot(ThrowSound);
            }
        }
        else
        {
            _reloadTime -= Time.deltaTime;
        }
    }
}
