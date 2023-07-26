using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _pivot;
    private Camera _camera;
    private Vector3 _offset = new Vector3(0,2,-5);
    private float _verticalSpeed = 100;
    private float _horizontalSpeed = 200;
    private readonly int _maxYRotation = 70;
    private readonly int _minYRotation = -10;
    private readonly int _followingSpeed = 30;
    private Vector3 _rotationDirection = Vector3.zero;
    private bool _isLookAtTarget;
    private List<Transform> _enemiesPosition = new List<Transform>();
    private Transform _currentTarget;

    private PlayerInputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new PlayerInputSystem();
        _camera = Camera.main;
        _camera.transform.localPosition = _offset;
        SwichLookMode(false);

        _inputSystem.Movement.Target.performed += ctx => SwichLookMode(!_isLookAtTarget);
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
        inputValue.Normalize();
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
    private void LookAtTarget()
    {
        if (_enemiesPosition.Count > 0)
        {
            if (_currentTarget == null || !_currentTarget.gameObject.activeSelf)
            {
                ChangeCurrentTarget();
            }
        }
        else
        {
            SwichLookMode(false);
            return;
        }
        if (_inputSystem.Movement.ChangeTarget.triggered)
        {
            var inputDirection = _inputSystem.Movement.Look.ReadValue<Vector2>();
            ChangeCurrentTarget(inputDirection);
        }
        var lookAtPoint = (_currentTarget.position + _player.transform.position)/2f;
        lookAtPoint.y -= 0.5f;
        _pivot.transform.LookAt(lookAtPoint);
    }

    private void ChangeCurrentTarget()
    {
        _currentTarget = FindNearestTarget();
    }
    private void ChangeCurrentTarget(Vector2 direction)
    {
        if (_enemiesPosition.Count != 0)
        {
            float axisX = Mathf.Sign(direction.x);
            var newTarget = _currentTarget;
            var minDegree = 361f;
            foreach (var target in _enemiesPosition)
            {
                if (target == _currentTarget)
                    continue;
                var angleToTarget = AngleToTarget(target);
                if (angleToTarget * axisX >= 0 && Mathf.Abs(angleToTarget) < minDegree)
                {
                    newTarget = target;
                    minDegree = angleToTarget;
                }
            }
            _currentTarget = newTarget;
        }
        else
            _currentTarget = null;
    }

    private void SwichLookMode(bool lookAtTargetEnable)
    {
        ChangeCurrentTarget();
        if (_currentTarget == null)
            _isLookAtTarget = false;
        else
            _isLookAtTarget = lookAtTargetEnable;

        _rotationDirection = _pivot.transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        _enemiesPosition.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        _enemiesPosition.Remove(other.transform);
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }
    private Transform FindNearestTarget()
    {
        if (_enemiesPosition.Count == 0)
            return null;
        Transform nearestTarget = _enemiesPosition[0];
        var minDistance = (_enemiesPosition[0].position - _player.transform.position).magnitude;
        foreach (var target in _enemiesPosition)
        {
            var distance = (target.position - _player.transform.position).magnitude;
            if (distance < minDistance && Mathf.Abs(AngleToTarget(target)) < 120)
            {
                nearestTarget = target;
                minDistance = distance;
            }
        }
        return nearestTarget;
    }

    private float AngleToTarget(Transform target)
    {
        var vectorBetweenPlayerAndTarget = target.position - transform.position;
        var cameraForward = transform.forward;
        vectorBetweenPlayerAndTarget.y = 0;
        cameraForward.y = 0;
        return Vector3.SignedAngle(cameraForward, vectorBetweenPlayerAndTarget,Vector3.up);
    }

    public void ClearTargetList()
    {
        for (int i = 0; i < _enemiesPosition.Count; i++)
        {
            if (!_enemiesPosition[i].gameObject.activeSelf)
            {
                _enemiesPosition.Remove(_enemiesPosition[i]);
            }
        }
    }
}
