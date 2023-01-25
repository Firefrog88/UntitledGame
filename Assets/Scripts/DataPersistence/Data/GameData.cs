using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string globalVariableStatesJson;
    public Vector3 playerPosition;
    public Dictionary<string, bool> coinsCollected;

    //Define all initial values for a new game
    public GameData()
    {
        this.globalVariableStatesJson = "";
        playerPosition = new Vector3(-3f,0f,0f);
        coinsCollected = new Dictionary<string, bool>();
    }
}