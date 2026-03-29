using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate1P : MonoBehaviour
{
    [SerializeField] private GameObject _player1P;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _minVerticalAngle = -30f; 
    [SerializeField] private float _maxVerticalAngle = 60f;  

    private Transform _Tr;
    private InputAction _cameraAction;
    private float _verticalAngle = 0f;

    private void Start()
    {
        _Tr = transform;
        _cameraAction = InputSystem.actions.FindAction("CameraMove");
        if (_cameraAction == null) Debug.LogError("CameraMoveƒAƒNƒVƒ‡ƒ“‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
    }

    private void Update()
    {
        Vector2 input = _cameraAction.ReadValue<Vector2>();

        _Tr.RotateAround(_player1P.transform.position, Vector3.up, input.x * _speed * Time.deltaTime);

        float newAngle = _verticalAngle - input.y * _speed * Time.deltaTime;
        newAngle = Mathf.Clamp(newAngle, _minVerticalAngle, _maxVerticalAngle);
        float delta = newAngle - _verticalAngle;
        _verticalAngle = newAngle;

        _Tr.RotateAround(_player1P.transform.position, _Tr.right, delta);
    }
}