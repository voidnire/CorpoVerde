using TMPro;
using UnityEngine;

public class UIItensController : MonoBehaviour
{
    public static UIItensController Instance;
    [SerializeField] private TMP_Text latexText;
    [SerializeField] private TMP_Text frutasText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateLatexText(int amount)
    {
        latexText.text = amount.ToString();
    }
    public void UpdateFrutasText(int amount)
    {
        frutasText.text = amount.ToString();
    }
}
