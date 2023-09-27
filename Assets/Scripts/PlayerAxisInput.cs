using System;
using UnityEngine;

public class PlayerAxisInput : PawnBase
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private PhysicsPawn physicsPawn;
    [SerializeField] private Bullet bulletPrefab;

    private Vector2 moveDirection;

    private void Awake()
    {
        PlayerManager.playerPawn = physicsPawn;
    }

    private void Update()
    {
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    public void FixedUpdate()
    {
        physicsPawn.MoveByForce(moveDirection * moveSpeed);
    }

    private void ShootBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab, physicsPawn.GetPosition(), Quaternion.identity);

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        newBullet.Launch(physicsPawn, targetPosition);
    }
}
