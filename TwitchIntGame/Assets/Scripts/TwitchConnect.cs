using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;

public class TwitchConnect : MonoBehaviour
{
    public UnityEvent OnChatMessage;
    TcpClient Twitch;
    StreamReader Reader;
    StreamWriter Writer;

    const string URL = "irc.chat.twitch.tv";
    const int PORT = 6667;

    string User = "programmerguy118";
    string OAuth = "oauth:oxwjvt53a75bg4cmjussdd58k5mwvm";
    string Channel = "TheLankyDude118";

    public string msg;

    private void ConnectToTwitch()
    {
        Twitch = new TcpClient(URL, PORT);
        Reader = new StreamReader(Twitch.GetStream());
        Writer = new StreamWriter(Twitch.GetStream());

        Writer.WriteLine("PASS " + OAuth);
        Writer.WriteLine("NICK " + User);
        Writer.WriteLine("JOIN #" + Channel.ToLower());
        Writer.Flush();
    }
    void Awake()
    {
        ConnectToTwitch();
    }

    void Update()
    {
        if (!Twitch.Connected)
        {
            ConnectToTwitch();
        }
        if (Twitch.Available > 0)
        {
            string message = Reader.ReadLine();

            if (message.Contains("PRIVMSG"))
            {
                int splitPoint = message.IndexOf(":", 1);
                msg = message.Substring(splitPoint + 1);
                OnChatMessage.Invoke();
            }
        }
    }
}
