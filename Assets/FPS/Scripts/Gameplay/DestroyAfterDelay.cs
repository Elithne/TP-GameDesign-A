using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay = 5f; // Tiempo en segundos antes de destruir el objeto

    void Start()
    {
        // Inicia una corutina para destruir el objeto después del tiempo especificado
        StartCoroutine(DestroyObjectDelayed());
    }

    IEnumerator DestroyObjectDelayed()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Destruye el objeto que contiene este script
        Destroy(gameObject);
    }
}

