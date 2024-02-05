using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExploreMove
{
    public float explorationRadius;
    public float avoidanceRadius;

    private Transform agent;
    private HashSet<Vector3> visitedLocations = new HashSet<Vector3>();
    private Stack<Vector3> rememberedLocations;
    private Vector3 position => agent.position;

    public ExploreMove(Transform agent, HashSet<Vector3> visitedLocations, Stack<Vector3> rememberedLocations, float explorationRadius, float avoidanceRadius)
    {
        this.agent = agent;
        this.visitedLocations = visitedLocations;
        this.avoidanceRadius = avoidanceRadius;
        this.explorationRadius = explorationRadius;
        this.rememberedLocations = rememberedLocations;
    }
    public Vector3 GetDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * explorationRadius;
        randomDirection += position;

        return FindNearestUnvisitedLocation(randomDirection);
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
                Debug.LogWarning("all location explorered");
                return Vector3.zero;
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

    public Vector3 GetRandomDestination()
    {
        NavMeshHit hit;
        Vector3 randomPoint;

        do
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f; // Радиус 10, можно изменить
            randomDirection += position;

            // Найти ближайшую непосещенную локацию в пределах NavMesh
            if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
            {
                randomPoint = hit.position;
            }
            else
            {
                randomPoint = position; // В случае неудачи используем текущую позицию
            }
        } while (!IsPointReachable(randomPoint));

        return randomPoint;
    }

    bool IsPointReachable(Vector3 point)
    {
        NavMeshPath path = new NavMeshPath();
        agent.GetComponent<NavMeshAgent>().CalculatePath(point, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }
}
