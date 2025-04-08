using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;
    private DynamicObjectPool pool;
    private float spawnTime;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(DynamicObjectPool bulletPool, float bulletSpeed)
    {
        this.pool = bulletPool;
        this.speed = bulletSpeed;
        spawnTime = Time.time;

        // Configurar velocidad al iniciar
        if (rb != null)
        {
            rb.linearVelocity = transform.right * speed;
        }
    }

    private void Update()
    {
        if (Time.time - spawnTime > lifeTime)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Bullet"))
        {
            ReturnToPool();
        }
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        if (pool != null)
        {
            // Resetear velocidad al devolver al pool
            if (rb != null) rb.linearVelocity = Vector2.zero;
            pool.Return(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
