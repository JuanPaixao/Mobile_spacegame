using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    private Vector3 _initialPos;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _speed;
    private float _angle;
    private void Awake()
    {
        this._initialPos = this.transform.position;
    }
    private void Update()
    {
        this._angle += this._speed * Time.deltaTime; //increasing angle by one and using sine on it, so it will go on (this case) 0.5 +0.5 and making the sine between -1 and 1
        float variation = Mathf.Sin(_angle); //period
        this.transform.position = this._initialPos + (this._amplitude * variation * Vector3.up);
        Debug.Log(_angle +"   " +variation);
    }
}
