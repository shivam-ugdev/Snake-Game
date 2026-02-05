using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
