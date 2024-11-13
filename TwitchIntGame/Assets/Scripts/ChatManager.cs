using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ChatManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatMessagePrefab;
    [SerializeField] CanvasGroup chatContent;
    [SerializeField] Scroller scroller;

    public void AddMessage(string chatter, string msg)
    {
        TextMeshProUGUI message = Instantiate(chatMessagePrefab, chatContent.transform);
        message.SetText(chatter + ": " + msg);
        print(chatter + ": " + msg);
    }
}
