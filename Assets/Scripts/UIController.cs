using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //in order to have the elements serializable, and exposed/usable by the inspector, we add the below element (because the elements are private and not public)
    [SerializeField]
    private Text dayText;
    [SerializeField]
    private Text cityText;
    private City city;
    // Start is called before the first frame update
    void Start()
    {
        city = GetComponent<City>();
        
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format
          ("Jobs: {0}/{1}\nCash: ${2} (+${6})\nPopulation: {3}/{4}\nFood: {5}",
          city.JobsCurrent, city.JobsCeiling,
          city.Cash, (int)city.PopulationCurrent, 
          (int)city.PopulationCeiling, (int)city.Food, city.JobsCurrent * 2);
       
    }

    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day {0}", city.Day);
    }
}
