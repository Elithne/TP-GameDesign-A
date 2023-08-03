using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{
    public Text messageText;
    private List<Message> messages = new List<Message>();

    public void AddMessage(string text, float duration)
    {
        Message message = new Message(text, duration);
        messages.Add(message);
    }

    // void Start()
    // {
    //     string mensaje1 = "¡Bienvenido al juego!";
    //     float duracionMensaje1 = 10f; // Duración de 5 segundos
    //     MessageSystem.AddMessage(mensaje1, duracionMensaje1);
    // }

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
