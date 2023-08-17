using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private bool isDisplayingSentence = false; // Controla si se está mostrando una oración

    public float typingSpeed = 0.05f; // Velocidad de tipeo
    public float delayBetweenSentences = 1.5f; // Retraso entre oraciones

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isDisplayingSentence)
        {
            // Si ya se está mostrando una oración, no hagas nada
            return;
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isDisplayingSentence = true;

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isDisplayingSentence = false;

        yield return new WaitForSeconds(delayBetweenSentences);

        // Llama automáticamente a DisplayNextSentence() cuando termine de escribir la oración
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
