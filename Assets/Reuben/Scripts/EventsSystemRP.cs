using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class EventsSystemRP
{
    public delegate void ResetCheckPoints();
    public static ResetCheckPoints OnResetCheckPoints;

    public delegate void GetCurrentCheckpoint(CheckpointRP checkPoint);
    public static GetCurrentCheckpoint OnGetCurrentCheckpoint;

    public delegate void isCheckpointMode(bool isInCheckpointMode);
    public static isCheckpointMode OnIsInCheckpointMode;

    public delegate void CloseMenuAndStartGame(bool isInCheckpointMode);
    public static CloseMenuAndStartGame OnCloseMenuAndStartGame;

    public delegate void GetLives(int lives);
    public static GetLives OnGetLives;

    public delegate void GetCheckPoints(int checkPoint);
    public static GetCheckPoints OnGetCheckPoints;

    public delegate void lastCheckpointReached();
    public static lastCheckpointReached OnLastCheckpointReached;

    public delegate void PlayerDeath();
    public static PlayerDeath OnPlayerDeath;
}
