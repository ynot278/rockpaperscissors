using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoMode : MonoBehaviour
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
        enemyChoice = Random.Range(1, 4);

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

    public void playGame()
    {
        while (input)
        {
            screenText.fontSize = 34;

            if (userChoice == 1)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot also chose rock! You tied!\nSince you tied, the system expects the player\nto play the same thing again (ROCK),\nso the system will choose what beats it (PAPER)";
                    score++;
                    enemyScore++;
                    enemyChoice = 2;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot chose paper! You lost!\nSince the system won, players are more likely to expect\nthe system to play the same thing again (PAPER),\nso the system will choose what the player played last (ROCK)";
                    enemyScore += 2;
                    enemyChoice = 1;
                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot chose scissors! You won!\nSince you won, the system expects the player\n to play the same thing again (ROCK),\nso the system will choose what beats it (PAPER)";
                    score += 2;
                    enemyChoice = 2;
                }
            }
            else if (userChoice == 2)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot chose rock! You won!\nSince you won, the system expects the player\n to play the same thing again (PAPER),\nso the system will choose what beats it (SCISSORS)";
                    score += 2;
                    enemyChoice = 3;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot also chose paper! You tied!\nSince you tied, the system expects the player\nto play the same thing again (PAPER),\nso the system will choose what beats it (SCISSORS)";
                    score++;
                    enemyScore++;
                    enemyChoice = 3;

                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot chose scissors! You lost!\nSince the system won, players are more likely to expect\nthe system to play the same thing again (SCISSORS),\nso the system will choose what the player played last (PAPER)";
                    enemyScore += 2;
                    enemyChoice = 2;
                }
            }
            else if (userChoice == 3)
            {
                if (enemyChoice == 1)
                {
                    screenText.text = "The bot chose rock! You lost!\nSince the system won, players are more likely to expect\nthe system to play the same thing again (ROCK),\nso the system will choose what the player played last (SCISSORS)";
                    enemyScore += 2;
                    enemyChoice = 3;
                }
                else if (enemyChoice == 2)
                {
                    screenText.text = "The bot chose paper! You won!\nSince you won, the system expects the player\n to play the same thing again (SCISSORS),\nso the system will choose what beats it (ROCK)";
                    score += 2;
                    enemyChoice = 1;
                }
                else if (enemyChoice == 3)
                {
                    screenText.text = "The bot also chose scissors! You tied!\nSince you tied, the system expects the player\nto play the same thing again (SCISSORS),\nso the system will choose what beats it (ROCK)";
                    score++;
                    enemyScore++;
                    enemyChoice = 1;
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
    public void ExitButton()
    {
        sounds[1].Play();
        SceneManager.LoadScene("MainMenu");
    }
}
