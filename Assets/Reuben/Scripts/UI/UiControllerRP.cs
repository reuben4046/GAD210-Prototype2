using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiControllerRP : MonoBehaviour
{

    public GameObject menu;

    public GameObject inGameUi;
    public GameObject livesPanel;
    public GameObject checkpointsPanel;

    void Start()
    {
        elapsedTime = 0f;
        menu.SetActive(true);
        inGameUi.SetActive(false);
    }

    void OnEnable()
    {
        EventsSystemRP.OnCloseMenuAndStartGame += CloseMenuAndStartGame;
        EventsSystemRP.OnGetLives += GetLives;
        EventsSystemRP.OnGetCheckPoints += GetCheckPoints;
        EventsSystemRP.OnLastCheckpointReached += LastCheckpointReached;
        EventsSystemRP.OnPlayerDeath += PlayerDeath;
    }

    void OnDisable()
    {
        EventsSystemRP.OnCloseMenuAndStartGame -= CloseMenuAndStartGame;
        EventsSystemRP.OnGetLives -= GetLives;
        EventsSystemRP.OnGetCheckPoints -= GetCheckPoints;
        EventsSystemRP.OnLastCheckpointReached -= LastCheckpointReached;
        EventsSystemRP.OnPlayerDeath -= PlayerDeath;
    }

    void CloseMenuAndStartGame(bool mode)
    {
        menu.SetActive(false);
        inGameUi.SetActive(true);
        switch (mode)
        {
            case true:
                checkpointsPanel.SetActive(true);
                livesPanel.SetActive(false);
                updateTime = true;
                break;
            case false:
                livesPanel.SetActive(true);
                checkpointsPanel.SetActive(false);
                updateTime = true;
                break;
        }
    }

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI checkpointsText;


    public void GetLives(int lives)
    {
        livesText.text = $"Lives: {lives.ToString()}";
    }

    public void GetCheckPoints(int checkpoints)
    {
        checkpointsText.text = $"Checkpoints: {checkpoints.ToString()}";
    }


    [SerializeField] private TextMeshProUGUI timerText;

    private float elapsedTime;
    bool updateTime = false;

    void Update()
    {
        if (updateTime)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void LastCheckpointReached()
    {
        updateTime = false;
    }

    [SerializeField] private TextMeshProUGUI playerDeathsText;
    int playerDeaths = 0;

    public void PlayerDeath()
    {
        playerDeaths++;
        playerDeathsText.text = playerDeaths.ToString();
    }
}
