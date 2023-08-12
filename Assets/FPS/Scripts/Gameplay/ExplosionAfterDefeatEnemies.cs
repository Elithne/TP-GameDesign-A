using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAfterDefeatEnemies : MonoBehaviour
{
    public GameObject objectToActivate; // Referencia al primer objeto que deseas activar
    public GameObject objectToActivate2; // Referencia al segundo objeto que deseas activar
    public float delay = 1.5f; // Retraso en segundos después de que se detecte la condición

    private bool conditionMet = false; // Variable para rastrear si la condición se ha cumplido

    void Update()
    {
        // Verifica si la condición aún no se ha cumplido
        if (!conditionMet && GameObject.FindGameObjectWithTag("Villagers") == null) {
            StartCoroutine(ActivateObjectsWithDelay());
            conditionMet = true; // Marca la condición como cumplida
        }
    }

    IEnumerator ActivateObjectsWithDelay()
    {
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado en "delay"

        Debug.Log("Bomba activada");
        objectToActivate.SetActive(true); // Activa el primer objeto objetivo
        objectToActivate2.SetActive(true); // Activa el segundo objeto objetivo
    }
}
