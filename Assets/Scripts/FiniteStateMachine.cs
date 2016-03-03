using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FiniteStateMachine<T> // <T> Generic 
{
    private List<T> StateList;                      //[Variable]// List of <T>s of the States 
    private List<string> TransitionList;            //[Variable]// List of <string>s of Valid Transistions 
    private T CurrentState;                         //[Variable]// Current State of Machine


    public FiniteStateMachine()                         //[Function]// Default Constructor 
    {
        StateList       = new List<T>();
        TransitionList  = new List<string>();

        LoadStates();
        // CurrentState will be set to the first object in the Generic
    }

    public FiniteStateMachine(T initialState)           //[Function]// Custom Constructor
    {
        StateList = new List<T>();
        TransitionList = new List<string>();

        LoadStates();

        CurrentState = initialState;
    }

    public T GetCurrentState()                          //[Function]// Returns CurrentState // Getter
    {
        return CurrentState;
    }

    public void AddState(T t)                           //[Function]// Add a Generic to StateList
    {
        StateList.Add(t);
    }

    private void LoadStates()                           //[Function]// Load All states into StateList
    {
        if (typeof(T) == typeof(Enum))
        {
            var values = Enum.GetValues(typeof(T)); // Values equals each value in <T>

            foreach (var v in values)               // For each "State" that was stored in v
                StateList.Add((T)v);                // We add it to our StateList. Once we've Typecasted it
        }
    }

    public void AddTransition(T from, T to)             //[Function]// Add valid Transistions to TransitionList
    {
        string t = from.ToString() + ">" + to.ToString();  // Create string of this transistion

        if (!TransitionList.Contains(t))    // if transistion is not already added..
        {
            TransitionList.Add(t);          // add to list
        }
    }

    public bool Transition(T to)                        //[Function]// Make Transistion
    {
        string t = CurrentState.ToString() + ">" + to.ToString();

        if (CheckTransition(CurrentState, to))      // If passed Check
        {
            CurrentState = to;
            return true;
        }

        Debug.Log("Failed Transition \nCheckTransition(" + t + ") is Not Valid");
        return false;
    }

    public void PrintStates()                           //[Function]// Print all States // Debug Tool
    {
        foreach (T t in StateList)
        {
            Debug.Log(t.ToString() + " State");
        }
    }

    private bool CheckTransition(T from, T to)          //[Function]// Return if Transistion is valid
    {
        string f = from.ToString();
        string t = to.ToString();
        string valid = f + ">" + t;
        if (TransitionList.Contains(valid))
        {
            return true;
        }
        return false;
    }
}

// Implementation ////////////////
/*
    // Example: //
    FiniteStateMachine<State> _fsm = new FiniteStateMachine<State>()                   // Default Constructor
                                    //- or -//
    FiniteStateMachine<State> _fsm = new FiniteStateMachine<State>(State.INIT)         // Custom Constructor // Sets CurrentState to GameState.INIT

    _fsm.Transition(State.INIT, State.RUNNING);                                        // Sets a valid Transition between INIT to RUNNING
    ...
    
*/
//////////////////////////////////