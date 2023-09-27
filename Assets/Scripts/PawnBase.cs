using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBase : MonoBehaviour
{
    public Vector2 GetPosition()
    {
        return (Vector2)transform.position;
    }
}
