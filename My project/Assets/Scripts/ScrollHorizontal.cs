using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Velocidad de desplazamiento en unidades por segundo")]
    public float scrollSpeed = 0.5f;

    [Tooltip("Dirección del desplazamiento (normalizada)")]
    public Vector2 scrollDirection = new Vector2(-1, 0); // Se mueve hacia la izquierda

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Inicializa el offset
        offset = Vector2.zero;
    }

    void Update()
    {
        // Calcula el nuevo offset
        offset += scrollDirection.normalized * scrollSpeed * Time.deltaTime;

        // Aplica el offset a la textura
        rend.material.mainTextureOffset = offset;
    }
}