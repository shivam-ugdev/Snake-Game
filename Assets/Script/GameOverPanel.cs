using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Score scoreManager;
    public Text finalScoreText;


    void OnEnable()
    {
        finalScoreText.text = "Score : " + scoreManager.score;
    }
}
