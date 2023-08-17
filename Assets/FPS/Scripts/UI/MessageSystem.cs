using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageSystem : MonoBehaviour
{
    public TMP_Text messageText; // Cambio en el tipo de referencia
    private List<Message> messages = new List<Message>();

    public void AddMessage(string text, float duration)
    {
        Message message = new Message(text, duration);
        messages.Add(message);
    }

    private void Update()
    {
        for (int i = messages.Count - 1; i >= 0; i--)
        {
            messages[i].duration -= Time.deltaTime;

            if (messages[i].duration <= 0)
            {
                messages.RemoveAt(i);
            }
        }

        if (messages.Count > 0)
        {
            messageText.text = messages[messages.Count - 1].text;
        }
        else
        {
            messageText.text = "";
        }
    }
}
