using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{

    [SerializeField]
    private City city;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    //this array will store the prefabs and their according values
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
    }
}
