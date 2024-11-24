using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI dropletsKilled;

    void Start()
    {
        scoreText.text = ": " + GlobalVariables.getScore() + " pts";
        dropletsKilled.text = "x " + GlobalVariables.getDropletKill();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GlobalVariables.ResetGame();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
