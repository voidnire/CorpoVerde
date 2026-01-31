using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TMP_Text healthText;


    public GameObject gameOverPanel;
    public GameObject pausePanel;



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

    public void UpdateHealthSlider()
    {
        playerHealthSlider.maxValue = PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value = PlayerController.Instance.playerCurrentHealth;
        healthText.text = $"{PlayerController.Instance.playerCurrentHealth} / {PlayerController.Instance.playerMaxHealth}";
    }

}
