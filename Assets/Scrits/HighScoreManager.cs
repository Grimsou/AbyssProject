using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    #region Init
    private void Awake()
    {
        HighScore = GetComponentInChildren<HighScore>();
        _endScore = GameObject.Find("ScoreStop");
    }
    #endregion

    #region Start
    private void Start()
    {
        HighScore._highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    #endregion

    #region Update
    private void Update()
    {
        //_convert += Time.deltaTime;
        //HighScore._highScore = (int)_convert;
        //Debug.Log(HighScore._highScore);
        Debug.Log(HighScore._highScore);
        StopScore();
    }
    #endregion

    #region Methods
    private void StopScore()
    {
        if(_endScore == null)
        {
            _convert += Time.deltaTime;
            HighScore._highScore = (int)_convert;
        }
    }
    #endregion
    #region Private
    private HighScore HighScore;
    private float _convert;
    private GameObject _endScore;
    #endregion
}
