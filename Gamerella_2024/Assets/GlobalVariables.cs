using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour
{
    // Start is called before the first frame update
    public static float score = 0f;
    public static TextMeshProUGUI scoreText;

    public static Slider arsonHealthBarSlider;
    public static int playerHealth = 100;

    public static Slider hearthHealthBarSlider;
    public static int hearthHealth = 100;


    public static int numberOFDropletKilled = 0;

    void Start()
    {
        // Correctly get the TextMeshProUGUI component using the tag
        GameObject scoreObject = GameObject.FindGameObjectWithTag("score text");

        GameObject arsonHealthBarObject = GameObject.FindGameObjectWithTag("arson health bar");

        arsonHealthBarSlider = arsonHealthBarObject.GetComponent<Slider>();

        arsonHealthBarSlider.value = playerHealth;

        GameObject hearthHealthBarObject = GameObject.FindGameObjectWithTag("hearth health bar");

        hearthHealthBarSlider = hearthHealthBarObject.GetComponent<Slider>();

        hearthHealthBarSlider.value = hearthHealth;

        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
        }
        else
        {
            Debug.LogError("Score text object not found with the specified tag!");
        }

    }

 

    public static void updateScore (int points)
    {
        score = score +  points;
        scoreText.text = score + " pts";
    }

    public static void SetArsonHealth(int damageValue)
    {
        arsonHealthBarSlider.value = arsonHealthBarSlider.value - damageValue;
        if(arsonHealthBarSlider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static void SetHearthHealth(int damageValue)
    {
        hearthHealthBarSlider.value = hearthHealthBarSlider.value - damageValue;
        if(hearthHealthBarSlider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Update()
    {

    }

    public static void ResetGame() {

        score = 0;
        scoreText.text = score + " pts";
        playerHealth = 100;
        hearthHealth = 100;
        numberOFDropletKilled = 0;

    }

    public static void UpdateNumberOfDropletsKilled()
    {
        numberOFDropletKilled = numberOFDropletKilled + 1;
    }

    public static string getDropletKill()
    {
        return numberOFDropletKilled.ToString();
    }

    public static string getScore()
    {
        return score.ToString();
    }
}
