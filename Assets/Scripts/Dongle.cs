using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public bool isDrag;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isDrag){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float rightBorder = -4.1f + transform.localScale.x / 2f;
            float leftBorder = 4.1f - transform.localScale.x / 2f;
            if (mousePos.x > leftBorder)
            {
                mousePos.x = leftBorder;
            }
            else if (mousePos.x < rightBorder)
            {
                mousePos.x = rightBorder;
            }
            mousePos.y = 7;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }
    }

    public void Drag()
    {
        isDrag = true;
    }

    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
}
