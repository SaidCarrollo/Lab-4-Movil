using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int scoreValue = 10;
    [SerializeField] private Score_LifeDataSO scoreRef;
    public float moveSpeed = 3f;

    private void OnEnable()
    {
        // Configurar movimiento al activarse
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            scoreRef.AddPoints(scoreValue);
            StaticObjectPool.Return(gameObject);

            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet != null) bullet.ReturnToPool();
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(1);
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