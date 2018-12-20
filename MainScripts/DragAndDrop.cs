using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour {

    public Patient.Papers paper;
    InkManager inkManager;

    private bool selected;
    Vector2 unselectedSize;
    Vector2 superselectedSize;

    Vector3 selectedPos;
    Vector3 unselectedPos;
    float initZ;

    public GameObject space;

    private void Start()
    {
        superselectedSize = new Vector2(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f);
        unselectedSize = new Vector2(transform.localScale.x, transform.localScale.y);
        initZ = transform.localPosition.z;

        inkManager = GameObject.Find("OfficeManager").GetComponent<InkManager>();
    }

    public void Initiate()
    {
        GetComponent<SpriteRenderer>().sprite = paper.paper;
    }

    private void Update()
    {

        if(selected == true)
        {
            transform.localScale = superselectedSize;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initZ - 0.1f);
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((cursorPos.x > -7.2f && cursorPos.x < -3.2f) && (cursorPos.y > 0.2f && cursorPos.y < 4.6f))
            {
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                inkManager.SwitchKnots(paper.threadName);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = unselectedSize;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initZ);
            GetComponent<SpriteRenderer>().sprite = paper.paper;
            space.GetComponent<Image>().enabled = false;
            selected = false;
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = paper.paper2;
            space.GetComponent<Image>().enabled = true;
            selected = true;
        }
    }
}
