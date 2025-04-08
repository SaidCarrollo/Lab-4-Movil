using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 10;
    public float moveSpeed = 5f;

    private void OnEnable()
    {
        // Configurar movimiento al activarse
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(damageAmount);
            StaticObjectPool.Return(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            StaticObjectPool.Return(gameObject);
        }
    }
}