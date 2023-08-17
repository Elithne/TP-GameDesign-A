using UnityEngine;
using System.Collections;

public class MessageTrigger : MonoBehaviour
{
    public MessageSystem messageSystem;
    public GameObject messageInterface; // Referencia a la interfaz de mensaje
    public string triggerMessage = "¡Has llegado a la zona!";
    public float messageDuration = 5f; // Duración para mostrar el mensaje e interfaz
    public bool permanentActivation = false; // Agrega una opción para activación permanente
    public float interfaceDisplayDuration = 5f; // Duración para mostrar la interfaz

    private bool hasBeenActivated = false; // Controla si ya ha sido activado

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenActivated && other.CompareTag("Player")) // Asegúrate de configurar la etiqueta correcta para el jugador
        {
            messageSystem.AddMessage(triggerMessage, messageDuration);

            // Mostrar la interfaz cuando se activa el trigger
            messageInterface.SetActive(true);

            // Marcar como activado si no es permanente
            if (!permanentActivation)
            {
                hasBeenActivated = true;
                StartCoroutine(HideInterfaceAfterDuration());
            }
        }
    }

    private IEnumerator HideInterfaceAfterDuration()
    {
        yield return new WaitForSeconds(interfaceDisplayDuration);

        // Ocultar la interfaz después de la duración establecida
        messageInterface.SetActive(false);
    }
}
