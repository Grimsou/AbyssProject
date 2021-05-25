using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    #region Awake
    private void Awake()
    {
    }
    #endregion

    public Text _txtScoreUI;
    #region Public Properties
    public int _highScore {

        get { return _scr; }

        set { _scr = value;
            _txtScoreUI.text = _highScore.ToString();
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }
    #endregion

    #region Init
    private void Start()
    {
        _scr = 0;
    }
    #endregion

    private int _scr;
}