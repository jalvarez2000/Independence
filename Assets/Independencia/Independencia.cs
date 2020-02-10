using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldMapStrategyKit;

public class Independencia : MonoBehaviour
{
    // Start is called before the first frame update
    WMSK map;
    List<string> countries = new List<string>() { "France", "Portugal", "Algeria", "Morocco" };

    void Start()
    {
        map = WMSK.instance;    

        foreach (string country in countries)
        {
            int sourceCountryIndex = map.GetCountryIndex(country);

            if (sourceCountryIndex < 0)
            {
                Debug.Log("Countries not found " + country);
            }

            map.countries[sourceCountryIndex].showProvinces = false;
            map.countries[sourceCountryIndex].allowProvincesHighlight = false;
            map.countries[sourceCountryIndex].allowHighlight = false;
            map.Redraw(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
