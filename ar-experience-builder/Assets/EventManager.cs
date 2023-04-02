using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    
    public delegate void PriorAction(object _o);

    public static event PriorAction OnPriorAction;

    public static void DoPriorAction(object _o)
    {
        OnPriorAction(_o);
    }

    public delegate void ImviObjectAction(ImviObject imviObject,object _o);

    public static event ImviObjectAction OnObjectAction;

    public static void DoObjectAction(ImviObject imviObject, object _o)
    {
        OnObjectAction(imviObject, _o);
    }

    public delegate void NextAction(int nextCall, object _o);

    public static event NextAction OnNextAction;

    public static void DoNextAction(int nextCall,object _o)
    {
        OnNextAction(nextCall,_o);
    }
}
