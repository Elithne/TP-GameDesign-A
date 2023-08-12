using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsAfterDelay : MonoBehaviour
{
    public GameObject[] objectsToDestroy; // Array de objetos que se destruirán
    public float delay = 5f; // Tiempo en segundos antes de destruir los objetos

    void Start()
    {
        // Inicia una corutina para destruir los objetos después del tiempo especificado
        StartCoroutine(DestroyObjectsDelayed());
    }

    IEnumerator DestroyObjectsDelayed()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Destruye cada objeto en el array
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
}
