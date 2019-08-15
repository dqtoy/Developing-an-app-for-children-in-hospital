﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform_Generator : MonoBehaviour {

    public GameObject Platform_Green;
    public GameObject Platform_Blue;
    public GameObject Platform_White;
    public GameObject Platform_Brown;

    public int num_step;

    public GameObject Spring;
    public GameObject Trampoline;
    public GameObject Propeller;

    private GameObject Platform;
    private GameObject Random_Object;

    private GameObject Player;
    private int Score;

    public float Current_Y = 0;
    float Offset;
    Vector3 Top_Left;

	// Use this for initialization
	void Start () 
    {
        // Initialize boundary
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Offset = 1.2f;

        Player = GameObject.Find("Doodler");

        // Initialize platforms
        Generate_Platform(num_step);
	}
	
	// Update is called once per frame
	void Update () {
        if (Player)
            Score = (int)(Player.transform.position.y * 30);

    }

    public void Generate_Platform(int Num)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "doodle_new2"|| scene.name == "doodle_new3" || scene.name == "doodle_new4" || scene.name == "doodle_new5" || scene.name == "doodle_new6" || scene.name == "doodle_new7")
        {
            for (int i = 0; i < Num; i++)
            {
                // Calculate platform x, y
                float Dist_X = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                float Dist_Y = 2.0f;

                // Create brown platform random with 1/8 probability
                int Rand_BrownPlatform = Random.Range(1, 8);


                if (Score > 5000)
                {
                    Dist_Y = Random.Range(2.0f, 3.5f);

                }
                if (Score > 10000)
                {
                    Dist_Y = Random.Range(2.5f, 4.0f);
                    Rand_BrownPlatform = Random.Range(1, 7);
                }
                if (Score > 20000)
                {
                    Dist_Y = Random.Range(3.0f, 5.0f);

                    Rand_BrownPlatform = Random.Range(1, 6);
                }
                if (Score > 30000)
                {
                    Dist_Y = Random.Range(4.0f, 6.0f);
                    Rand_BrownPlatform = Random.Range(1, 5);
                }
                if (Score > 50000)
                {
                    Dist_Y = Random.Range(5.0f, 8.0f);
                    Rand_BrownPlatform = Random.Range(1, 4);
                }
                //if (scene.name == "competition")
                //{
                //    Dist_Y = Random.Range(1f, 5f);
                //}
                //if (scene.name == "doodle_cooperation")
                //{
                //    Dist_Y = Random.Range(1f, 3f);
                //}



                if (Rand_BrownPlatform == 1)
                {
                    float Brown_DistX = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                    float Brown_DistY = Random.Range(Current_Y + 1, Current_Y + Dist_Y - 1);
                    Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);

                    Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
                }

                // Create other platform
                Current_Y += Dist_Y;
                Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y, 0);
                int Rand_Platform = Random.Range(1, 10);

                if (Rand_Platform == 1) // Create blue platform
                {
                    Platform = Instantiate(Platform_Blue, Platform_Pos, Quaternion.identity);
                }
                else if (Rand_Platform == 2) // Create white platform
                    Platform = Instantiate(Platform_White, Platform_Pos, Quaternion.identity);
                else
                {
                    if (Score > 10000 && Rand_Platform == 3)
                    {
                        Platform = Instantiate(Platform_White, Platform_Pos, Quaternion.identity);
                    }
                    else if (Score > 30000 && Rand_Platform == 4)
                    {

                        Platform = Instantiate(Platform_Blue, Platform_Pos, Quaternion.identity);
                    }
                    else
                    {
                        // Create green platform
                        Platform = Instantiate(Platform_Green, Platform_Pos, Quaternion.identity);
                    }
                }

                if (Rand_Platform != 2 && Rand_Platform != 3)
                {
                    // Create random objects; like spring, trampoline and etc...
                    int Rand_Object = Random.Range(1, 80);

                    if (Rand_Object == 4 || Rand_Object == 14 || Rand_Object == 24 || Rand_Object == 34) // Create spring
                    {
                        Vector3 Spring_Pos = new Vector3(Platform_Pos.x + 0.5f, Platform_Pos.y + 0.27f, 0);
                        Random_Object = Instantiate(Spring, Spring_Pos, Quaternion.identity);

                        // Set parent to object
                        Random_Object.transform.parent = Platform.transform;
                    }
                    else if (Rand_Object == 7 || Rand_Object == 17) // Create trampoline
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
        else if (scene.name == "competition")
        {
            for (int i = 0; i < Num; i++)
            {
                // Calculate platform x, y
                float Dist_X = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                float Dist_Y = Random.Range(2f, 5f);
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

                // Create brown platform random with 1/8 probability
                

                if (Rand_BrownPlatform == 1)
                {
                    float Brown_DistX = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                    float Brown_DistY = Random.Range(Current_Y + 1, Current_Y + Dist_Y - 1);
                    Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);

                    Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
                }

                // Create other platform

                Current_Y += Dist_Y;
                Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y, 0);
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
        else if (scene.name == "doodle_cooperation")
        {
            for (int i = 0; i < Num; i++)
            {
                // Calculate platform x, y
                float Dist_X = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                float Dist_Y = Random.Range(1f, 3f);

                // Create brown platform random with 1/8 probability
                int Rand_BrownPlatform = Random.Range(1, 8);

                if (Rand_BrownPlatform == 1)
                {
                    float Brown_DistX = Random.Range(Top_Left.x + Offset, -Top_Left.x - Offset);
                    float Brown_DistY = Random.Range(Current_Y + 1, Current_Y + Dist_Y - 1);
                    Vector3 BrownPlatform_Pos = new Vector3(Brown_DistX, Brown_DistY, 0);

                    Instantiate(Platform_Brown, BrownPlatform_Pos, Quaternion.identity);
                }

                // Create other platform

                Current_Y += Dist_Y;
                Vector3 Platform_Pos = new Vector3(Dist_X, Current_Y, 0);
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
}
