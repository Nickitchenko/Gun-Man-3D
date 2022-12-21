using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney=400;
    public int m;

    public static int Lives;
    public int startLives = 20;
    public int l;

    public static int Rounds;

    private void Start()
    {
        Money = StartMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
