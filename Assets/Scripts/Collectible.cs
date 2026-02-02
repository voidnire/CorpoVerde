using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ItemType itemType;

    [Header("Configurações de Brilho")]
    [SerializeField] private float velocidadePulso = 2f;
    [SerializeField] private float alphaMinimo = 0.3f; // 30% (diminui até aqui)
    [SerializeField] private float alphaMaximo = 1f;   // 100% (aumenta até aqui)

    private Material materialItem;
    private static readonly int PropriedadeAlpha = Shader.PropertyToID("_Alpha"); // Nome da variável no Shader

    void Start()
    {
        // Pega o material do objeto. 
        // Se o outline for o segundo material, use: GetComponent<Renderer>().materials[1];
        materialItem = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Cria um valor que vai e volta entre os limites
        float alpha = Mathf.Lerp(alphaMinimo, alphaMaximo, Mathf.PingPong(Time.time * velocidadePulso, 1));

        // Aplica ao material
        // Se for um Shader comum, usa "_Color". Se for o seu Shader Graph, use o nome da variável que você criou
        Color corAtual = materialItem.color;
        corAtual.a = alpha;
        materialItem.color = corAtual;

        // Se estiver usando Shader Graph com uma variável Float chamada "Alpha":
        // materialItem.SetFloat("_Alpha", alpha);
    }

    public void Collect(PlayerInventory inventory)
    {
        inventory.AddItem(itemType);

        if (itemType == ItemType.Fruta)
        {
            UIItensController.Instance.UpdateFrutasText(inventory.GetItemCount(ItemType.Fruta));
        }
        else if (itemType == ItemType.CuiaLatex)
        {
            UIItensController.Instance.UpdateLatexText(inventory.GetItemCount(ItemType.CuiaLatex));
        }

        Destroy(gameObject);
    }
}