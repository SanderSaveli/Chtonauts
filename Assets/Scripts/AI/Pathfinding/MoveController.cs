using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveController : MonoBehaviour
{
    public float explorationRadius = 5f;
    public float avoidanceRadius = 2f;
    public float stopDistanceFromWalls = 1.5f;
    public float handDistance = 0f;

    public float visitedRadius = 3f;
    public float rememberRadius = 7f;
    public float updateInterval = 1f;

    private NavMeshAgent agent;
    private HashSet<Vector3> visitedLocations = new HashSet<Vector3>();
    private Stack<Vector3> rememberedLocations = new Stack<Vector3>();

    private Vector3 CurrentDestonation;
    private MoveToTarget toTarget;
    private ExploreMove exploreMove;
    private bool isAcktive;
    private bool isIdle;
    public bool hasAtrifact;

    public Transform leaveTile;

    private float elapsedTime = 0;

    public AudioSource audioSource;
    public AudioClip click;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        toTarget = new(agent);
        exploreMove = new(transform, visitedLocations, rememberedLocations, explorationRadius, avoidanceRadius);
        CurrentDestonation = exploreMove.GetDestination();
        isAcktive = true;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < handDistance)
        {
            if (isAcktive)
            {
                CameToPosition();
            }
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updateInterval)
        {
            elapsedTime = 0f;
            TimerUpdate();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
        }

    }

    private void CameToPosition()
    {
        if (!isIdle)
        {
            if (hasAtrifact)
            {
                toTarget.StartMove(leaveTile.position);
            }
            else
            {
                CurrentDestonation = exploreMove.GetDestination();
                toTarget.StartMove(CurrentDestonation);
            }
        }
        else
        {
            CurrentDestonation = exploreMove.GetRandomDestination();
            toTarget.StartMove(CurrentDestonation);
        }
    }

    public bool CheckPathToTarget(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if (NavMesh.CalculatePath(agent.transform.position, targetPosition, NavMesh.AllAreas, path))
        {
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                return true;
            }
        }
        return false;
    }


    private void TimerUpdate()
    {
        if (CurrentDestonation == Vector3.zero)
        {
            isAcktive = false;
        }
        VisiteLocation();
        RememberLocation();
        if (!CheckPathToTarget(CurrentDestonation))
        {
            IdleMove();
        }
    }

    private void VisiteLocation()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, visitedRadius);

        foreach (Collider col in colliders)
        {
            if (col.TryGetComponent(out FloorCell floorCell))
            {
                visitedLocations.Add(floorCell.transform.position);
            }
        }
    }

    private void RememberLocation()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rememberRadius);
        foreach (Collider col in colliders)
        {
            if (col.TryGetComponent(out FloorCell floorCell))
            {
                if (!visitedLocations.Contains(floorCell.transform.position))
                {
                    rememberedLocations.Push(floorCell.transform.position);
                }
            }
            if (col.TryGetComponent<Artefact>(out Artefact artefact))
            {
                // CurrentDestonation = artefact.transform.position;
                toTarget.StartMove(CurrentDestonation);
            }
        }
    }

    private void MoveToArtefact()
    {
        
    }

    private void IdleMove()
    {
        if (!isIdle)
        {
            StartCoroutine(WaitAndExplore());
        }
    }

    private IEnumerator WaitAndExplore()
    {
        if(!hasAtrifact)
        {
            Debug.Log("Wait...");
            isIdle = true;
            CameToPosition();
            yield return new WaitForSeconds(6);
            if (isAcktive)
            {
                isIdle = false;
                CameToPosition();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(leaveTile.position, Vector3.one *2);
    }
}
