using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueInstance : MonoBehaviour
{
    [SerializeField] private bool _overrideExistentInstance;
    void Start()
    {
        GameObject[] otherInstance = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var instance in otherInstance)
        {
            if (instance != this.gameObject)
            {
                if (_overrideExistentInstance)
                {
                    GameObject.Destroy(instance);
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                }
            }
        }
    }
}