using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScriptAfterDelay : MonoBehaviour
{
    public MonoBehaviour scriptToActivate; // Componente de script a activar
    public float delay = 14f; // Tiempo en segundos antes de activar el script

    void Start()
    {
        // Inicia una corutina para activar el script después del tiempo especificado
        StartCoroutine(ActivateScriptDelayed());
    }

    IEnumerator ActivateScriptDelayed()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Activa el componente de script especificado
        scriptToActivate.enabled = true;
    }
}
