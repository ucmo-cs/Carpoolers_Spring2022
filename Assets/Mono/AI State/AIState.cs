using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// You can inherit from this function and change the behavior if your needs for a state thing need to be more specific
public class AIState : MonoBehaviour
{
  public UnityEvent onState; // the functions that will be ran whenever this state is first activated and will trigger this state's actions
  public List<AIState> subStates; // an optional list of states this class can handle
  public int initialState; // the state from the list of sub states to start from; default is 0
  public bool invokeOnStart; // whether the action for this state should be ran on start
  public bool invokeChildOnStart; // whether the initial sub state action should be ran on start
  public bool loopSequentially; // whether the substates should be looped sequentially or a random one should be selected each time
  public List<int> chanceToBeSelected; // if loopSequentially isn't true, then this dictates the chances a state has of being chosen
                                       // please have this have the same length as the substates list. I don't want to have to deal with custom editors to force this, although I'll have to eventually

  [HideInInspector] public AIState father; // the parent state; if this state is being held in a list of substates, this variable holds the state holding the list of substates

  private int currState;

  void Start()
  {
    currState = initialState >= subStates.Count ? subStates.Count - 1 : initialState;
    if (initialState >= subStates.Count && subStates.Count > 0)
      Debug.Log("Warning: The initial state selected is larger than the length of the list of states. Defaulting to last state");
    if (currState == -1 && invokeChildOnStart) Debug.Log("Warning: There are no substates.");

    if (invokeOnStart) onStateStart();
    if (invokeChildOnStart && currState > -1) subStates[currState].onStateStart();

    for (int i = 0; i < subStates.Count; i++)
    {
      subStates[i].father = this;
    }
  }

  public void onStateStart()
  {
    onState.Invoke();
  }

  // should be ran by processes invoked by onStateStart to mark the moving on to the next state
  public void nextState()
  {
    if (loopSequentially) currState = (currState + 1) % subStates.Count;
    else
    {
      if (chanceToBeSelected.Count == 0) currState = Random.Range(0, subStates.Count);
      else
      {
        int totalPool = 0;
        for (int i = 0; i < chanceToBeSelected.Count; i++)
        {
          totalPool += chanceToBeSelected[i];
        }

        int selected = Random.Range(0, totalPool + 1);

        for (int i = 0; i < chanceToBeSelected.Count; i++)
        {
          selected -= chanceToBeSelected[i];
          if (selected <= 0)
          {
            currState = i;
            if (currState >= subStates.Count)
            {
              currState = subStates.Count - 1;
              Debug.Log("Warning: Next state index selected is outside the range of the list of states. Defaulting to last state.");
            }
            break;
          }
        }
      }
    }

    subStates[currState].onStateStart();
  }
}
