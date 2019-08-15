using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Music class;
[System.Serializable]
public class Music
{
    public Button musicButton;              //Music toggle button;
    public Sprite onIcon;                   //Music on image icon;
    public Sprite offIcon;                  //Misoc off image icon;
    public AudioSource ambientSource;       //Mucic audio source;
}

//Sounds class;
[System.Serializable]
public class Sounds
{
    public Button soundsButton;             //Sounds toggle button;
    public Sprite onIcon;                   //Sounds on image icon;
    public Sprite offIcon;                  //Sounds off image icon;
}


public class MainMenu1 : MonoBehaviour 
{
    public Button playButton;           //Start game button;
    public Button exitButton;           //Quit game button;
    public Button SingleButton;           //Start game button;
    public Button BackButton;           //Start game button;
    public GameObject menuPanel;        //Menu panel object;
    public GameObject SelectPanel;        //Menu panel object;
    public GameObject UserPanel;        //Menu panel object;
    public AudioClip clickSFX;          //Click sound effect;
    public Music music;                 //Music class;
    

//    private bool firstPlay;
    private AudioSource source;
    private Image soundImage, musicImage;

	// Use this for initialization
	void Start () 
	{
        //Cache components;
        source = GetComponent<AudioSource>();
        
        musicImage = music.musicButton.GetComponent<Image>();


        //Assign buttons listeners;
        playButton.onClick.AddListener(StartGame);
        SingleButton.onClick.AddListener(SingleMode);
        BackButton.onClick.AddListener(BackToMode);
        exitButton.onClick.AddListener(() =>
        {
            StartCoroutine(ExitGame());
        });
  
        music.musicButton.onClick.AddListener(ToggleMusic);

        //Load prefs;
        LoadAudioSettings();


	}

    void StartGame()
    {
      
        Game.PlaySound(source, clickSFX);       //Play click sound effect;

        SelectPanel.SetActive(true);               //Enable hud panel;
        menuPanel.SetActive(false);             //Disable menu panel;
        UserPanel.SetActive(false);

    }
    void SingleMode()
    {
        

        Game.PlaySound(source, clickSFX);       //Play click sound effect;

        SelectPanel.SetActive(false);               //Enable hud panel;
        menuPanel.SetActive(false);             //Disable menu panel;
        UserPanel.SetActive(true);
        music.musicButton.gameObject.SetActive(false);


    }

    void BackToMode()
    {


        Game.PlaySound(source, clickSFX);       //Play click sound effect;

        SelectPanel.SetActive(true);               //Enable hud panel;
        menuPanel.SetActive(false);             //Disable menu panel;
        UserPanel.SetActive(false);
        music.musicButton.gameObject.SetActive(true);


    }


    //Quit game function;
    IEnumerator ExitGame()
    {
        Game.PlaySound(source, clickSFX);   //Play click sound effect;
        SaveSettings();                     //Save settings;

        //Wait for click sound effect finished and quie application;
        if (source.isPlaying)
            yield return null;

        SelectPanel.SetActive(false);               //Enable hud panel;
        UserPanel.SetActive(false);
        menuPanel.SetActive(true);             //Disable menu panel;
        music.musicButton.gameObject.SetActive(true);


        //Debug.Log("Quit");
        //Application.Quit();
    }



    //Toggle music function;
    void ToggleMusic()
    {
        Game.music = !Game.music;                                           //Toggle music bool;
        musicImage.sprite = Game.music ? music.onIcon : music.offIcon;      //Change music button image sprite based on music state;
        //Pause or play music based on music state;
        if (Game.music)
            music.ambientSource.Play();
        else
            music.ambientSource.Pause();
    }

    //Load audio settings;
    void LoadAudioSettings()
    {


        if (PlayerPrefs.HasKey("Music"))
            Game.music = Game.GetBool("Music");
        musicImage.sprite = Game.music ? music.onIcon : music.offIcon;

        if (Game.music)
            music.ambientSource.Play();
        else
            music.ambientSource.Pause();
    }

    //Save audio settings;
    void SaveSettings()
    {

        Game.SetBool("Music", Game.music);
    }
}