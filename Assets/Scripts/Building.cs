using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //an integer which defines the id of a building - road=0, house=1, farm=2, factory=3
    public int id;
    //allows to define in the inspector the cost of buildings
    public int cost;
    public string buildingName;
}
