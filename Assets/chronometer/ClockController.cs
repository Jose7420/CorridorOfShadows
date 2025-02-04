using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    [Header("Canvas Clock text references")]
    [SerializeField] private TextMeshProUGUI timerText;
    
    [Header("Clock parameters")]
    [SerializeField] private float totalTimeInMinutes;
    [SerializeField] private Color clockIconColor;
    [SerializeField] private Color clockTextColor;
    [SerializeField] private Color panelClockColor;
    
    private readonly float _tenSeconds = 0.1f;
    private float _startTime;
    private float _maxTime;
    private float _elapsedTime;
    private float _remainingTime;
    
    private bool _isEnd;
    
    /// <summary>
    /// Method Start [Life cycle]
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _startTime = Time.time;
        _maxTime = GetMaxTime();
        UpdateColors();
    }

    /// <summary>
    /// Method Update [Life cycle]
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(_isEnd) return;
        
        _elapsedTime = Time.time - _startTime;
        _remainingTime = Mathf.Max(_maxTime - _elapsedTime, 0f);
        
        if (timerText)
            timerText.text = GetFormatTime();
        

        if (_elapsedTime >= _maxTime) _isEnd = true;
    }
        
    /*private string FormatTime(float time)
    {
            int seconds = Mathf.FloorToInt(time);
            int milliseconds = Mathf.FloorToInt((time - seconds) * 1000f);
            return $"{seconds}.{milliseconds}";
    }*/
    
    /// <summary>
    /// Method FormatTime
    /// This method apply format "min:sec" to the remaining time 
    /// </summary>
    /// <param name="time">Remaining time in seconds</param>
    /// <returns></returns>
    private string GetFormatTime()
    {
        int min = (int)_remainingTime / 60; 
        int sec = (int)_remainingTime % 60;
        
        return $"{min:00}:{sec:00}";
    }
    
    /// <summary>
    /// Method GetMaxTime
    /// This method convert the serializable value into total seconds value
    /// </summary>
    /// <returns></returns>
    private float GetMaxTime()
    {
        var intPart = (float)Math.Truncate(totalTimeInMinutes);
        var decimalPart = totalTimeInMinutes - intPart;
        return (decimalPart * 10.0f / _tenSeconds) + (intPart * 60.0f);
    }
    
    /// <summary>
    /// Method UpdateColors
    /// This method change the colors of the clock component
    /// </summary>
    private void UpdateColors()
    {
        transform.GetChild(0).GetComponent<Image>().color = clockIconColor;
        GetComponent<Image>().color = panelClockColor;
        timerText.color = clockTextColor;
    }
    
    /// <summary>
    /// Getter IsEnd
    /// </summary>
    /// <returns>Boolean</returns>
    public bool IsEnd()
    {
        return _isEnd;
    }
    
    /// <summary>
    /// Getter GetRemainingTime
    /// </summary>
    /// <returns>Float</returns>
    public float GetRemainingTime()
    {
        return _remainingTime;
    }
    
    /// <summary>
    /// Getter GetElapsedTime
    /// </summary>
    /// <returns></returns>
    public float GetElapsedTime()
    {
        return _elapsedTime;
    }
}
