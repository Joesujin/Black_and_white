using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events 
{
    public static Action<Color> ChangeColor;

    public static Action<int> ColorId;

    public static Action<int> Date;

    public static Action<int[]> saveProject;

    public static Action<int> saveButton;

    public static Action drawScreen;

    public static Action RecallDrawscreen;

    public static Action projectScreen;

    public static Action Destroytiles;

    public static Action<int> refreshTile;

    public static Action<int[]> recallProject;

    public static Action<int> ButtonCall;
}
