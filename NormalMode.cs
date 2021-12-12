using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NormalMode : MonoBehaviour
{

    public GameObject paper;
    public GameObject scissor;
    public GameObject rock;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI screenText;
    public TextMeshProUGUI botscoreText;

    public GameObject rockButton;
    public GameObject scissorButton;
    public GameObject paperButton;

    public static int score = 0;
    private static int enemyScore = 0;
    private int userChoice = 0;
    private int enemyChoice = 0;
    private bool input;
    private bool rotate;

    private float timer = 1f;

    AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        sounds[1].Play();
        scoreText.text = "Score: " + score.ToString();
        botscoreText.text = "Enemy Score: " + enemyScore.ToString();
        screenText.text = "Make Your Move!";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        botscoreText.text = "Enemy Score: " + enemyScore.ToString();

        playGame();

        if (rotate)
        {
            switch (userChoice)
            {
                case 1:
                    rock.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
                    break;
                case 2:
                    paper.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
                    break;
                case 3:
                    scissor.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
                    break;
            }
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                rotate = false;

                //reset z rotation to 0
                rock.transform.rotation = Quaternion.Euler(0, 0, 0);
                paper.transform.rotation = Quaternion.Euler(0, 0, 0);
                scissor.transform.rotation = Quaternion.Euler(0, 0, 0);

                timer = 1f;
                rockButton.SetActive(true);
                paperButton.SetActive(true);
                scissorButton.SetActive(true);
            }
        }
    }

    public void ExitButton()
    {
        sounds[1].Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void playGame()
    {
        while (input)
        {
            enemyChoice = Random.Range(1, 4);

            if (userChoice == 1)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot also chose rock! You tied!";
                    score++;
                    enemyScore++;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot chose paper! You lost!";
                    enemyScore += 2;
                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot chose scissors! You won!";
                    score += 2;
                }
            }
            else if (userChoice == 2)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot chose rock! You won!";
                    score += 2;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot also chose paper! You tied!";
                    score++;
                    enemyScore++;

                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot chose scissors! You lost!";
                    enemyScore += 2;
                }
            }
            else if (userChoice == 3)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot chose rock! You lost!";
                    enemyScore += 2;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot chose paper! You won!";
                    score += 2;
                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot also chose scissors! You tied!";
                    score++;
                    enemyScore++;
                }
            }
            input = false;
        }
    }

    public void rockSelected()
    {
        sounds[1].Play();
        userChoice = 1;
        input = true;
        rotate = true;

        rockButton.SetActive(false);
        paperButton.SetActive(false);
        scissorButton.SetActive(false);
    }

    public void paperSelected()
    {
        sounds[1].Play();
        userChoice = 2;
        input = true;
        rotate = true;

        rockButton.SetActive(false);
        paperButton.SetActive(false);
        scissorButton.SetActive(false);
    }

    public void scissorSelected()
    {
        sounds[1].Play();
        userChoice = 3;
        input = true;
        rotate = true;

        rockButton.SetActive(false);
        paperButton.SetActive(false);
        scissorButton.SetActive(false);
    }

    public static void sayHi()
    {
        Debug.Log("hi");
    }
}
