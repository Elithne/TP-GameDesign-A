using UnityEngine;

public class DoorActivationController : MonoBehaviour
{
    public GameObject upperDoor;
    public GameObject lowerDoor;
    public AudioSource doorSound;

    private bool isDoorsActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isDoorsActive)
        {
            DeactivateDoors();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorsActive)
        {
            ActivateDoors();
        }
    }

    private void DeactivateDoors()
    {
        doorSound.Play();
        upperDoor.SetActive(false);
        lowerDoor.SetActive(false);
        isDoorsActive = false;
    }

    private void ActivateDoors()
    {
        doorSound.Play();
        upperDoor.SetActive(true);
        lowerDoor.SetActive(true);
        isDoorsActive = true;
    }
}