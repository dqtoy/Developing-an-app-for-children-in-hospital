using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{

    public float Jump_Force = 10f;
    private float Destroy_Distance;
    private float Destroy_Distance2;

    private bool Create_NewPlatform = false;

    private GameObject Game_Controller;

    private float leftBorder;

    public Camera MainCamera;
    public Camera MainCamera2;
    // Use this for initialization
    void Start()
    {
        Game_Controller = GameObject.Find("Game_Controller");
        GameObject gameObject = GameObject.Find("Main Camera");
        MainCamera = gameObject.GetComponent<Camera>();
        GameObject gameObject2 = GameObject.Find("Main Camera2");
        MainCamera2 = gameObject2.GetComponent<Camera>();

        // Set distance to destroy the platforms out of screen
        Destroy_Distance = Game_Controller.GetComponent<Game_Controller>().Get_DestroyDistance();
        Destroy_Distance2 = Game_Controller.GetComponent<Game_Control2>().Get_DestroyDistance();


        leftBorder = MainCamera2.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        Debug.Log("1111111111111111111111111");
        Debug.Log(leftBorder);
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftBorder)
        {
            // Platform out of screen
            if (transform.position.y - MainCamera.transform.position.y < Destroy_Distance)
            {
                // Create new platform
                if (name != "Platform_Brown(Clone)" && name != "Spring(Clone)" && name != "Trampoline(Clone)" && !Create_NewPlatform)
                {
                    Game_Controller.GetComponent<Platform_Generator>().Generate_Platform(1);
                    Create_NewPlatform = true;
                }

                // Deactive Collider and effector
                GetComponent<EdgeCollider2D>().enabled = false;
                GetComponent<PlatformEffector2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                // Deactive collider and effector if gameobject has child
                if (transform.childCount > 0)
                {
                    if (transform.GetChild(0).GetComponent<Platform>()) // if child is platform
                    {
                        transform.GetChild(0).GetComponent<EdgeCollider2D>().enabled = false;
                        transform.GetChild(0).GetComponent<PlatformEffector2D>().enabled = false;
                        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }

                    // Destroy this platform if sound has finished
                    if (!GetComponent<AudioSource>().isPlaying && !transform.GetChild(0).GetComponent<AudioSource>().isPlaying)
                        Destroy(gameObject);
                }
                else
                {
                    // Destroy this platform if sound has finished
                    if (!GetComponent<AudioSource>().isPlaying)
                        Destroy(gameObject);
                }
            }
        }
        else
        {
            // Platform out of screen
            if (transform.position.y - MainCamera2.transform.position.y < Destroy_Distance2)
            {
                // Create new platform
                if (name != "Platform_Brown(Clone)" && name != "Spring(Clone)" && name != "Trampoline(Clone)" && !Create_NewPlatform)
                {
                    Game_Controller.GetComponent<Platform_Generator2>().Generate_Platform(1);
                    Create_NewPlatform = true;
                }

                // Deactive Collider and effector
                GetComponent<EdgeCollider2D>().enabled = false;
                GetComponent<PlatformEffector2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                // Deactive collider and effector if gameobject has child
                if (transform.childCount > 0)
                {
                    if (transform.GetChild(0).GetComponent<Platform>()) // if child is platform
                    {
                        transform.GetChild(0).GetComponent<EdgeCollider2D>().enabled = false;
                        transform.GetChild(0).GetComponent<PlatformEffector2D>().enabled = false;
                        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }

                    // Destroy this platform if sound has finished
                    if (!GetComponent<AudioSource>().isPlaying && !transform.GetChild(0).GetComponent<AudioSource>().isPlaying)
                        Destroy(gameObject);
                }
                else
                {
                    // Destroy this platform if sound has finished
                    if (!GetComponent<AudioSource>().isPlaying)
                        Destroy(gameObject);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {

        // Add force when player fall from top
        if (true)
        {
            Rigidbody2D Rigid = Other.collider.GetComponent<Rigidbody2D>();


            if (Rigid != null)
            {

                // if gameobject has animation; Like spring, trampoline and etc...
                if (GetComponent<Animator>())
                    GetComponent<Animator>().SetBool("Active", true);

                // Check platform type
                Platform_Type();

                Vector2 Force = Rigid.velocity;
                //Force.y = Jump_Force;
                //Rigid.velocity = Force;
                Rigid.velocity = Vector2.zero;
                Rigid.AddForce(new Vector2(0, Jump_Force), ForceMode2D.Impulse);

                // Play jump sound
                GetComponent<AudioSource>().Play();



            }

        }

    }

    void Platform_Type()
    {
        if (GetComponent<Platform_White>())
            GetComponent<Platform_White>().Deactive();
        else if (GetComponent<Platform_Brown>())
            GetComponent<Platform_Brown>().Deactive();
    }
}
