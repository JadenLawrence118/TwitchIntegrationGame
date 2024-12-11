using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;
using System.Globalization;

public class TwitchConnect : MonoBehaviour
{
    private PlatformMovement platMove;
    private ChatManager chatManager;

    TcpClient Twitch;
    StreamReader Reader;
    StreamWriter Writer;

    const string URL = "irc.chat.twitch.tv";
    const int PORT = 6667;

    string User = "Anyone";

    private Globals global;

    void Awake()
    {
        platMove = GameObject.Find("Platform").GetComponent<PlatformMovement>();
        chatManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChatManager>();
        global = GameObject.Find("Globals").GetComponent<Globals>();
        ConnectToTwitch();
    }

    private void ConnectToTwitch()
    {
        Twitch = new TcpClient(URL, PORT);
        Reader = new StreamReader(Twitch.GetStream());
        Writer = new StreamWriter(Twitch.GetStream());

        Writer.WriteLine("PASS " + global.OAuth);
        Writer.WriteLine("NICK " + User);
        Writer.WriteLine("JOIN #" + global.Channel.ToLower());
        Writer.Flush();
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
                int splitPoint = message.IndexOf("!");
                string chatter = message.Substring(1, splitPoint - 1);

                splitPoint = message.IndexOf(":", 1);
                string msg = message.Substring(splitPoint + 1);
                platMove.OnChatMessage(msg);
                chatManager.AddMessage(chatter, msg);
            }
        }
    }
}
