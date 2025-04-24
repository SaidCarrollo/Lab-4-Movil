using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] frames; // Lista de sprites para la animación
    public float frameRate = 0.1f; // Tiempo entre frames (en segundos)

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }
}
