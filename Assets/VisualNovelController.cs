using System.Collections;
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

    [Header("Typewriter")]
    [SerializeField] private float typingSpeed = 0.04f;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

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
            //AdvanceDialogue();
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (isTyping)
        {
            SkipTyping();
        }
        else
        {
            AdvanceDialogue();
        }
    }

    private void StartTyping(string line)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(line));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void SkipTyping()
    {
        if (!isTyping) return;

        StopCoroutine(typingCoroutine);
        dialogueText.text = dialogueLines[currentLineIndex];
        isTyping = false;
    }


    /*private void AdvanceDialogue()
    {
        currentLineIndex++;

        if (currentLineIndex >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = dialogueLines[currentLineIndex];
    }*/

    private void AdvanceDialogue()
    {
        currentLineIndex++;

        if (currentLineIndex >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        StartTyping(dialogueLines[currentLineIndex]);
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
