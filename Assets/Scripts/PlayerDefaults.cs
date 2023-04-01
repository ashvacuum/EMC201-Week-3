using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Defaults", menuName = "Game Prog 1/Player Default", order = 0)]
public class PlayerDefaults : ScriptableObject
{
    public float speed;
    public float jumpForce;
    public float lazerBeamRange;

    public void MathDemo()
    {
        UnityEngine.Random.Range(0f, 100f);

        Mathf.Min(100, speed - 1);
        Mathf.Max(0, jumpForce - 1);
        Mathf.Clamp(jumpForce, 0, 20f);

        Mathf.Abs(jumpForce);
        Mathf.Round(speed);
        Mathf.RoundToInt(speed);

        Mathf.Floor(speed);
        Mathf.FloorToInt(speed);

        Mathf.Pow(2, 2);

        Mathf.Sin(speed);
        Mathf.Cos(speed);
        Mathf.Tan(speed);

        Mathf.Asin(speed);
        Mathf.Acos(speed);
        Mathf.Atan(speed);

        Mathf.Clamp01(speed);



    }
}
