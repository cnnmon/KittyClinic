using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DADPuzzle : MonoBehaviour {

    private bool selected;
    Vector2 unselectedSize;
    Vector2 superselectedSize;

    Vector3 selectedPos;
    Vector3 unselectedPos;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), -5);
    }

    private void Update()
    {
        if(selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((cursorPos.x > -3.2f && cursorPos.x < 3.2f) && (cursorPos.y > -3.2f && cursorPos.y < 3.4f))
            {
                transform.position = new Vector3(cursorPos.x, cursorPos.y, -5);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            selected = false;
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selected = true;
        }
    }
}
