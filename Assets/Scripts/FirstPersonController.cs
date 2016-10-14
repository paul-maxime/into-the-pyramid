using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class FirstPersonController : MonoBehaviour
{
    public float Speed;
    public float AirForce;
    public float RotationSpeed;
    public float Gravity;
    public float JumpSpeed;
    public float CameraSpeed;
    public bool CanMove = true;

    public AudioClip[] StepSounds;
    public AudioClip JumpSound;

    public bool Flying { get; set; }
    public bool JustJumped { get; private set; }

    private CharacterController _controller;
    private AudioSource _audio;
    private Vector3 _moveDirection = Vector3.zero;
    private float _stepSoundDelay;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleCursorLocking();

        if (CanMove)
        {
            ApplyInputMovement();
            ApplyCameraMovement();
        }
        else
        {
            ResetMovement();
        }
        MoveCharacter();
    }

    private void HandleCursorLocking()
    {
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetButtonDown("Cancel") && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Cursor.visible = Cursor.lockState != CursorLockMode.Locked;
    }

    public void ResetMovement()
    {
        if (_controller.isGrounded)
        {
            _moveDirection = Vector3.zero;
        }
    }

    private void ApplyInputMovement()
    {
        JustJumped = false;
        if (_controller.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= Speed;
            if (_moveDirection != Vector3.zero)
            {
                _stepSoundDelay -= Time.deltaTime;
                if (_stepSoundDelay < 0)
                {
                    _stepSoundDelay = 0.3f;
                    _audio.PlayOneShot(StepSounds[Random.Range(0, StepSounds.Length)], 0.5f);
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                _audio.PlayOneShot(JumpSound);
                _moveDirection.y = JumpSpeed;
                JustJumped = true;
            }
        }
        else
        {
            Vector3 airMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            airMovement = transform.TransformDirection(airMovement);
            airMovement *= AirForce;
            Vector3 newMovement = _moveDirection + airMovement;
            if (newMovement.sqrMagnitude < _moveDirection.sqrMagnitude)
            {
                _moveDirection = newMovement;
            }
        }

        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotation * Time.deltaTime * RotationSpeed);
    }

    private void MoveCharacter()
    {
        if (!Flying)
            _moveDirection.y -= Gravity * Time.deltaTime;

        Vector3 realTranslation = _moveDirection;
        if (Flying)
        {
            realTranslation = new Vector3(realTranslation.x, 0, realTranslation.z);
        }
        _controller.Move(realTranslation * Time.deltaTime);
    }

    private void ApplyCameraMovement()
    {
        Vector3 verticalRotation = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        Camera.main.transform.Rotate(verticalRotation * Time.deltaTime * CameraSpeed);
        if (Camera.main.transform.localEulerAngles.y > 90)
        {
            if (Camera.main.transform.localEulerAngles.x < 180)
            {
                Camera.main.transform.localEulerAngles = new Vector3(90, 0, 0);
            }
            else
            {
                Camera.main.transform.localEulerAngles = new Vector3(270, 0, 0);
            }
        }
    }
}