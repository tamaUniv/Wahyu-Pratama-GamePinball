using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditUIController : MonoBehaviour
{
  public Button menuButton;

  private void Start()
  {
    menuButton.onClick.AddListener(MainMenu);
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
