using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_OnClick : MonoBehaviour {

    // Button onclick functions
	public void Play_OnClick()
    {
        SceneManager.LoadScene("doodle_new2");
    }
    public void Play3_OnClick()
    {
        SceneManager.LoadScene("doodle_new3");
    }
    public void Play4_OnClick()
    {
        SceneManager.LoadScene("doodle_new4");


    }

    public void Pla5_OnClick()
    {
        SceneManager.LoadScene("doodle_new5");
    }

    public void Pla6_OnClick()
    {
        SceneManager.LoadScene("doodle_new6");
    }

    public void Pla7_OnClick()
    {
        SceneManager.LoadScene("doodle_new7");
    }

    public void if_click()
    {
        Debug.Log("on_click!!!!!!!!!!!!!");
    }

    public void Scores_OnClick()
    {
        GameObject MainMenu_Canvas = GameObject.Find("Game_Controller");

        // Active highscore menu
        MainMenu_Canvas.GetComponent<Submit_Score>().HighScore_Canvas.SetActive(true);
        GameObject Main_Canvas = GameObject.Find("Main_Canvas");

        for (int i = 1; i < 14; i++)
            Main_Canvas.transform.GetChild(i).gameObject.SetActive(false);

            // Active loading
            MainMenu_Canvas.GetComponent<Submit_Score>().HighScore_Canvas.transform.GetChild(5).gameObject.SetActive(true);

        // Show scores
        MainMenu_Canvas.GetComponent<Submit_Score>().Show_TopTen();
    }

    public void Ehsan_OnClick()
    {
        Application.OpenURL("https://instagram.com/ehsanmhmdi/");
    }

    public void Menu_OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("cute");
    }
    public void Competition_OnClick()
    {
        SceneManager.LoadScene("competition");
    }

    public void Mode_OnClick()
    {
        SceneManager.LoadScene("Mode_Select");
    }
    public void Cooperation_OnClick()
    {
        SceneManager.LoadScene("doodle_cooperation");
    }

    public void TapToChange_OnClick()
    {
        // Deactive game over menu
        Set_GameOverMenu(false);
        
        // Active submit score menu
        Set_SubmitScoreMenu(true);
    }

    public void SubmitConfirm_OnClick()
    {
        // Deactive input field and buttons until server response
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");
        Set_InteractableSubmitScore(false);
        Set_Error(false);

       
    }

    public static void Set_GameOverMenu(bool State)
    {
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

         
        Background_Canvas.transform.GetChild(1).gameObject.SetActive(State);

        // Set player name (if exist)
        // Background_Canvas.transform.GetChild(5).GetComponent<InputField>().text = Data_Manager.Get_PlayerName();
    }



    public static void Set_GameOverMenu1(bool State)
    {
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

        for (int i = 1; i < 3; i++)
            Background_Canvas.transform.GetChild(i).gameObject.SetActive(State);

        // Set player name (if exist)
       // Background_Canvas.transform.GetChild(5).GetComponent<InputField>().text = Data_Manager.Get_PlayerName();
    }

    public static void Set_GameOverMenu2(bool State)
    {
        GameObject Background_Canvas2 = GameObject.Find("Background_Canvas2");

        for (int i = 1; i < 3; i++)
            Background_Canvas2.transform.GetChild(i).gameObject.SetActive(State);

        // Set player name (if exist)
        //Background_Canvas2.transform.GetChild(5).GetComponent<InputField>().text = Data_Manager.Get_PlayerName();
    }

    public static void Set_SubmitScoreMenu(bool State)
    {
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

        for (int i = 12; i < 17; i++)
            Background_Canvas.transform.GetChild(i).gameObject.SetActive(State);

        // Set player name (if exist) and Input field set focus
        Background_Canvas.transform.GetChild(14).GetComponent<InputField>().text = Data_Manager.Get_PlayerName();
        Background_Canvas.transform.GetChild(14).GetComponent<InputField>().Select();
    }

    public static void Set_InteractableSubmitScore(bool State)
    {
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");

        // Active or deactive input field and buttons until server response
        Background_Canvas.transform.GetChild(14).GetComponent<InputField>().interactable = State;
        Background_Canvas.transform.GetChild(15).GetComponent<Button>().interactable = State;
        Background_Canvas.transform.GetChild(16).GetComponent<Button>().interactable = State;

        if(State)
        {
            Background_Canvas.transform.GetChild(15).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Background_Canvas.transform.GetChild(16).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            Background_Canvas.transform.GetChild(15).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            Background_Canvas.transform.GetChild(16).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }

    public static void Set_TopTenMenu(bool State)
    {
        // Active or deactive top ten menu
        GameObject HighScore_Canvas = GameObject.Find("Game_Controller").GetComponent<Submit_Score>().HighScore_Canvas;
        HighScore_Canvas.SetActive(State);

        // Active loading
        HighScore_Canvas.transform.GetChild(5).gameObject.SetActive(State);
    }
    
    public static void Set_Error(bool State)
    {
        // Active or deactive error
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");
        Background_Canvas.transform.GetChild(17).gameObject.SetActive(State);
    }

    public static void Set_Error(bool State, string Message)
    {
        // Active or deactive error and message
        GameObject Background_Canvas = GameObject.Find("Background_Canvas");
        Background_Canvas.transform.GetChild(17).gameObject.SetActive(State);
        Background_Canvas.transform.GetChild(17).GetComponent<Text>().text = Message;
    }

    public static void Set_RecordListView(int Index, string Name, int High_Score)
    {
        GameObject HighScore_Canvas = GameObject.Find("Game_Controller").GetComponent<Submit_Score>().HighScore_Canvas;
        
        // Deactive loading
        Set_RecordLoading(false);

        // Set top ten name and record
        HighScore_Canvas.transform.GetChild(4).GetChild(0).GetChild(Index).GetChild(0).GetComponent<Text>().text = Name;
        HighScore_Canvas.transform.GetChild(4).GetChild(0).GetChild(Index).GetChild(1).GetComponent<Text>().text = High_Score.ToString();
    }

    public static void Set_RecordLoading(bool State)
    {
        GameObject HighScore_Canvas = GameObject.Find("Game_Controller").GetComponent<Submit_Score>().HighScore_Canvas;

        // Active or deactive loading
        HighScore_Canvas.transform.GetChild(5).gameObject.SetActive(false);
    }

    public static void Set_RecordMessage(string Record_Data)
    {
        GameObject HighScore_Canvas = GameObject.Find("Game_Controller").GetComponent<Submit_Score>().HighScore_Canvas;
        HighScore_Canvas.transform.GetChild(6).GetComponent<Text>().text = Record_Data;
    }
}
