using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game_Controller : MonoBehaviour {

    private GameObject Player;
    private GameObject Player2;

    private GameObject rope;

    private float Max_Height = 0;
    public Text Txt_Score;

    private int Score;

    private Vector3 Top_Left;
    private Vector3 Camera_Pos;

    private bool Game_Over = false;

    public Text Txt_GameOverScore;
    public Text Txt_GameOverHighsocre;

    public GameObject Menu_Canvas;
    public Button PauseButton;
    public Button ContinueButton;
    public GameObject PausePanel;
    //public GameObject GAMEOVER_Txt;
    //public GameObject GAMEOVER_Btn;
    //public GameObject GAMEOVER_Menu;

    void Awake () 
    {
        Player = GameObject.Find("Doodler");

        // Initialize boundary 
        Camera_Pos = Camera.main.transform.position;
        Top_Left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "doodle_cooperation")
        {
            Player2 = GameObject.Find("Doodler2");
           // rope= GameObject.Find("Obi Rope");
        }

        PauseButton.onClick.AddListener(PauseSingle);
        ContinueButton.onClick.AddListener(ContinueSingle);

    }
	
	void FixedUpdate () 
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!Game_Over)
        {

            //if (scene.name == "doodle_cooperation")
            //{
            //    if (rope.transform.position.y > Max_Height)
            //    {
            //        Max_Height = rope.transform.position.y;
            //    }
            //}
            //else
            //{
            //    // Calculate max height
            //    if (Player.transform.position.y > Max_Height)
            //    {
            //        Max_Height = Player.transform.position.y;
            //    }
            //}

            if (Player.transform.position.y > Max_Height)
            {
                Max_Height = Player.transform.position.y;
            }
            if (scene.name == "doodle_cooperation")
            {   // Check player fall
                if (Player.transform.position.y - Camera.main.transform.position.y < Get_DestroyDistance() && Player2.transform.position.y - Camera.main.transform.position.y < Get_DestroyDistance())
                {
                    // Play game over sound
                    GetComponent<AudioSource>().Play();

                    // Set game over
                    Set_GameOver();
                    Game_Over = true;
                }
            }
            else if(scene.name == "doodle_new3"|| scene.name == "doodle_new2" || scene.name == "doodle_new4" || scene.name == "doodle_new5" || scene.name == "doodle_new6" || scene.name == "doodle_new7")
            {   // Check player fall
                if (Player.transform.position.y - Camera.main.transform.position.y < Get_DestroyDistance())
                {
                    // Play game over sound
                    GetComponent<AudioSource>().Play();

                    // Set game over
                    Set_GameOver();
                    Game_Over = true;
                }

                if(Score>5000)
                {
                    GameObject Background_Canvas = GameObject.Find("Background_Canvas");

                    Background_Canvas.transform.GetChild(2).gameObject.SetActive(true);
                }
                if (Score > 10000)
                {
                    GameObject Background_Canvas = GameObject.Find("Background_Canvas");

                    Background_Canvas.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (Score > 20000)
                {
                    GameObject Background_Canvas = GameObject.Find("Background_Canvas");

                    Background_Canvas.transform.GetChild(4).gameObject.SetActive(true);
                }
                if (Score > 30000)
                {
                    GameObject Background_Canvas = GameObject.Find("Background_Canvas");

                    Background_Canvas.transform.GetChild(5).gameObject.SetActive(true);
                }
                if (Score > 50000)
                {
                    GameObject Background_Canvas = GameObject.Find("Background_Canvas");

                    Background_Canvas.transform.GetChild(6).gameObject.SetActive(true);
                }
            }
        }
	}

    void PauseSingle()
    {
        Time.timeScale = 0.00001F;                                  //Freeze time;
        
        Menu_Canvas.SetActive(false);                                  //Disable hud panel;

        PausePanel.SetActive(true);
    }

    void ContinueSingle()
    {
        PausePanel.SetActive(false);                                //Disable pause panel;
        Time.timeScale = 1;                                         //Unfreeze time;
       
        Menu_Canvas.SetActive(true);
    }

    void OnGUI()
    {
        // Set score
        Score = (int)(Max_Height * 30);
        Txt_Score.text = Score.ToString();
        Txt_GameOverScore.text = Score.ToString();

    }

    public bool Get_GameOver()
    {
        return Game_Over;
    }

    public float Get_DestroyDistance()
    {
        return Camera_Pos.y + Top_Left.y;
    }

    void Set_GameOver()
    {


       //Txt_GameOverScore.text = Score.ToString();
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

        // Active game over menu
        Button_OnClick.Set_GameOverMenu(true);

        GameObject Main_Canvas = GameObject.Find("Menu_Canvas");
        Main_Canvas.SetActive(false);
        //GameObject Menu_btn = GameObject.Find("Button_Menu");
        //Menu_btn.transform.localPosition = new Vector3(0, 0, 0);

        // Enable animation
        //Background_Canvas.GetComponent<Animator>().enabled = true;



    }
}
