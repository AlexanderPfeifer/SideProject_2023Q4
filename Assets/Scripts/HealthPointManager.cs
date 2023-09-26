using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointManager : MonoBehaviour
{
    [SerializeField] private int maximumHitpoints = 5;
    [SerializeField] private int currentHitpoints;

    private void Start()
    {
        currentHitpoints = maximumHitpoints;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHitpoints -= damageAmount;
        
        if(currentHitpoints <= 0)
            Destroy(gameObject);
    }
}
