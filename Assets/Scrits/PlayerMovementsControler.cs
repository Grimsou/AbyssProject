using UnityEngine;

public class PlayerMovementsControler : MonoBehaviour
{
    #region In Inspector
    [SerializeField][Range(0,10)] private float _subDefaultAcceleration;
    [SerializeField][Range(0,10)] private float _subDivingAcceleration;
    [SerializeField][Range(0,10)] private float _subSurfaceAcceleration;
    [SerializeField][Range(0,10)] private float _subBackWardAcceleration;

    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField][Range(0,10)] private float _transitionTimeToFullSpeed;
    [SerializeField][Range(0,10)] private float _maxMovementSpeed;

    #endregion

    #region Update
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        
    }
    #endregion

    #region Fixed Update
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            IsMoving(_subDefaultAcceleration);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            IsMoving(_subBackWardAcceleration);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            IsMoving(_subSurfaceAcceleration);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            IsMoving(_subDivingAcceleration);
        }
    }
    #endregion

    #region Methods
    private void IsMoving(float acceleration)
    {
        _force = new Vector2(_horizontal * acceleration * Time.deltaTime, _vertical * acceleration * Time.deltaTime);
        _force = Vector2.Lerp(_playerRigidbody.velocity,_force.normalized, _transitionTimeToFullSpeed);
        _playerRigidbody.velocity = Vector2.ClampMagnitude(_playerRigidbody.velocity, Mathf.Abs(_maxMovementSpeed));
        _playerRigidbody.AddForce(_force);
    }
    #endregion
    
    #region Private
    private float _horizontal, _vertical;
    
    private Vector2 _force;
    #endregion
}