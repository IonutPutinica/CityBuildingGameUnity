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

    public int[] buildingCounts = new int[3];

    void Start()
    {
        Cash = 10000;
        Food = 6;
        JobsCeiling = 10;
    }

    //at the end of each day, calculations are made, to define the new food supply, population, money and jobs
   public void EndTurn()
    {
        Day++;
        CalculateJobs();
        CalculateCash();
        Debug.Log("Day ended.");
    }

    void CalculateJobs()
    {
        //each factory gives the city a value of 10 jobs - this is how the job limit is defined
        JobsCeiling = buildingCounts[2] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent, JobsCeiling);
    }

    void CalculateCash()
    {
        //each job gives the city $2
        Cash += JobsCurrent * 2;
    }
}
