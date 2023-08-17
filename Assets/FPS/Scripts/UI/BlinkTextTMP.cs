using UnityEngine;
using TMPro;

public class BlinkTextTMP : MonoBehaviour
{
    public float blinkInterval = 0.5f;        // Intervalo de parpadeo en segundos
    public bool startVisible = true;          // El texto comienza como visible o no
    private TextMeshProUGUI textComponent;
    private bool isTextVisible;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        isTextVisible = startVisible; // Establecer la visibilidad inicial
        textComponent.enabled = startVisible; // Establecer la visibilidad inicial del componente

        // Comienza el proceso de parpadeo
        InvokeRepeating("ToggleTextVisibility", 0f, blinkInterval);
    }

    private void ToggleTextVisibility()
    {
        isTextVisible = !isTextVisible;
        textComponent.enabled = isTextVisible;
    }
}
