using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text GameOverText;
    private Board board;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if (board.GameOver)
        {
            GameOverText.text = $"Game over, {board.winningColor} wins!";
            GameOverPanel.SetActive(true);
            
        }
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
