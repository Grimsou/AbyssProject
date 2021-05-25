using UnityEngine;

public class CameraMove : MonoBehaviour
{
    #region In Inspector
    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    /*[SerializeField][Range(0,2)] private float _cameraSpeed;



    [SerializeField] float _incrementalSpeedMultiplier;
    [SerializeField] float _maxCameraSpeed; 
    private float _endSpeed; */
    [SerializeField] private float _verticalMovement;
    [SerializeField] private float _horizontalMovement;
    public float _vitesseCameraBase;
    public float _vitesseCameraMax;
    private float _vitesseCameraActuelle;
    public float _combienDeVitesseTuPrendsParSeconde;
    private float _addedVitesseCamera;
    public float _endMultiplierVitesse;
    #endregion

    private void Start()
    {
        _combienDeVitesseTuPrendsParSeconde = _combienDeVitesseTuPrendsParSeconde / 50;
    }
    #region Update
    private void Update()
    {
        
    }
    #endregion
    private void FixedUpdate()
    {
        CameraMoving();
    }
    #region Methods
    private void CameraMoving()
    {
        _addedVitesseCamera += _combienDeVitesseTuPrendsParSeconde;
        _vitesseCameraActuelle = _vitesseCameraBase + _addedVitesseCamera;
        if (_vitesseCameraActuelle < _vitesseCameraMax)
        {
            _vitesseCameraActuelle = _vitesseCameraMax;
        }


        /*  _incrementalSpeed += _incrementalSpeedMultiplier * Time.deltaTime / 1000f;
          _endSpeed = (_cameraSpeed + _incrementalSpeed)/100f;

          //_exponentialSpeedMultiplier = _exponentialSpeedMultiplier + Time.time;
          //Mathf.Clamp(_exponentialSpeedMultiplier, _minCameraSpeed, _maxCameraSpeed);
          if (_endSpeed >= _maxCameraSpeed/100)
          {
              _endSpeed = _maxCameraSpeed/100;
          }
          Debug.Log(_endSpeed * 100);
        */
        _constantVelocity = new Vector3(_horizontalMovement, _verticalMovement, 0) * _vitesseCameraActuelle*_endMultiplierVitesse;
          _mainCameraTransform.transform.position += _constantVelocity; 




    }
    #endregion

    #region Private
    private Vector3 _constantVelocity;
    private float _incrementalSpeed;
    #endregion
}