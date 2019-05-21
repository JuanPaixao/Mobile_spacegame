using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
