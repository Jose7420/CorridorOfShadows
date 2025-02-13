using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Score : NetworkBehaviour
{

    [SerializeField] private TextMeshProUGUI _TextMeshProUGUI;
     
    private int _Score;

    public PlayerInfo _PlayerInfo;

    // Start is called before the first frame update
    void Start()
    {
        _TextMeshProUGUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    public void Points()
    {
        _Score++;
        _TextMeshProUGUI.text = "Score: " + _Score.ToString();
        CmdUpdatePlayerScore(_Score);
    }

    [Command(requiresAuthority = false)]
    private void CmdUpdatePlayerScore(int newScore, NetworkConnectionToClient sender = null)
    {
        sender.identity.GetComponent<PlayerInfo>().Score = newScore;
    }
}
