using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    [SerializeField] private Pawn playerPawn;
    [SerializeField] private float distanceUntilStop = 3;
    [SerializeField] private float targetingDuration = 1;
    [SerializeField] private EnemyAnimator enemyAnimator;
    [SerializeField] private Bullet bulletPrefab;

    private bool isTargetingPlayer = false;

    private void Update()
    {
        if(!isTargetingPlayer)
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        if (Vector2.Distance(pawn.GetPosition(), playerPawn.GetPosition()) < distanceUntilStop)
        {
            pawn.CancelMovement();
            TargetPlayer();
        }
        else
        {
            pawn.MoveToPosition(playerPawn.GetPosition());
        }
    }

    private void TargetPlayer()
    {
        isTargetingPlayer = true;
        StartCoroutine(TargetAndShootAtPlayerCoroutine());
    }

    private IEnumerator TargetAndShootAtPlayerCoroutine()
    {
        enemyAnimator.ShowTargetingAnimation(targetingDuration);
        yield return new WaitForSeconds(targetingDuration);

        Vector2 shootDirection = playerPawn.GetPosition() - pawn.GetPosition();
        shootDirection.Normalize();

        Vector2 bulletSpawnPosition = pawn.GetPosition();
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, quaternion.identity);
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), newBullet.GetComponent<CircleCollider2D>());
        newBullet.Launch(shootDirection);
        
        isTargetingPlayer = false;
    }
}
