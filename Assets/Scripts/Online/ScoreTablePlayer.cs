using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class ScoreTablePlayer : NetworkBehaviour
{
    GameObject tableScore;

    [SyncVar(hook = nameof(OnScoreChange))]
    public int playerScore;

    [SerializeField]
    private TextMeshProUGUI scorePanelText;

    // Start is called before the first frame update
    void Start()
    {
        tableScore = GameObject.Find("ScoreTable");
        scorePanelText = GetComponentInChildren<TextMeshProUGUI>();
        this.transform.SetParent(tableScore.transform);
    }

    [ClientRpc]
    private void OnScoreChange(int oldScore, int newScore)
    {
        scorePanelText.text = "Score: "+newScore.ToString();
    }

}
