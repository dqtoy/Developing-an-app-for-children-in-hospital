using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Game_Control2 : MonoBehaviour
{

    private GameObject Player;
    private GameObject Player2;

    private float Max_Height = 0;
    private float Max_Height2 = 0;

    public Text Txt_Score;
    public Text Txt_Score2;

    private int Score;
    private int Score2;

    private Vector3 Top_Left;
    private Vector3 Camera_Pos;
    private Vector3 Top_Left2;
    private Vector3 Camera_Pos2;

    private bool Game_Over = false;
    private bool Game_Over2 = false;

    public Text Txt_GameOverScore;
    public Text Txt_GameOverHighsocre;
    public Text Txt_GameOverScore2;
    public Text Txt_GameOverHighsocre2;

    public Camera MainCamera;
    public Camera MainCamera2;

    private bool onedead = false;

    public GameObject Menu_Canvas;
    public Button PauseButton;
    public Button ContinueButton;
    public GameObject PausePanel;

    public GameObject Menu_Canvas2;
    public Button PauseButton2;
    public Button ContinueButton2;
    public GameObject PausePanel2;

    void Awake()
    {
        Player = GameObject.Find("Doodler");

        // Initialize boundary 
        Camera_Pos = MainCamera.transform.position;
        Top_Left = MainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

        Player2 = GameObject.Find("Doodler2");

        // Initialize boundary 
        Camera_Pos2 = MainCamera2.transform.position;
        Top_Left2 = MainCamera2.ScreenToWorldPoint(new Vector3(0, 0, 0));

        PauseButton.onClick.AddListener(PauseSingle);
        ContinueButton.onClick.AddListener(ContinueSingle);

        PauseButton2.onClick.AddListener(PauseSingle);
        ContinueButton2.onClick.AddListener(ContinueSingle);

    }

    void FixedUpdate()
    {
        if (!Game_Over)
        {
            // Calculate max height
            if (Player.transform.position.y > Max_Height)
            {
                Max_Height = Player.transform.position.y;
            }



            // Check player fall
            if (Player.transform.position.y - MainCamera.transform.position.y < Get_DestroyDistance())
            {
                // Play game over sound
                GetComponent<AudioSource>().Play();

                // Set game over
                Set_GameOver();
                Game_Over = true;
                

                onedead = true;
 

            }
        }

        if (!Game_Over2)
        {
            // Calculate max height
            if (Player2.transform.position.y > Max_Height2)
            {
                Max_Height2 = Player2.transform.position.y;
            }



            // Check player fall
            if (Player2.transform.position.y - MainCamera2.transform.position.y < Get_DestroyDistance())
            {
                // Play game over sound
                GetComponent<AudioSource>().Play();

                // Set game over
                Set_GameOver2();
                Game_Over2 = true;

                 onedead = true;
       
            }
        }

    }

    void PauseSingle()
    {
        Time.timeScale = 0.00001F;                                  //Freeze time;

        Menu_Canvas.SetActive(false);                                  //Disable hud panel;
        Menu_Canvas2.SetActive(false);

        PausePanel.SetActive(true);
        PausePanel2.SetActive(true);
    }

    void ContinueSingle()
    {
        PausePanel.SetActive(false);
        PausePanel2.SetActive(false);  //Disable pause panel;
        Time.timeScale = 1;                                         //Unfreeze time;

        Menu_Canvas.SetActive(true);
        Menu_Canvas2.SetActive(true);
    }

    void OnGUI()
    {
        // Set score
        Score = (int)(Max_Height * 30);
        Txt_Score.text = Score.ToString();

        Score2 = (int)(Max_Height2 * 30);
        Txt_Score2.text = Score2.ToString();
    }

    public bool Get_GameOver()
    {
        return Game_Over;
    }

    public bool Get_GameOver2()
    {
        return Game_Over2;
    }

    public float Get_DestroyDistance()
    {
        return Camera_Pos.y + Top_Left.y;
    }
    public float Get_DestroyDistance2()
    {
        return Camera_Pos2.y + Top_Left2.y;
    }

    void Set_GameOver()
    {


        Txt_GameOverScore.text = Score.ToString();
        GameObject Main_Canvas = GameObject.Find("Menu_Canvas");
        Main_Canvas.SetActive(false);

        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

        // Active game over menu
        Button_OnClick.Set_GameOverMenu1(true);

        // Enable animation
        Background_Canvas.GetComponent<Animator>().enabled = true;

        if (onedead == true)
        {

            Background_Canvas.transform.GetChild(3).gameObject.SetActive(true);
            Background_Canvas.transform.GetChild(4).gameObject.SetActive(true);
            GameObject Background_Canvas2 = GameObject.Find("Background_Canvas2");
            Background_Canvas2.transform.GetChild(3).gameObject.SetActive(true);
            Background_Canvas2.transform.GetChild(4).gameObject.SetActive(true);
            if (Score>Score2)
            {
                Background_Canvas.transform.GetChild(5).gameObject.SetActive(true);
                Background_Canvas2.transform.GetChild(6).gameObject.SetActive(true);
            }
            else
            {
                Background_Canvas.transform.GetChild(6).gameObject.SetActive(true);
                Background_Canvas2.transform.GetChild(5).gameObject.SetActive(true);
            }
        }

    }

    void Set_GameOver2()
    {

        Txt_GameOverScore2.text = Score2.ToString();

        GameObject Main_Canvas = GameObject.Find("Menu_Canvas2");
        Main_Canvas.SetActive(false);

        GameObject Background_Canvas = GameObject.Find("Background_Canvas2");

        // Active game over menu
        Button_OnClick.Set_GameOverMenu2(true);

        // Enable animation
        Background_Canvas.GetComponent<Animator>().enabled = true;

        if (onedead == true)
        {

            Background_Canvas.transform.GetChild(3).gameObject.SetActive(true);
            Background_Canvas.transform.GetChild(4).gameObject.SetActive(true);
            GameObject Background_Canvas2 = GameObject.Find("Background_Canvas");
            Background_Canvas2.transform.GetChild(3).gameObject.SetActive(true);
            Background_Canvas2.transform.GetChild(4).gameObject.SetActive(true);
            if (Score > Score2)
            {
                Background_Canvas.transform.GetChild(6).gameObject.SetActive(true);
                Background_Canvas2.transform.GetChild(5).gameObject.SetActive(true);
            }
            else
            {
                Background_Canvas.transform.GetChild(5).gameObject.SetActive(true);
                Background_Canvas2.transform.GetChild(6).gameObject.SetActive(true);
            }

        }


    }
}
