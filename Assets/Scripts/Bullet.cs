using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 14;
    [SerializeField] private float distanceUntilDespawn = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private float radius = .25f;
    [SerializeField] private Transform bulletVisuals;

    private Vector2 startPosition;
    
    private void OnValidate()
    {
        GetComponent<CircleCollider2D>().radius = radius;
        if (bulletVisuals != null)
            bulletVisuals.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }

    public void Launch(PawnBase shooter, Vector2 targetedPosition)
    {
        Vector2 direction = targetedPosition - shooter.GetPosition();
        direction.Normalize();
        
        startPosition = transform.position;
        
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shooter.GetComponent<Collider2D>());
        
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Destroy(gameObject);
        
        HealthPointManager healthPointManager = other.gameObject.GetComponent<HealthPointManager>();
        if (healthPointManager != null)
        {
            healthPointManager.TakeDamage(damage);
        }
    }
    

    private void FixedUpdate()
    {
        if (Vector2.Distance(startPosition, transform.position) >= distanceUntilDespawn)
        {
            Destroy(gameObject);
        }
    }
}
