using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    public static UIManager Instance;
    public Button resetButton;
    public GameObject gameOverPanel;
    public GameObject startPanel;
    public Button startButton;
    public Button exitButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ShowStartPanel();
    }
    void OnEnable()
    {
        resetButton.onClick.AddListener(OnResetButtonClicked);
        startButton.onClick.AddListener(OnStartButtonClicked);
    }
    void OnDisable()
    {
        resetButton.onClick.RemoveListener(OnResetButtonClicked);
        startButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        GameManager.Instance.StartGame();
        HideStartPanel();
    }
    private void OnResetButtonClicked()
    {
        GameManager.Instance.ResetGame();
        HideGameOverPanel();
    }

    private void HideStartPanel()
    {
        startPanel.SetActive(false);
    }
    private void ShowStartPanel()
    {
        startPanel.SetActive(true);
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString("00"); // Format score as a 2-digit number
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
