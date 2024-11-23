using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCursor : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;

    }

    private void FixedUpdate()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

}
