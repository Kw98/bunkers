using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Photon.Chat;

public class GameHandler : MonoBehaviour, IChatClientListener {
    public string  playerName;
    public HScore  score;
    private string  path;
    private ChatClient  chatClient;

    private void Awake() {
        playerName = PlayerPrefs.GetString("PlayerName", "none") + "X" + PlayerPrefs.GetInt("Id", 1000).ToString();
        path = Application.persistentDataPath + "/scores.txt";
        print(path);
        OnLoadScore();
        chatClient = new ChatClient(this);
        chatClient.ChatRegion = "ASIA";
        chatClient.Connect("fafabff4-aac8-49b6-8f37-069175182f89", "0.1", new AuthenticationValues(playerName));
    }

    void Update()
    {
        if (chatClient != null)
            chatClient.Service();
    }

    public void OnSaveScore() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream  stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, score);
        stream.Close();
    }

    public void OnLoadScore() {
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream  stream = new FileStream(path, FileMode.Open);
            score = formatter.Deserialize(stream) as HScore;
            stream.Close();
        }
    }

    public void OnNewScore(int points, int days, float hours, float minutes) {
        Score sc = new Score(playerName, points, days, hours, minutes);
        List<Score> scList = new List<Score>(score.scoreList);
        scList.Add(sc);
        score.scoreList = scList.ToArray();
        chatClient.PublishMessage("UPDATE", JsonUtility.ToJson(score));
    }
    public void OnConnected() {
        chatClient.Subscribe( new string[] { "GET", "UPDATE" } );
        chatClient.PublishMessage("GET", "A");
    }

    public void OnDisconnected() { }

    public void OnGetMessages(string channelName, string[] senders, object[] messages) {
        if (channelName == "GET")
            sendScores();
        else
            updateScore(messages);
    }

    private void sendScores() {
        string json = JsonUtility.ToJson(score);
        chatClient.PublishMessage("UPDATE", json);
    }

    private void updateScore(object[] messages) {
        List<Score>    scList = new List<Score>();
        ScoreEQC qC = new ScoreEQC();
        scList.AddRange(score.scoreList);
        foreach (string mess in messages) {
            HScore hs = JsonUtility.FromJson<HScore>(mess);
            scList.AddRange(hs.scoreList);
        }
        score.scoreList = scList.Distinct(qC).ToArray();
        OnSaveScore();
    }


    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
	{
		if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
			Debug.LogError(message);
		else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
			Debug.LogWarning(message);
		else
			Debug.Log(message);
	}

    public void OnSubscribed(string[] channels, bool[] results) {}
    public void OnChatStateChange(ChatState state) { }
    public void OnUnsubscribed(string[] channels) { }
    public void OnUserSubscribed(string channel, string user) { Debug.LogFormat("OnUserSubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user); }
    public void OnUserUnsubscribed(string channel, string user) { Debug.LogFormat("OnUserUnsubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user); }
    public void OnPrivateMessage(string sender, object message, string channelName) { }
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message) { }

}
