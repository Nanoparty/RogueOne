using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class stats
{


    private static int max, coins, health, level;
    private static bool char2, char3, char4;

    public static int Max
    {
        get
        {
            return max;
        }
        set
        {
            max = value;
        }
    }

    public static int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public static int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }

    public static bool Char2
    {
        get
        {
            return char2;
        }
        set
        {
            char2 = value;
        }
    }

    public static bool Char3
    {
        get
        {
            return char3;
        }
        set
        {
            char3 = value;
        }
    }
}
