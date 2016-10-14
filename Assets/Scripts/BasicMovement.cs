using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Vector3 PositionVelocity;
    public Vector3 RotationVelocity;

    void Update()
    {
        transform.localPosition += PositionVelocity * Time.deltaTime;
        transform.Rotate(RotationVelocity * Time.deltaTime);
    }
}
