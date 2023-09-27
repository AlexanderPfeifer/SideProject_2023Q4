using UnityEngine;

public class PlayerAxisInput : PawnBase
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private PhysicsPawn physicsPawn;

    private Vector2 moveDirection;

    private void Update()
    {
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.Normalize();
    }

    public void FixedUpdate()
    {
        physicsPawn.MoveByForce(moveDirection * moveSpeed);
    }
}
