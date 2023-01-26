using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public string globalVariableStatesJson;
    public Vector3 playerPosition;
    public Dictionary<string, bool> coinsCollected;

    //Define all initial values for a new game
    public GameData()
    {
        playerPosition = new Vector3(-3f,0f,0f);
        this.globalVariableStatesJson = "";
        coinsCollected = new Dictionary<string, bool>();
    }

    public int GetPercentageComplete()
    {
        //TODO Calculate percentage of completion with story, flags and collectibles
        return 100;
    }
}