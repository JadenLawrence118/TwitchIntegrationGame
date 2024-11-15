using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatMessagePrefab;
    [SerializeField] CanvasGroup chatContent;
    [SerializeField] ScrollRect scroller;

    private void Awake()
    {
        scroller = GameObject.Find("Chat").GetComponent<ScrollRect>();
    }

    public void AddMessage(string chatter, string msg)
    {
        TextMeshProUGUI message = Instantiate(chatMessagePrefab, chatContent.transform);
        message.SetText(chatter + ": " + msg);
        print(chatter + ": " + msg);
        StartCoroutine(UpdateChat());
    }

    IEnumerator UpdateChat()
    {
        yield return new WaitForEndOfFrame();
        scroller.verticalNormalizedPosition = 0;
    }
}
