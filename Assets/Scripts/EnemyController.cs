using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    [SerializeField] private Pawn playerPawn;
    [SerializeField] private float distanceUntilStop = 3;

    private void Update()
    {
        if (Vector2.Distance(pawn.GetPosition(), playerPawn.GetPosition()) > distanceUntilStop)
        {
            pawn.MoveToPosition(playerPawn.GetPosition());
        }
        else
        {
            pawn.CancelMovement();
        }
    }
}
