using UnityEngine;

public class SonarPulse : MonoBehaviour
{
    #region In Inspector
    [Header("Particle manage")]
    [Tooltip("Needs the particles prefab")]
    [SerializeField] ParticleSystem _sonarPulse;
    //[SerializeField] LayerMask _obstacleLayer;
    [Tooltip("Gameobject where particle systems stacks")]
    [SerializeField] Transform _saveParticles;

    [Header("Sonar ping")]
    [Tooltip("Float value descreased by seconds until it reach 0")]
    [SerializeField] float _sonarPingInterval;
    [SerializeField] AudioSource _sonarPingSong;

    #endregion

    #region Start
    private void Start()
    {
        _lastPing = 1f;
    }
    #endregion

    #region Update
    private void Update()
    {
        _mousePos = Input.mousePosition;
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(_mousePos);
        _mouseWorldPos.z = 0f;
        
        RaycastHit2D mouseHit = Physics2D.Raycast(_mouseWorldPos, Vector3.zero);

        if(_lastPing > 0)
        {
            _lastPing -= Time.deltaTime;
        }

        //if(mouseHit == true && mouseHit.collider.gameObject.layer == 6 && Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("I clicked an obstacle, it'll change material");
        //}

        else if (_lastPing <= 0f && mouseHit == true && mouseHit.collider.gameObject.layer == 7)
        {
            UseSonar(_sonarPulse);
            _lastPing = _sonarPingInterval;
        }

        Debug.Log($"Interval entre les ping {_lastPing}");

        //SonarPingStock();
    }
    #endregion

    #region Methods
    private void UseSonar(ParticleSystem sonarParticle)
    {
        Instantiate(sonarParticle, new Vector3(_mouseWorldPos.x, _mouseWorldPos.y, Camera.main.transform.position.z + 7f), Quaternion.identity, parent: _saveParticles);
        _sonarPingSong.Play();
    }

    //private int SonarPingStock()
    //{
    //    int currentPingStock = 0;
    //    int i = 0 * (int)Time.deltaTime;

    //    for(i = 0; i >= _minSonarPing && i <= _maxSonarPing; i++)
    //    {
    //        currentPingStock += (int)Time.time;
    //    }
    //    return currentPingStock;

    //}
    #endregion

    #region Private
    private Vector3 _mousePos;
    private Vector3 _mouseWorldPos;
    private float _lastPing;
    #endregion
}