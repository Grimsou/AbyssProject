using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetection : MonoBehaviour
{

    #region Init
    private void Start()
    {
        _nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    #endregion

    #region OnCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("A collision happened");
            Destroy(this.gameObject);
            SceneManager.LoadScene(_nextSceneToLoad);
        }
    }
    #endregion

    #region OnTrigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("OutOfBoundColliders"))
        {
            Debug.Log("You are out of bounds");
            Destroy(this.gameObject);
            SceneManager.LoadScene(_nextSceneToLoad);
        }
    }
    #endregion

    #region Private
    private int _nextSceneToLoad;
	
    #endregion
}