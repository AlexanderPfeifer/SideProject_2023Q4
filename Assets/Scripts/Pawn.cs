using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AgentRotate2d))]
[RequireComponent(typeof(AgentOverride2d))]
public class Pawn : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPosition(Vector2 pos)
    {
        agent.isStopped = false;
        agent.SetDestination(pos);
    }
    
    public void CancelMovement()
    {
        agent.isStopped = true;
    }

    public Vector2 GetPosition()
    {
        return (Vector2)transform.position;
    }
}
