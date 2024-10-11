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
}
