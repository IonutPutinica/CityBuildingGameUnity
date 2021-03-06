﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour  {


    //the board has a 2 dimensional array that stores buildings
     private Building[,] buildings = new Building[100, 100];

    //instatiating the object and placing it in the world, depending on where the user clicked, which is registred by the vector3

    public void AddBuilding(Building building, Vector3 position)
    {
        //quaterion gives the object the rotation that it actually has 
        buildings[(int)position.x, (int)position.z] = Instantiate(building, position, Quaternion.identity);
        SoundManager.PlaySound ("build");
       
    }

    public Building CheckForBuildingAtPosition(Vector3 position)
    {
        return buildings[(int)position.x, (int)position.z];
    }

    public void RemoveBuilding(Vector3 position)
    {
        Destroy(buildings[(int)position.x, (int)position.z].gameObject);
        buildings[(int)position.x, (int)position.z] = null;
        SoundManager.PlaySound ("sell");
    }

    //building position
    public Vector3 CalculateGridPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round(position.x), .5f, Mathf.Round(position.z));
    }
    
}
