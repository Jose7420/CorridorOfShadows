using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerLocal : MonoBehaviour
{
    private int _Score;

    [SerializeField] private TextMeshProUGUI _TextMeshProUGUI;

    public static GameManagerLocal Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _TextMeshProUGUI = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }


    public void UpdateScore()
    {
        _TextMeshProUGUI.text = "Score: " + _Score.ToString();
    }

    /*
    public void Points()
    {
        _Score++;
        _TextMeshProUGUI.text = "Score: " + _Score.ToString();

     }
    */

    public void addPoints(int points)
    {
        _Score += points;
        UpdateScore();
      
    }

    
    public void removePoints(int points) { 
        _Score -= points;
        UpdateScore();
    }

    public int getScore()
    {
        return _Score;
    }
   

}
