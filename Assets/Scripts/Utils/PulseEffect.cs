using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    [Header("Configurações de Brilho")]
    [SerializeField] private float velocidadePulso = 2f;
    [SerializeField] private float alphaMinimo = 0.3f; 
    [SerializeField] private float alphaMaximo = 1f;  

    private Material materialItem;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Tenta pegar o SpriteRenderer primeiro (comum em 2D)
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (spriteRenderer == null)
        {
            // Se não tiver SpriteRenderer, tenta pegar o Renderer genérico (MeshRenderer, etc)
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                materialItem = rend.material;
            }
        }
    }

    void Update()
    {
        float alpha = Mathf.Lerp(alphaMinimo, alphaMaximo, Mathf.PingPong(Time.time * velocidadePulso, 1));

        if (spriteRenderer != null)
        {
            Color corAtual = spriteRenderer.color;
            corAtual.a = alpha;
            spriteRenderer.color = corAtual;
        }
        else if (materialItem != null)
        {
            Color corAtual = materialItem.color;
            corAtual.a = alpha;
            materialItem.color = corAtual;
        }
    }
}
