using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using TMPro;

public class PlayerInfo : NetworkBehaviour
{

    [SyncVar(hook = nameof(OnPlayerScoreChanged))]
    public int Score;

    public GameObject scoreTablePanelPrefab;
    public GameObject scoreTablePanelInstance;

    private Score scoreScript;

    [SyncVar]
    public GameObject relatedPanel;

    private void Start()
    {
        scoreScript = GameObject.Find("Contador").GetComponent<Score>();
        if (!isLocalPlayer) return;
        CmdGeneratePanel();
    }


    [Command]
    private void CmdGeneratePanel(NetworkConnectionToClient sender = null)
    {
        scoreTablePanelInstance = Instantiate(scoreTablePanelPrefab);

        NetworkServer.Spawn(scoreTablePanelInstance);

        sender.identity.GetComponent<PlayerInfo>().relatedPanel = scoreTablePanelInstance;
    }

    private void OnPlayerScoreChanged(int oldScore, int newScore)
    {

        relatedPanel.GetComponent<ScoreTablePlayer>().playerScore = newScore;

    }
}
