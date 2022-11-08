using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject SettingsPanel;

    private bool isPauseMode;
    // Start is called before the first frame update
    void Start()
    {
        PauseMode(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseMode)
            {
                PauseMode(false);
            }
            else
            {
                PauseMode(true);
            }

            
        }
    }

    public void PauseMode(bool isPause)
    {
        GameManager.IsGamePuase(isPause);
        isPauseMode = isPause;
        if (isPause)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void ButtonResume()
    {
        PauseMode(false);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
