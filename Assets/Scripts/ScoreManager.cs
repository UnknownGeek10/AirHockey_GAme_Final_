using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public enum Score
    {
        BotScore, PlayerScore
    }

    public Text BotScoreText, PlayerScoreText;

    public UIManager uiManager;

    public int maxScore;


    private int botScore, playerScore;

    private int BotScore { get { return botScore; } set { botScore = value; if (value == maxScore) uiManager.ShowRestartCanvas(true); } }
    private int PlayerScore { get { return playerScore; } set { playerScore = value; if (value == maxScore) uiManager.ShowRestartCanvas(false); } }


    public void Increment(Score whichScore)
    {
        if (whichScore == Score.BotScore)
            BotScoreText.text = (++BotScore).ToString();
        else
            PlayerScoreText.text = (++PlayerScore).ToString();
    }

    public void ResetScores()
    {
        BotScore = PlayerScore = 0;
        BotScoreText.text = PlayerScoreText.text = "0";
    }
}
