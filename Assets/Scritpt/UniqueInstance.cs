using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] otherInstance = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var instance in otherInstance)
        {
            if (instance != this.gameObject)
            {
                Destroy(instance);
            }
        }
    }
}