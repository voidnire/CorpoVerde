using TMPro;
using UnityEngine;

public class VisualNovelController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text dialogueText;

    [Header("Dialogue")]
    [TextArea(3, 6)]
    [SerializeField] private string[] dialogueLines;

    private int currentLineIndex = 0;
    private bool canAdvance = true;

    private void Start()
    {
        if (dialogueLines.Length > 0)
            dialogueText.text = dialogueLines[0];
    }

    private void Update()
    {
        if (!canAdvance) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }

    private void AdvanceDialogue()
    {
        currentLineIndex++;

        if (currentLineIndex >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = dialogueLines[currentLineIndex];
    }

    private void EndDialogue()
    {
        canAdvance = false;
        // Aqui você pode:
        // - trocar de cena
        // - liberar controle do player
        // - abrir escolhas
        // - fechar a caixa de texto
    }
}
