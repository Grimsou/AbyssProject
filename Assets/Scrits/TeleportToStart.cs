using UnityEngine;

public class TeleportToStart : MonoBehaviour
{
    #region In Inspector
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _submarine;
    [SerializeField] private Transform _particleSave;
    #endregion

    #region Init
    private void Start()
    {
        _teleportVector = _endPos.position - _startPos.position;
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EndPoint"))
        {
            _submarine.transform.position = new Vector3(_submarine.transform.position.x - _teleportVector.x, _submarine.transform.position.y - _teleportVector.y, _submarine.transform.position.z);
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x - _teleportVector.x, _mainCamera.transform.position.y - _teleportVector.y, _mainCamera.transform.position.z);
            _particleSave.position = new Vector3(_particleSave.position.x - _teleportVector.x, _particleSave.position.y - _teleportVector.y, _particleSave.position.z);
            Debug.Log("Teleport to start");
        }
    }

    #region Private
    private Vector3 _teleportVector;
    #endregion
}
