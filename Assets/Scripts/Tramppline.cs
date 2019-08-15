using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramppline : MonoBehaviour {


    private bool Rotate = false;
    float angel = 20f;
    public float angel_all = 0;

    // Use this for initialization
    void Start () {
        Rotate = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Rotate)
        {
            if (angel_all + angel > 360f)
            {
                angel = 360f - angel_all;
                Rotate = false;
            }
            Player.transform.Rotate(new Vector3(0, 0, angel));
            angel_all += angel;
        }
	}

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Player")
            Rotate = true;
    }

}
