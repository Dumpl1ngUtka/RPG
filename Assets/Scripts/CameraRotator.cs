using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Camera _camera;
    private float _verticalSpeed = 100;
    private float _horizontalSpeed = 200;
    private int _maxYRotation = 50;
    private int _minYRotation = -10;
    private int _followingSpeed = 10;
    [SerializeField] private GameObject _pivot;
    private Vector3 _rotationDirection = Vector3.zero;
    private bool _isLookAtTarget;
    private List<Transform> _enemiesPosition = new List<Transform>();

    private PlayerInputSystem _inputSystem;
    [SerializeField] private PlayerParameters _player;

    private void Awake()
    {
        _inputSystem = new PlayerInputSystem();
        _camera.transform.localPosition = _offset;
        SwichLookAtTarget(false);

        _inputSystem.Movement.Target.performed += ctx => SwichLookAtTarget();
    }

    private void LateUpdate()
    {
        if (_isLookAtTarget)
        {
            LookAtTarget();
        }
        else
        {
            FreeRotationCondition();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _pivot.transform.rotation,
            Time.deltaTime * _followingSpeed);
    }

    private void FreeRotationCondition()
    {
        var inputValue = _inputSystem.Movement.Look.ReadValue<Vector2>();
        var verticalAxis = -inputValue.y;
        var horizontalAxis = inputValue.x;

        var verticalRotate = verticalAxis * _verticalSpeed * Time.deltaTime;
        var horizontalRotate = horizontalAxis * _horizontalSpeed * Time.deltaTime;

        if (_rotationDirection.x + verticalRotate <= _maxYRotation
            && _rotationDirection.x + verticalRotate >= _minYRotation)
            _rotationDirection.x += verticalRotate;
        _rotationDirection.y += horizontalRotate;
        _pivot.transform.localEulerAngles = _rotationDirection;
    }
    private void OnTriggerEnter(Collider other)
    {
        _enemiesPosition.Add(other.transform);
    }
    private void LookAtTarget()
    {
        if (_enemiesPosition.Count == 0)
        {
            SwichLookAtTarget();
        }
        var lookAtPoint = (_enemiesPosition[0].position + _player.transform.position)/2;
        lookAtPoint.y -= 1;
        _pivot.transform.LookAt(lookAtPoint);
    }

    private void SwichLookAtTarget()
    {
        _isLookAtTarget = !_isLookAtTarget;
        _rotationDirection = _pivot.transform.eulerAngles;
    }
    private void SwichLookAtTarget(bool enable)
    {
        _isLookAtTarget = enable;
        _rotationDirection = _pivot.transform.eulerAngles;
    }
    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }
}
