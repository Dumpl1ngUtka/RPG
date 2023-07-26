using UnityEngine;
using UnityEngine.AI;

public abstract class Humanoid : Enemy, IFollowable
{
    public NavMeshAgent navMeshAgent {  get;  set; }
    protected float StoppingDistace = 3f;
    protected GameObject Target;
    protected Vector3 followingPosition;

    private void OnEnable()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = StoppingDistace;
        Target = GetNearestTarget(Targets);
        followingPosition = Target.transform.position;
        navMeshAgent.SetDestination(followingPosition);
    }

    protected void Update()
    {
        if (DistanceBetween(followingPosition, Target.transform.position) >= 
            DistanceBetween(transform.position, Target.transform.position)/3)
            UpdateFollowingPosition();
        if (DistanceBetween(transform.position, Target.transform.position) <= StoppingDistace * 1.2f)
            Debug.Log("ReadyToAttack");
    }

    private void UpdateFollowingPosition()
    {
        followingPosition = Target.transform.position;
        navMeshAgent.SetDestination(followingPosition);
    }

    public float DistanceBetween(Vector3 firstPoint,Vector3 secondPoint)
    {
        return (firstPoint - secondPoint).magnitude;
    }
}
