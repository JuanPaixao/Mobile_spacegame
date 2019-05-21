using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Rigidbody2D _rb;
    public float speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Follow();
    }
    private void Follow()
    {
        if (_target != null)
        {
            Vector3 movement = _target.transform.position - this.transform.position;
            movement = movement.normalized;
            movement *= this.speed;
            _rb.AddForce(movement, ForceMode2D.Force);
        }
    }
    public void SetTarget(Transform target)
    {
        this._target = target;
    }
}
