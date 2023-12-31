using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI ammoText;

    private int scoreValue;
    [SerializeField] private GameObject tryAgainButton;

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 1)
            timerText.text = Time.time.ToString("#,#");
    }
    public void AddScore() 
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString("#,#");
    }

    public void UpdateAmmoInfo(int currentBullets, int maxBullets)
    {
        ammoText.text = currentBullets + "/" + maxBullets;
    }

    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
