using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScrollOffset backgroundScript;

    private int score;
    private bool isGameOver;
    public static GameManager Instance { get; private set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    private void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {   //Reinicia la escena buscando por el indice activo
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int points)
    {
        score += points;
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = "score: " + score.ToString();
    }

    public void StopGame()
    {
        isGameOver = true;
        StopScroll();
        StopSpawn();
        ShowGameOverPanel();
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void StopSpawn()
    {
        Spawner[] spawnerObjects = FindObjectsOfType<Spawner>();
        foreach (Spawner spawnerObject in spawnerObjects)
        {
            spawnerObject.StopSpawn();
        }
    }

    private void StopScroll()
    {
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll scrollingObject in scrollingObjects)
        {
            scrollingObject.StopScroll();
        }

        backgroundScript.StopScroll();
    }
}