using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
  public Button mainMenuButton;
  public Button playAgainButton;

  private void Start()
  {
    mainMenuButton.onClick.AddListener(MainMenu);
    playAgainButton.onClick.AddListener(PlayAgain);
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene("TheGame");
  }
}
