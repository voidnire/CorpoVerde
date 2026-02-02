using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ItemType itemType;

    [Header("Configurações de Brilho")]
    public float velocidade = 2f;
    public float alphaMinimo = 0.5f;
    public float intensidadeGlow = 2.0f; // Aumente para brilhar mais

    private SpriteRenderer spriteRenderer;
    private Color corOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        corOriginal = spriteRenderer.color;
    }

    void Update()
    {
        // Cria o efeito de vai e vem (0 a 1)
        float oscilacao = Mathf.PingPong(Time.time * velocidade, 1f);
        float novoAlpha = Mathf.Lerp(alphaMinimo, 1f, oscilacao);

        // Aplica a transparência e o brilho HDR
        // Multiplicamos a cor pela intensidade para "estourar" o Bloom
        spriteRenderer.color = corOriginal * (novoAlpha * intensidadeGlow);

        // Garante que o Alpha (transparência) seja aplicado corretamente
        Color finalColor = spriteRenderer.color;
        finalColor.a = novoAlpha;
        spriteRenderer.color = finalColor;
    }

    public void Collect(PlayerInventory inventory)
    {
        inventory.AddItem(itemType);
        SoundEffectManager.Instance.PlaySFX(SoundEffectManager.Instance.pop);

        if (UIItensController.Instance != null)
        {
            if (itemType == ItemType.Fruta)
                UIItensController.Instance.UpdateFrutasText(inventory.GetItemCount(itemType));
            else if (itemType == ItemType.CuiaLatex)
                UIItensController.Instance.UpdateLatexText(inventory.GetItemCount(itemType));
        }

        Destroy(gameObject);
    }
}