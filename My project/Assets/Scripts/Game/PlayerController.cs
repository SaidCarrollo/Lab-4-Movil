using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;
    private bool isFiring = false;
    private float nextFireTime = 0f;
    public SelectedShipDataSO selectedShipData;
    [SerializeField] private Score_LifeDataSO currentHealth;
    [SerializeField] private PaletteSO paletteColor;
    private DynamicObjectPool bulletPool;
    void Start()
    {
        bulletPool = gameObject.AddComponent<DynamicObjectPool>();

        if (selectedShipData.selectedShip != null)
        {
            currentHealth.currentlife = selectedShipData.selectedShip.maxHealth;
            this.GetComponent<SpriteRenderer>().color = paletteColor.color;
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado una nave.");
            currentHealth.currentlife = 1;
        }
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isFiring = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isFiring = false;
            }

            if (isFiring && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / selectedShipData.selectedShip.fireRate;
            }
        }
        else
        {
            isFiring = false;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth.currentlife -= amount;

        if (currentHealth.currentlife <= 0)
        {
            currentHealth.currentlife = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Jugador destruido");
        SceneGlobalManager.OnShowResults?.Invoke();
        Time.timeScale = 0f;
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.Get(bulletPrefab);
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;
        bullet.SetActive(true);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.Init(bulletPool, bulletSpeed);
        }
        else
        {
            Debug.LogError("El prefab de bala no tiene componente Bullet");
        }
    }
}
