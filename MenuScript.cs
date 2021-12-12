using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    //Buttons for main menu
    public GameObject playButton;
    public GameObject helpButton;
    public GameObject quitButton;
    public GameObject scoreButton;
    public GameObject scoreTextScreen;

    public TextMeshProUGUI scoreText;
    public GameObject helpMenu;

    //Buttons for game modes
    public GameObject normalMode;
    public GameObject advancedMode;
    public GameObject infoMode;
    public GameObject reactiveMode;

    //Back Button
    public GameObject backButton;

    //Paper sprite
    public GameObject paper;

    //Sound System
    AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        //Set Audio Source Component
        sounds = GetComponents<AudioSource>();

        //Hide back button and score screen
        backButton.gameObject.SetActive(false);
        scoreTextScreen.gameObject.SetActive(false);

        //Main Menu
        playButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        scoreButton.gameObject.SetActive(true);

        //Instructions
        helpMenu.gameObject.SetActive(false);

        //Game Modes
        normalMode.gameObject.SetActive(false);
        advancedMode.gameObject.SetActive(false);
        infoMode.gameObject.SetActive(false);
        reactiveMode.gameObject.SetActive(false);

    }

    public void PlayMenu()
    {
        //When Play Button is pressed
        sounds[1].Play();
        normalMode.gameObject.SetActive(true);
        advancedMode.gameObject.SetActive(true);
        infoMode.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        reactiveMode.gameObject.SetActive(true);

        playButton.gameObject.SetActive(false);
    }

    public void BacktoMainMenu()
    {
        sounds[1].Play();
        //Return back to the main menu
        backButton.gameObject.SetActive(false);
        scoreTextScreen.gameObject.SetActive(false);

        //Main Menu
        playButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        scoreButton.gameObject.SetActive(true);

        //Instructions
        helpMenu.gameObject.SetActive(false);

        //Game Modes
        normalMode.gameObject.SetActive(false);
        advancedMode.gameObject.SetActive(false);
        infoMode.gameObject.SetActive(false);
        reactiveMode.gameObject.SetActive(false);

        paper.transform.position = new Vector3(0f, 0.5f, 0f);
    }
    public void ExitButton()
    {
        //Quit the game
        sounds[1].Play();
        Application.Quit();
    }
    public void HowToPlayButton()
    {
        sounds[1].Play();

        //Displays help menu
        playButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        scoreButton.gameObject.SetActive(false);

        //hide other things
        normalMode.gameObject.SetActive(false);
        advancedMode.gameObject.SetActive(false);
        infoMode.gameObject.SetActive(false);
        reactiveMode.gameObject.SetActive(false);

        helpMenu.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        paper.transform.position = new Vector3(0f, -2f, 0f);
    }

    public void ScoreButton()
    {
        //hide other buttons
        playButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        //Display scores
        sounds[1].Play();
        scoreTextScreen.gameObject.SetActive(true);
        scoreText.text = "Normal Mode: " + NormalMode.score + "\n\n\nAdvanced Mode: " + AdvancedMode.score + "\n\n\nInform Mode: " + InfoMode.score + "\n\n\nReactive Mode: " + ReactiveMode.score;
    }

    public void Normal()
    {
        //Change to normal mode
        SceneManager.LoadScene("NormalMode");
    }

    public void Advanced()
    {
        //Change to advanced mode
        SceneManager.LoadScene("AdvancedMode");
    }

    public void Info()
    {
        //Change to inform mode
        SceneManager.LoadScene("InfoMode");
    }

    public void Reactive()
    {
        //Change to reactive mode
        SceneManager.LoadScene("ReactiveMode");
    }
}
