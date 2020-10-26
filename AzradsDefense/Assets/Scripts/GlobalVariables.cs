using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    private static int level;
    private static int enemiesDestroyed;

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

    public static int EnemiesDestroyed
    {
        get
        {
            return enemiesDestroyed;
        }
        set
        {
            enemiesDestroyed = value;
        }
    }
}
