using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Blue2 : MonoBehaviour
{

    // For moving platforms
    private bool To_Right = true;
    private float Offset = 1.2f;
    public Camera MainCamera2;
    private float leftBorder;
    private float rightBorder;

    void Start()
    {
        GameObject gameObject2 = GameObject.Find("Main Camera2");
        MainCamera2 = gameObject2.GetComponent<Camera>();
        leftBorder = MainCamera2.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBorder = MainCamera2.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }
    

    void FixedUpdate()
    {
        // Move the platform
        //Vector3 Top_Left = MainCamera2.ScreenToWorldPoint(new Vector3(0, 0, 0));
        

        if (To_Right) // Move to right
        {
            if (transform.position.x < rightBorder - Offset)
                transform.position += new Vector3(0.1f, 0, 0);
            else
                To_Right = false;
        }
        else // Move to left
        {
            if (transform.position.x > leftBorder + Offset)
                transform.position -= new Vector3(0.1f, 0, 0);
            else
                To_Right = true;
        }
    }
}
