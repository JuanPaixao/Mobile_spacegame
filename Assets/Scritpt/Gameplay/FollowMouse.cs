using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void Update()
    {
        Vector2 position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = position;
    }
}
