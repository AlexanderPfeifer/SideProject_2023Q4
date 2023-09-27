using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
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
        if (Vector2.Distance(PlayerManager.playerPawn.GetPosition(), pawn.GetPosition()) < distanceUntilStop)
        {
            pawn.CancelMovement();
            TargetPlayer();
        }
        else
        {
            pawn.MoveToPosition(PlayerManager.playerPawn.GetPosition());
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

        Vector2 bulletSpawnPosition = pawn.GetPosition();
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        
        newBullet.Launch(pawn, PlayerManager.playerPawn.GetPosition());
        
        isTargetingPlayer = false;
    }
}
