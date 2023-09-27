using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AgentRotate2d))]
[RequireComponent(typeof(AgentOverride2d))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Pawn : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody2D rb;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveByDistance(Vector2 movement)
    {
        CancelMovement();
        rb.AddForce(movement, ForceMode2D.Force);
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
