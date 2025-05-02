using System.Collections;
using UnityEngine;

public interface IState 
{
    IStateMachine StateMachine { get; }
    IEnumerator OnEnter(); 
    IEnumerator OnExit();
    IEnumerator OnUpdate();
}
