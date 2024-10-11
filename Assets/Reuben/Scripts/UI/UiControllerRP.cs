using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControllerRP : MonoBehaviour
{

    public GameObject menu;

    public GameObject inGameUi;
    public GameObject livesPanel;
    public GameObject checkpointsPanel;

    void Start()
    {
        menu.SetActive(true);
        inGameUi.SetActive(false);
    }

    void OnEnable()
    {
        EventsSystemRP.OnCloseMenuAndStartGame += CloseMenuAndStartGame;
    }

    void OnDisable()
    {
        EventsSystemRP.OnCloseMenuAndStartGame -= CloseMenuAndStartGame;
    }

    void CloseMenuAndStartGame(bool mode)
    {
        menu.SetActive(false);
        inGameUi.SetActive(true);
        if (mode)
        {
            checkpointsPanel.SetActive(true);
            livesPanel.SetActive(false);
        }
        if (!mode)
        {
            livesPanel.SetActive(true);
            checkpointsPanel.SetActive(false);
        }
    }
}
