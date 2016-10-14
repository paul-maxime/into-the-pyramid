using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MovingSpell : MonoBehaviour
{
    public Light Light;
    public Color Color;
    public AudioClip SelectSound;

    private AudioSource _audio;
    private MovableObject _selection;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (_selection != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                UnselectObject();
            }
            else
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, 100.0f) || _selection.transform != hit.transform)
                {
                    UnselectObject();

                }
                else
                {
                    float scroll = Input.GetAxis("Mouse ScrollWheel");
                    if (scroll != 0.0f)
                    {
                        Vector3 delta = _selection.transform.position - transform.position;
                        delta = delta / 5.0f;
                        _selection.transform.position += delta * scroll;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                SelectObject(hit.collider);
            }
        }
    }

    private void SelectObject(Component selectable)
    {
        _selection = selectable.GetComponent<MovableObject>();
        if (_selection != null)
        {
            _audio.PlayOneShot(SelectSound);

            _selection.IsSelected = true;
            _selection.transform.parent = Camera.main.transform;
            _selection.Color = Color;
            Light.enabled = true;
            Light.color = Color;
            Light.transform.parent = _selection.transform;
            Light.transform.localPosition = Vector3.zero;
        }
    }

    private void UnselectObject()
    {
        _selection.IsSelected = false;
        _selection.transform.parent = null;
        _selection = null;
        Light.enabled = false;
        Light.transform.parent = transform;
    }
}
