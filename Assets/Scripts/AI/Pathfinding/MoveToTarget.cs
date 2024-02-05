using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget
{
    protected NavMeshAgent agent;
    public MoveToTarget(NavMeshAgent agent)
    {
        this.agent = agent;
    }
    public void StartMove(Vector3 target)
    {
        agent.SetDestination(target);
    }

}
