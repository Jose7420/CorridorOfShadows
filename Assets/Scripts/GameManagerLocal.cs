using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerLocal : MonoBehaviour
{
    private int _Score;

    [SerializeField] private TextMeshProUGUI _scoreText;

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


    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }


    public void UpdateScore()
    {
        _scoreText.text = "Score: " + _Score.ToString();
    }

    /*
    public void Points()
    {
        _Score++;
        _TextMeshProUGUI.text = "Score: " + _Score.ToString();

     }
    */

    public void AddPoints(int points)
    {
        _Score += points;
        UpdateScore();
      
    }

    
    public void RemovePoints(int points) { 
        _Score -= points;
        _Score = _Score < 0 ? 0 : _Score;
        UpdateScore();
    }

    public int GetScore()
    {
        return _Score;
    }
   

}
