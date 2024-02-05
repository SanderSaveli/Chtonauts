using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExploreMove
{
    public float explorationRadius;
    public float avoidanceRadius;

    private NavMeshAgent agent;
    private HashSet<Vector3> visitedLocations = new HashSet<Vector3>();
    private Stack<Vector3> rememberedLocations;
    private Vector3 position => agent.transform.position;

    public ExploreMove(NavMeshAgent agent, HashSet<Vector3> visitedLocations, Stack<Vector3> rememberedLocations, float explorationRadius, float avoidanceRadius)
    {
        this.agent = agent;
        this.visitedLocations = visitedLocations;
        this.avoidanceRadius = avoidanceRadius;
        this.explorationRadius = explorationRadius;
        this.rememberedLocations = rememberedLocations;
    }
    public void StartMove()
    {
        SetRandomDestination();
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * explorationRadius;
        randomDirection += position;

        Vector3 targetLocation = FindNearestUnvisitedLocation(randomDirection);

        agent.SetDestination(targetLocation);
    }

    Vector3 FindNearestUnvisitedLocation(Vector3 targetLocation)
    {
        NavMesh.SamplePosition(targetLocation, out NavMeshHit hit, explorationRadius, NavMesh.AllAreas);

        Vector3 nearestUnvisitedLocation = hit.position;

        int i = 0;
        while (IsTooCloseToVisitedLocations(nearestUnvisitedLocation, avoidanceRadius))
        {
            i++;
            if(i == 20)
            {
                for(int j = 0; j < rememberedLocations.Count; j++)
                {
                    nearestUnvisitedLocation = rememberedLocations.Pop();
                    if (!visitedLocations.Contains(nearestUnvisitedLocation))
                    {
                        return nearestUnvisitedLocation;
                    }
                }
                return agent.transform.position;
            }
            NavMesh.SamplePosition(Random.insideUnitSphere * explorationRadius + position, out hit, explorationRadius, NavMesh.AllAreas);
            nearestUnvisitedLocation = hit.position;
        }
        return nearestUnvisitedLocation;
    }

    bool IsTooCloseToVisitedLocations(Vector3 point, float radius)
    {
        foreach (Vector3 visitedLocation in visitedLocations)
        {
            if (Vector3.Distance(point, visitedLocation) < radius)
            {
                return true;
            }
        }
        return false;
    }
}
