using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    #region In Inspector
    [SerializeField] private Collider2D _rightCollider;
    [SerializeField] private Collider2D _leftCollider;
    [SerializeField] private Collider2D _upperCollider;
    [SerializeField] private Collider2D _downCollider;
    #endregion
}
