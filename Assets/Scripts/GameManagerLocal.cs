using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerLocal : MonoBehaviour
{
    [Header("Active Game")]
    [SerializeField] private GameObject activePlayer;
    [SerializeField] private GameObject activeBoss;
    [SerializeField] private GameObject activeLuz;
    [SerializeField] private GameObject activeTraps;
    [SerializeField] private GameObject activeObjectPresent;
    [SerializeField] private GameObject activeControlersPanel;
    [SerializeField] private GameObject activePaticle;
    [SerializeField] private GameObject activeSpawner;
   
    [Header("Elements to handle the synchronization")]

    //TODO descomentar cuando este en linea
    // [SerializeField] private GameManager _globalGameManager;

    // Live table to view the all players scores
   // [SerializeField]
   // private GameObject rankingOnlineRowPrefab;

   // [SerializeField] private GameObject rankingOnlineContainer;

    // Chronometer
    [SerializeField] private ClockController clockController;

    // TODO Descomentar cuando se conecte en linea
    /*
    // End game panel and Prefab row to complete the ranking
    [SerializeField] private TextMeshProUGUI rankingTitleText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject rankingContainer;
    [SerializeField] private GameObject rankingMiniGameRowPrefab;
    */
    
    /*
    [Header("Optional Elements")]
    // [Optional] Titles to show in base demo
    [SerializeField]
    private int gameIndex;
    
    [SerializeField] private TextMeshProUGUI titleText;
    */
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Private variables
    private bool _isEndGame;
    private int _score;

    private readonly float _startTime = 5.0f; // [You can customize this value] Start time to start the live players points

    private readonly float _repeatRate = 1.0f; // [You can customize this value] The list is updating every one second


    public static GameManagerLocal Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Mmethod Start [Live cycle]
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // *** [Important] Get the global game manager instance and your prefab variant Chronometer
        //_globalGameManager = GameObject.FindGameObjectWithTag("GameManagerGlobal").GetComponent<GameManager>();
        clockController = FindObjectOfType<ClockController>();

       

        // *** [Optional] You can get the minigame index or not
        //  gameIndex = _globalGameManager.GetMiniGameIndex();
       // titleText.text = $"Minijuego {gameIndex.ToString()}";

        // *** [Important] This Invoke it is necessary to get the current ranking list of the global game manager.
      //  InvokeRepeating("UpdateOnliveRanking", _startTime, _repeatRate);
    }

    // TODO descomentar cuando se conecte a online.
    /*
    /// <summary>
    /// Method FixedUpdate
    /// </summary>
    void FixedUpdate()
    {
        // *** [Optional] This only handle the end time to call EndGame method.
        if ((clockController && clockController.IsEnd()) && !_isEndGame)
        {
            EndGame();
        }
    }
    */
    private void Update()
    {
        ActivarGame(clockController.GetElapsedTime()>10);
      
    }

    /// <summary>
    /// Handle UpdateScore. [** Not necessary **]
    /// This method only handle the canvas button to update score to the player
    /// </summary>
    public void UpdateScore()
    {
        scoreText.text = $"Score: {_score.ToString()}";
        // **** [Important]
        //_globalGameManager.CmdUpdatePlayerScore(score,GameType.Minigame); // This is very important, When your player get any points in the
        // game, you need call the command to synchronize with the Global
        // Game Manager
    }
  
    

    public void AddPoints(int points)
    {
        _score += points;
        _score =(_score >50) ?50:_score;
        UpdateScore();
    }


    public void RemovePoints(int points)
    {
        _score -= points;
        _score = (_score <= 0) ? 0 : _score;
        UpdateScore();
    }
    
    //TODO Descomentar cuando este en linea
    #region EnGame
    /*
    /// <summary>
    /// Method EndGame
    /// This method handles the end of the minigame. You can implement it in another way, but it is necessary to
    /// implement the actions of:
    ///     1º Deactivate the clockController or chronometer. [you can get the time first if you need it to perform calculations]
    ///     2º Send command to Global Game Manager to indicate that the game has ended [parameter --> player points]
    /// 
    /// </summary>
    public void EndGame()
    {
        // Set end game flag 
        _isEndGame = true;

        // *** Handle the chronometer and Deactivate
        // [Optional] var playerTime = clockController.GetElapsedTime();
        clockController.gameObject.SetActive(false);
        //scoreText.text = $"Minijuego resuelto en : {playerTime} segundos";
        //scoreText.gameObject.SetActive(true);

        // Hide the canvas elements that you consider
        GameObject.Find("Button End Game").gameObject.SetActive(false);
        //Debug.Log("[MiniJuego] Game Over");

        // [Important] Send command to Global Game Manager with the player score 
        _globalGameManager.CmdSetEndMiniGame(score);

        // [Optional] Set a custom title for your minigame ranking
        rankingTitleText.text = $"Ranking Minijuego {gameIndex.ToString()}";

        // [Maybe Important] Calling to get the final Ranking. If all players finish at the same time, it is not necessary
        // to make repeated invocations of the method and it will be enough to call it only once. 
        InvokeRepeating("GetScores", 0, _repeatRate); // You can customize this
    }
    */
    #endregion

    // TODO Descomentar cuando este en linea

    #region Get Scores
    /*
    /// <summary>
    /// Method GetScores [Important]
    /// This method clear the container and call to the Global Game Manager to get the updated ranking list to set into
    /// the ranking End game container
    /// </summary>
    private void GetScores()
    {
        // Clear container
        ClearRankingContainer(rankingContainer);
        // Call the method to set the new values into the  container
        UpdateContainer(rankingMiniGameRowPrefab, rankingContainer);
        // Active the gameObject
        if (!endGamePanel.gameObject.activeSelf) endGamePanel.gameObject.SetActive(true);
    }
    */
    #endregion
    //TODO Descomentar cuanto se conecte en online
    #region UpdateContainer OnLine

    /*
    /// <summary>
    /// Method UpdateContainer
    /// This method get the updated list fron the global game manager and set the each row prefab into the container to
    /// show the players ranking info.
    /// </summary>
    /// <param name="prefabRow">Prefab row to set into the container</param>
    /// <param name="container">GameObject parent</param>
    private void UpdateContainer(GameObject prefabRow, GameObject container)
    {
        // Get the latest results
        var results = _globalGameManager.MiniGameResults;

        // Read results and instatiate a prefab row for each new player score
        for (int i = 0; i < results.Count; i++)
        {
            // Instantiate a Ranking live row prefab into the container
            var scoreRow = Instantiate(prefabRow, container.transform);
            // Get all TextMeshProUGUI components of the prefab
            var prefabTexts = scoreRow.GetComponentsInChildren<TextMeshProUGUI>();

            // Set the current result into the TextMeshProUGUI elements
            prefabTexts[0].text = (i + 1).ToString(); // Player position
            prefabTexts[1].text = results[i].Playername; // Player name
            prefabTexts[2].text = $"{results[i].Points} ptos"; // Player total points

            // [Optional- To handle time] prefabTexts[2].text = results[i].elapsedTime.ToString("F3") + "s";
        }
    }
    */

    #endregion

    //TODO Descomentar cuando se conecte en linea
    #region UpdateOnlive Ranking

    /*
    /// <summary>
    /// Method UpdateOnliveRanking
    /// This method get the list of points of all the players and mapping it to the live ranking table
    /// </summary>
    private void UpdateOnliveRanking()
    {
        // Calling to clear method to destroy old gameObject in container
        ClearRankingContainer(rankingOnlineContainer);

        // Handle results
        UpdateContainer(rankingOnlineRowPrefab, rankingOnlineContainer);
    }
    */

    #endregion

    // TODO Descomentar cuando se conecte el linea
    #region Clear Ranking Container
    /*

    /// <summary>
    /// Method ClearRankingContainer [Important]
    /// This method clean the container to set the new information 
    /// </summary>
    /// <param name="container"></param>
    private void ClearRankingContainer(GameObject container)
    {
        foreach (Transform child in container.transform)
            Destroy(child.gameObject);
    }
    */

    #endregion


    private void ActivarGame(bool active)
    {
        activePlayer.SetActive(active);
        activeBoss.SetActive(active);
        activeLuz.SetActive(active);
        activeTraps.SetActive(active);
        activeObjectPresent.SetActive(active);
        activeControlersPanel.SetActive(!active);
        activePaticle.SetActive(active);
        activeSpawner.SetActive(active);
        
    }
}