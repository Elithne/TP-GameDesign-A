using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlataform : MonoBehaviour
{
    PlataformMoving plataform;
    public AudioSource elevatorMusic;

    private void Start()
    {
        plataform = GetComponent<PlataformMoving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("jugador entró al ascensor");
        
        // Invoca la función para ejecutarla después de 1 segundo
        Invoke("ActivatePlataformWithDelay", 1f);
    }

    // Función para activar la plataforma después del retraso
    private void ActivatePlataformWithDelay()
    {
        plataform.canMove = true;
        elevatorMusic.Play();
    }
}
