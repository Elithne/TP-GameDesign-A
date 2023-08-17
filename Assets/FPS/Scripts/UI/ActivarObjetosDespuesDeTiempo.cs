using System.Collections;
using UnityEngine;

public class ActivarObjetosDespuesDeTiempo : MonoBehaviour
{
    public GameObject[] objetosAActivar;  // Lista de objetos a activar
    public float tiempoDeEspera = 2.0f;   // Tiempo de espera en segundos

    private void Start()
    {
        StartCoroutine(ActivarObjetosDespuesDeTiempoCoroutine());
    }

    IEnumerator ActivarObjetosDespuesDeTiempoCoroutine()
    {
        yield return new WaitForSeconds(tiempoDeEspera);

        foreach (GameObject objeto in objetosAActivar)
        {
            objeto.SetActive(true);
        }
    }
}
