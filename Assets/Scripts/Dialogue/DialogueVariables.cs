using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables {get; private set;}
    private Story globalVariablesStory;
    private const string saveVariablesKey = "INK_VARIABLES";

    public DialogueVariables(TextAsset globalsLoaderJSON, string globalStatesJson)
    {
        //Creating story
        globalVariablesStory = new Story(globalsLoaderJSON.text);
        //Check for data and load it if present
        if(!globalStatesJson.Equals(""))
        {
            globalVariablesStory.state.LoadJson(globalStatesJson);
        }
        //Initialize the variable dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public string SaveVariablesToGlobalsJSON()
    {
        //Put current variable states in globals story
        VariablesToStory(globalVariablesStory);
        // return states
        return globalVariablesStory.state.ToJson();
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
