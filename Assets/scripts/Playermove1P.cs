using UnityEngine;
using UnityEngine.InputSystem;

class Playermove1P : MonoBehaviour
{
    private InputAction _moveAction;
    [SerializeField] private float _speed = 10f;
    private Transform _Tr;

    private void Start()
    {
        _Tr = transform;
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 _moveValue = _moveAction.ReadValue<Vector2>();
        Vector3 _move = new Vector3(_moveValue.x, 0f, _moveValue.y) * _speed * Time.deltaTime;
        _Tr.Translate(_move);
    }
}
