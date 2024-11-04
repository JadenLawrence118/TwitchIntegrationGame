using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private TwitchConnect twitch;
    void Awake()
    {
        twitch = GameObject.Find("TwitchConnect").GetComponent<TwitchConnect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChatMessage()
    {
        print(twitch.msg);
    }
}
