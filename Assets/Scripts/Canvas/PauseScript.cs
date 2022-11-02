using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject SettingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        PauseMode(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMode(bool isPause)
    {
        GameManager.IsGamePuase(isPause);

        if (isPause)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
    }
}
