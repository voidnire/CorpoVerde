using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    [Header("Configurações de Brilho")]
    [SerializeField] private float velocidadePulso = 2f;
    [SerializeField] private float alphaMinimo = 0.3f;
    [SerializeField] private float alphaMaximo = 1f;
    [SerializeField] private float intensidadeGlow = 2.5f; // O "pulo do gato" para o brilho

    private Material materialItem;
    private SpriteRenderer spriteRenderer;
    private Color corOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                materialItem = rend.material;
                corOriginal = materialItem.color;
            }
        }
    }

    void Update()
    {
        // Cálculo da oscilação: vai de 0 a 1
        float t = Mathf.PingPong(Time.time * velocidadePulso, 1);
        float alpha = Mathf.Lerp(alphaMinimo, alphaMaximo, t);

        if (spriteRenderer != null)
        {
            // Multiplicamos a cor pela intensidade para o Bloom "enxergar" o brilho
            Color corComBrilho = corOriginal * (alpha * intensidadeGlow);
            corComBrilho.a = alpha; // Mantém a transparência que você queria
            spriteRenderer.color = corComBrilho;
        }
        else if (materialItem != null)
        {
            Color corComBrilho = corOriginal * (alpha * intensidadeGlow);
            corComBrilho.a = alpha;
            materialItem.color = corComBrilho;
        }
    }
}