using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float DodgeChance;
    [SerializeField] private TargetDetector _targetDetector;
    protected Rigidbody Rigidbody;
    protected GameObject[] Targets;
    protected float Health;
    public UnityEvent Dead;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        SetTargets();
        Dead.AddListener(_targetDetector.ClearTargetList);
    }

    protected void SetTargets()
    {
        Targets = GameObject.FindGameObjectsWithTag("Player");
    }
    protected GameObject GetNearestTarget(GameObject[] targets)
    {
        if (targets.Length == 0)
            return null;
        var nearestTarget = targets[0];
        var minDistance = Vector3.Magnitude(targets[0].transform.position - transform.position);
        foreach (GameObject target in targets)
        {
            var distance = Vector3.Magnitude(target.transform.position - transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = target;
            }
        }
        return nearestTarget;
    }
    public virtual void ApplyDamage(float damage)
    {
        if (Dodge(DodgeChance))
        {
            Health -= damage;
            if (Health <= 0)
            {
                Destroy(gameObject);

            }
        } 
        else
        {
            Debug.Log("Enemy " + Name + " dodge");
        }
    }

    protected virtual bool Dodge(float dodgeChance)
    {       
        if (Random.Range(0, 1f) > dodgeChance)
            return true;
        return false;
    }

    public virtual void Attack()
    {

    }

    private void OnDestroy()
    {
        Dead.Invoke();
    }
}

public interface IFollowable
{
    public NavMeshAgent navMeshAgent { get; set; }
}