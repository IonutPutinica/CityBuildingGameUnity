using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    public int Cash { get; set; }
    public int Day { get; set; }
    public float PopulationCurrent { get; set; }
    //the limit of population, which is defined by the amount of created houses
    public float PopulationCeiling { get; set; }
    public int JobsCurrent { get; set; }
    public int JobsCeiling { get; set; }
    public float Food { get; set; }

    public int[] buildingCounts = new int[4];

    private UIController uiController;

    void Start()
    {
        uiController = GetComponent<UIController>();
        Cash = 10000;
        Food = 6;
        JobsCeiling = 10;
    }

    //at the end of each day, calculations are made, to define the new food supply, population, money and jobs
   public void EndTurn()
    {
        Day++;
        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        Debug.Log("Day ended.");
        uiController.UpdateCityData();
        uiController.UpdateDayCount();
        //Testing method!
        Debug.LogFormat
            ("Jobs: {0}/{1}, Cash: {2}, pop: {3}/{4}, Food: {5}",
            JobsCurrent, JobsCeiling, Cash, PopulationCurrent, PopulationCeiling, Food);
    }

    void CalculateJobs()
    {
        //each factory gives the city a value of 10 jobs - this is how the job limit is defined
        JobsCeiling = buildingCounts[3] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent, JobsCeiling);
    }

    void CalculateCash()
    {
        //each job gives the city $2
        Cash += JobsCurrent * 2;
    }

    void CalculateFood()
    {
        //each farm gives the player 4 extra food
        Food += buildingCounts[2] * 4f;
    }

    void CalculatePopulation()
    {
        //every house gives a possible 5 extra population
        PopulationCeiling = buildingCounts[0] * 5;
        //the below part calculates if the player gains population or not
        if(Food>=PopulationCurrent && PopulationCurrent< PopulationCeiling)
        {
            //feeding the current population
            Food -= PopulationCurrent*.25f;
            //what is left over, can go towards creating new population
            PopulationCurrent = Mathf.Min(PopulationCurrent+=Food*.25f, PopulationCeiling);

        }

        //deleting the population that "starved to death" - haha rip
        else if(Food<PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food) * 5f;
        }
    }
}
