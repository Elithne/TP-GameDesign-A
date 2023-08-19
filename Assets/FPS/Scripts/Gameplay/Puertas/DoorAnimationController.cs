using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource doorSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Guard"))
        {
            // Cambia la condición a true para reproducir la animación de apertura.
            doorAnimator.SetBool("character_nearby", true);
            doorSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Guard"))
        {
            // Cambia la condición a false para reproducir la animación de cierre.
            doorAnimator.SetBool("character_nearby", false);
            doorSound.Play();
        }
    }
}
