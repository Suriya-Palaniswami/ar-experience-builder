using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public delegate void GameAction(int _executionLevel, object _o);

    public static event GameAction OnGameAction;

    public static void DoGameAction(int _executionLevel, object _o)
    {

        OnGameAction(_executionLevel, _o);
    }
}
