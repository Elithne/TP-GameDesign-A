using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public AudioSource openSound;
    public AudioSource closeSound;

    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoors();
            isOpen = true;

            // Reproduce el sonido de apertura.
            if (openSound != null)
            {
                openSound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoors();
            isOpen = false;

            // Reproduce el sonido de cierre.
            if (closeSound != null)
            {
                closeSound.Play();
            }
        }
    }

    private void OpenDoors()
    {
        // Mueve las puertas hacia los lados para abrir.
        leftDoor.Translate(Vector3.left * leftDoor.localScale.x, Space.Self);
        rightDoor.Translate(Vector3.right * rightDoor.localScale.x, Space.Self);
    }

    private void CloseDoors()
    {
        // Mueve las puertas hacia su posición original para cerrar.
        leftDoor.Translate(Vector3.right * leftDoor.localScale.x, Space.Self);
        rightDoor.Translate(Vector3.left * rightDoor.localScale.x, Space.Self);
    }
}