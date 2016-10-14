using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class MovableObject : MonoBehaviour
{
    public Material DefaultMaterial;
    public Material SelectedMaterial;

    private MeshRenderer _renderer;
    private Rigidbody _rigidbody;
    private bool _isSelected;

    public void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                _renderer.material = _isSelected ? SelectedMaterial : DefaultMaterial;
                _rigidbody.useGravity = !value;
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }

    public Color Color
    {
        get { return _renderer.material.GetColor("_MKGlowColor"); }
        set
        {
            _renderer.material.SetColor("_MKGlowColor", value);
        }
    }
}
