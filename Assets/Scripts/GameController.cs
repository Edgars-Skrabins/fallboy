using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private GameObject m_PauseGameOverMenu;
    [SerializeField] private TMP_Text m_menuTitleText;

    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_resumeButton, m_retryButton;

    [SerializeField] private PlayerScore m_playerScore;

    public bool m_gameStarted,m_gamePaused;

    [SerializeField] private Transform m_camera;
    [SerializeField] private float m_shakeDuration = 0.5f;
    [SerializeField] private float m_shakeAmount = 0.7f;
    [SerializeField] private GameObject m_crosshairGO;

    private Vector3 m_originalPos;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (!m_gameStarted) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void StartGame()
    {
        m_gameStarted = true;
        Time.timeScale = 1;
        m_menuTitleText.text = "Paused!!";
        m_player.SetActive(true);
        m_playerScore.ResetScores();

        m_resumeButton.SetActive(true);
        m_retryButton.SetActive(false);
    }

    void PauseGame()
    {
        m_gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_PauseGameOverMenu.SetActive(true);
        Time.timeScale = 0;
        m_crosshairGO.SetActive(false);
    }

    public void UnpauseGame()
    {
        m_gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_PauseGameOverMenu.SetActive(false);
        Time.timeScale = 1;
        m_crosshairGO.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_crosshairGO.SetActive(false);

        m_gameStarted = false;
        m_PauseGameOverMenu.SetActive(true);
        m_resumeButton.SetActive(false);
        m_retryButton.SetActive(true);
        m_menuTitleText.text = "Game Over!!";
        m_player.SetActive(false);
        m_playerScore.IsHighScore();
    }

    public void CameraShake()
    {
        m_originalPos = m_camera.transform.localPosition;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < m_shakeDuration)
        {
            float offsetX = Random.Range(-m_shakeAmount, m_shakeAmount);
            float offsetY = Random.Range(-m_shakeAmount, m_shakeAmount);

            m_camera.transform.localPosition = m_originalPos + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        m_camera.transform.localPosition = m_originalPos;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
