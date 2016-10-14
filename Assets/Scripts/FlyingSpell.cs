using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(FirstPersonController))]
[RequireComponent(typeof(AudioSource))]
public class FlyingSpell : MonoBehaviour
{
    public Light FlyLight;
    public MeshRenderer FlyEffect;
    public AudioClip FlySound;

    private CharacterController _controller;
    private FirstPersonController _firstPerson;
    private AudioSource _audio;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _firstPerson = GetComponent<FirstPersonController>();
        _audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (!_controller.isGrounded && !_firstPerson.JustJumped)
        {
            if (!_firstPerson.Flying)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _audio.PlayOneShot(FlySound);
                    _firstPerson.Flying = true;
                    FlyLight.enabled = true;
                    FlyEffect.enabled = true;
                }
            }
            else
            {
                _firstPerson.Flying = Input.GetButton("Jump");
                FlyLight.enabled = _firstPerson.Flying;
                FlyEffect.enabled = _firstPerson.Flying;
            }
        }
        else if (_firstPerson.Flying)
        {
            _firstPerson.Flying = false;
            FlyLight.enabled = false;
            FlyEffect.enabled = false;
        }
    }
}
