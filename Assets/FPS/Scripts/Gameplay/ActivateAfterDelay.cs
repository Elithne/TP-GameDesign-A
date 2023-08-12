using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que se activará
    public float delay = 14f; // Tiempo en segundos antes de activar el objeto

    void Start()
    {
        // Inicia una corutina para activar el objeto después del tiempo especificado
        StartCoroutine(ActivateObjectDelayed());
    }

    IEnumerator ActivateObjectDelayed()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Activa el objeto especificado
        objectToActivate.SetActive(true);
    }
}
