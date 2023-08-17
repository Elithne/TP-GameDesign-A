using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public float delayBetweenSentences = 1.5f;

	// public void TriggerDialogue ()
	// {
	// 	FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	// }

	private void OnTriggerEnter(Collider other)
    {
		if(other.CompareTag("Player")) {
			{
				Debug.Log("Mensaje triggeriado");
				FindObjectOfType<DialogueManager>().delayBetweenSentences = delayBetweenSentences;
				FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
				Destroy(gameObject);
	}
		}
	}
}