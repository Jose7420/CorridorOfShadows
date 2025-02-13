using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class GameManagerLocal : NetworkBehaviour
{
    public PlayerInfo _PlayerInfo;
    private int _Score;

    [SerializeField] private TextMeshProUGUI _TextMeshProUGUI;
    
    public static GameManagerLocal Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(Instance);
        }
    }
    

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
