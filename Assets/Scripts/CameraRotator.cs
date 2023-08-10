using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private TargetDetector _targetDetector;
    private Vector3 _offset = new Vector3(1,1,0);
    private float cameraFollowResistance = 50f;
    private Vector3 _lookAtPoint;
    private float _distance = 10;
    private bool _isLookAtTarget;
    private List<Transform> _enemiesPosition;
    private Transform _currentTarget;

    private PlayerInputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new PlayerInputSystem();
        _enemiesPosition = _targetDetector.EnemiesPosition;
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
        var distance = (transform.localPosition - _lookAtPoint).magnitude;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _lookAtPoint, distance / cameraFollowResistance);
    }

    private float Zoom—oefficient()
    {
        var distanceToTarget = (_player.transform.position - _currentTarget.transform.position).magnitude;
        var coefficient = _distance * distanceToTarget / 100;
        if (coefficient < 1)
            return 1;
        return coefficient;
    }
    private void FreeRotationCondition()
    {
        var inputDirection = _inputSystem.Movement.Look.ReadValue<Vector2>().normalized;
        var lookDirection = new Vector3(-inputDirection.y,0, inputDirection.x) * _distance / 5; 
        _lookAtPoint = (_player.transform.position + lookDirection) + _offset * _distance;
    }
    private void LookAtTarget()
    {
        if (_currentTarget == null || _enemiesPosition.Count == 0)
            SwichLookMode(false);
        else
            _lookAtPoint = (_player.transform.position + _currentTarget.position)/2 
                + _offset * Zoom—oefficient() * _distance;
        if (_inputSystem.Movement.ChangeTarget.triggered)
            ChangeCurrentTarget(_inputSystem.Movement.Look.ReadValue<Vector2>());
    }
    private void ChangeCurrentTarget()
    {
        _currentTarget = FindNearestTarget();
    }
    private void ChangeCurrentTarget(Vector2 direction)
    {
        direction.Normalize();
        if (_enemiesPosition.Count != 0)
        {
            float inputDegree = Mathf.Acos(direction.x) * Mathf.Rad2Deg * Mathf.Sign(direction.y);
            var newTarget = _currentTarget;
            var minDegree = 361f;

            foreach (var target in _enemiesPosition)
            {
                if (target == _currentTarget)
                    continue;
                var angelToTarget = AngleToTarget(target);
                var firstAngle = Mathf.Abs(angelToTarget - inputDegree);
                if (inputDegree < 0)
                    inputDegree += 360;
                if (angelToTarget < 0)
                    angelToTarget += 360;
                var secondAngle = Mathf.Abs(angelToTarget - inputDegree);
                float deltaDegree;
                if (firstAngle - secondAngle < 5f)
                    deltaDegree = firstAngle;
                else
                    deltaDegree = Mathf.Min(firstAngle, secondAngle);
                if (deltaDegree < minDegree)
                {
                    newTarget = target;
                    minDegree = deltaDegree;
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
        var vectorBetweenPlayerAndTarget = target.position - _player.transform.position;
        var cameraForward = transform.forward;
        vectorBetweenPlayerAndTarget.y = 0;
        cameraForward.y = 0;
        return -Vector3.SignedAngle(Vector3.forward, vectorBetweenPlayerAndTarget,Vector3.up);
    }
}
