﻿using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        //user can hold shift to build multiple buildings
        if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedBuilding!=null)
        {
            InteractWithBoard();
        }
        //it checks if the mouse is clicked, but it only works if a building is pre-selected
        else if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            InteractWithBoard();
        }
    }

    void InteractWithBoard()
    {
        //generates a ray at the clicked position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);
            //build a building if there is not a building at that position
            //in addition, it checks if the mouse is clicked over a game object (UI) - so it doesn't build when a user selects a building type for exameple
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() &&!board.CheckForBuildingAtPosition(gridPosition))
            {
                //do I have enough cash to build it??
                if(city.Cash>=selectedBuilding.cost)
                {
                    //substracting the cost of the building from the total money
                    city.Cash -= selectedBuilding.cost;
                    uiController.UpdateCityData();
                    city.buildingCounts[selectedBuilding.id]++;
                    //adding the building to the world
                    board.AddBuilding(selectedBuilding, gridPosition);

                }
            }
        }
    }

    

    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
        Debug.Log("Selected building: " + selectedBuilding.buildingName);
    }
}
