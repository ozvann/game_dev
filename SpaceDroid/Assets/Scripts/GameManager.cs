using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;

    private bool isPaused;
    private bool isGameOver;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.kKey.wasPressedThisFrame && !isGameOver)
        {
            SetPause(!isPaused);
        }
    }

    private void Start()
    {
        FindUiObjectsIfNeeded();

        if (quitButton != null && quitButton.onClick.GetPersistentEventCount() == 0)
        {
            quitButton.onClick.AddListener(QuitGame);
        }

        if (restartButton != null && restartButton.onClick.GetPersistentEventCount() == 0)
        {
            restartButton.onClick.AddListener(Restart);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (pauseText != null)
        {
            pauseText.gameObject.SetActive(false);
        }

        if (quitButton != null)
        {
            quitButton.gameObject.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
        }
    }

    private void FindUiObjectsIfNeeded()
    {
        if (gameOverPanel == null)
        {
            gameOverPanel = GameObject.Find("GameOverPanel");
        }

        if (gameOverText == null)
        {
            GameObject textObject = GameObject.Find("Game Over");
            if (textObject != null)
            {
                gameOverText = textObject.GetComponent<TextMeshProUGUI>();
            }
        }

        if (pauseText == null)
        {
            GameObject textObject = GameObject.Find("Pause");
            if (textObject != null)
            {
                pauseText = textObject.GetComponent<TextMeshProUGUI>();
            }
        }

        if (quitButton == null)
        {
            GameObject quitObject = GameObject.Find("Quit");
            if (quitObject != null)
            {
                quitButton = quitObject.GetComponent<Button>();
            }
        }

        if (restartButton == null)
        {
            GameObject restartObject = GameObject.Find("Restart");
            if (restartObject != null)
            {
                restartButton = restartObject.GetComponent<Button>();
            }
        }
    }

    public static void GameOver()
    {
        if (Instance == null)
        {
            return;
        }

        Instance.isGameOver = true;
        Instance.isPaused = false;

        if (Instance.pauseText != null)
        {
            Instance.pauseText.gameObject.SetActive(false);
        }

        if (Instance.gameOverPanel != null)
        {
            Instance.gameOverPanel.SetActive(true);
        }

        if (Instance.gameOverText != null)
        {
            Instance.gameOverText.gameObject.SetActive(true);
        }

        if (Instance.quitButton != null)
        {
            Instance.quitButton.gameObject.SetActive(true);
        }

        if (Instance.restartButton != null)
        {
            Instance.restartButton.gameObject.SetActive(true);
        }

        Time.timeScale = 0.0f;
    }

    public static void SetPause(bool pause)
    {
        if (Instance == null || (pause && Instance.isGameOver))
        {
            return;
        }

        Instance.isPaused = pause;

        if (Instance.pauseText != null)
        {
            Instance.pauseText.gameObject.SetActive(pause);
        }

        Time.timeScale = pause ? 0.0f : 1.0f;
    }

    public static void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public static void Restart()
    {
        if (Instance != null)
        {
            Instance.isPaused = false;
            Instance.isGameOver = false;
        }

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
