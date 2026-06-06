using UnityEngine;
using UnityEngine.InputSystem;

public class RobotRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.3f;
    private float _lastMouseX;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            float delta = Mouse.current.delta.x.ReadValue();
            transform.Rotate(Vector3.up, -delta * _rotationSpeed);
        }
    }
}