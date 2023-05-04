using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LostTxt;

    [Header("Other")]

    public ScoreManager scoreManager;

    public PuckController puckController;
    public PlayerController playerController;
    public AIController AIController;

    public void ShowRestartCanvas(bool AIWon)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (AIWon)
        {
            WinTxt.SetActive(false);
            LostTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LostTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreManager.ResetScores();
        playerController.ResetPosition();
        AIController.ResetPosition();
    }
}
