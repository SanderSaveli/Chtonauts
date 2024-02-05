using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveController : MonoBehaviour
{
    public float explorationRadius = 5f;
    public float avoidanceRadius = 2f;
    public float stopDistanceFromWalls = 1.5f;
    public float handDistance = 1f;

    public float visitedRadius = 3f;
    public float rememberRadius = 7f;
    public float updateInterval = 1f;

    private NavMeshAgent agent;
    private HashSet<Vector3> visitedLocations = new HashSet<Vector3>();
    private Stack<Vector3> rememberedLocations = new Stack<Vector3>();


    private MoveToTarget toTarget;
    private ExploreMove exploreMove;
    bool isAcktive;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        toTarget = new(agent);
        exploreMove = new(agent, visitedLocations, rememberedLocations, explorationRadius, avoidanceRadius);
        exploreMove.StartMove();
        isAcktive = true;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < handDistance)
        {
            if(isAcktive)
            {
                CameToPosition(agent.destination);
            }
        }
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updateInterval)
        {
            elapsedTime = 0f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, visitedRadius);

            foreach (Collider col in colliders)
            {
                if (col.TryGetComponent(out FloorCell floorCell))
                {
                    visitedLocations.Add(floorCell.transform.position);
                }
            }

            colliders = Physics.OverlapSphere(transform.position, rememberRadius);
            foreach (Collider col in colliders)
            {
                if (col.TryGetComponent(out FloorCell floorCell))
                {
                    if (!visitedLocations.Contains(floorCell.transform.position))
                    {
                        rememberedLocations.Push(floorCell.transform.position);
                    }
                }
            }
        }
    }

    private void CameToPosition(Vector3 pos)
    {
        if(pos!= agent.transform.position)
        {
            exploreMove.StartMove();
            Debug.Log(pos);
        }
        else
        {
            isAcktive = false;
            Debug.LogWarning("All location visited");
        }
    }

    private float elapsedTime = 0f;


}
