using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator2 : MonoBehaviour
{

    public GameObject Platform_Green;
    public GameObject Platform_Blue;
    public GameObject Platform_White;
    public GameObject Platform_Brown;

    public GameObject Spring;
    public GameObject Trampoline;
    public GameObject Propeller;

    private GameObject Platform;
    private GameObject Random_Object;

    public float Current_Y_2 = 0;
    float Offset;
    Vector3 Top_Left;

    private float leftBorder;       //游戏左边界x
    private float rightBorder;      //游戏右边界x

    public Camera MainCamera;
    public Camera MainCamera2;
    private GameObject Player;
    private int Score;

    // Use this for initialization
    void Start()
    {
        // Initialize boundary
   
        leftBorder = MainCamera2.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBorder = MainCamera2.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        Offset = 1.2f;

        Player = GameObject.Find("Doodler2");

        // Initialize platforms
        Generate_Platform(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
            Score = (int)(Player.transform.position.y * 30);
    }

    public void Generate_Platform(int Num)
    {
        for (int i = 0; i < Num; i++)
        {
            // Calculate platform x, y
            float Dist_X = Random.Range(leftBorder + Offset, rightBorder - Offset);
            float Dist_Y = Random.Range(2f, 5f);

            // Create brown platform random with 1/8 probability
            int Rand_BrownPlatform = Random.Range(1, 8);

            if (Score > 5000)
            {
                Dist_Y = Random.Range(3f, 6f);

            }
            if (Score > 10000)
            {
                Dist_Y = Random.Range(4f, 7f);
                Rand_BrownPlatform = Random.Range(1, 7);
            }
            if (Score > 20000)
            {
                Dist_Y = Random.Range(5f, 8f);

                Rand_BrownPlatform = Random.Range(1, 6);
            }

            if (Rand_BrownPlatform == 1)
            {
                float Brown_DistX = Random.Range(leftBorder + Offset, rightBorder - Offset);
                float Brown_DistY = Random.Range(Current_Y_2 + 1, Current_Y_2 + Dist_Y - 1);
                Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);

                Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
            }

            // Create other platform

            Current_Y_2 += Dist_Y;
            Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y_2, 0);
            int Rand_Platform = Random.Range(1, 10);

            if (Rand_Platform == 1) // Create blue platform
                Platform = Instantiate(Platform_Blue, Platform_Pos, Quaternion.identity);
            else if (Rand_Platform == 2) // Create white platform
                Platform = Instantiate(Platform_White, Platform_Pos, Quaternion.identity);
            else // Create green platform
                Platform = Instantiate(Platform_Green, Platform_Pos, Quaternion.identity);

            if (Rand_Platform != 2)
            {
                // Create random objects; like spring, trampoline and etc...
                int Rand_Object = Random.Range(1, 40);

                if (Rand_Object == 4) // Create spring
                {
                    Vector3 Spring_Pos = new Vector3(Platform_Pos.x + 0.5f, Platform_Pos.y + 0.27f, 0);
                    Random_Object = Instantiate(Spring, Spring_Pos, Quaternion.identity);

                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
                else if (Rand_Object == 7) // Create trampoline
                {
                    Vector3 Trampoline_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.25f, 0);
                    Random_Object = Instantiate(Trampoline, Trampoline_Pos, Quaternion.identity);

                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
                else if (Rand_Object == 15) // Create propeller
                {
                    Vector3 Propeller_Pos = new Vector3(Platform_Pos.x + 0.13f, Platform_Pos.y + 0.15f, 0);
                    Random_Object = Instantiate(Propeller, Propeller_Pos, Quaternion.identity);

                    // Set parent to object
                    Random_Object.transform.parent = Platform.transform;
                }
            }


        }
    }
}
