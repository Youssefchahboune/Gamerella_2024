using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void updateScore (int points)
    {
        score += points;
        scoreText.text = score + " pts";
    }

    public static void SetArsonHealth(int damageValue)
    {
        arsonHealthBarSlider.value = arsonHealthBarSlider.value - damageValue;
    }

    public static void SetHearthHealth(int damageValue)
    {
        hearthHealthBarSlider.value = hearthHealthBarSlider.value - damageValue;
    }
}
