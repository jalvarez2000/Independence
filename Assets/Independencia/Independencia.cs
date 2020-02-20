using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldMapStrategyKit;

public class Independencia : MonoBehaviour
{
    // Start is called before the first frame update
    static WMSK map;
    List<string> peripheralCountries = new List<string>() { "Andorra","France", "Portugal", "Algeria", "Morocco" };
    string currentCountry = "Spain";
    Vector2 centerProvince;

    void Start()
    {
        map = WMSK.instance;

        // Adjacent countries are not selectable

        foreach (string country in peripheralCountries)
        {
            int sourcePeripheralCountryIndex = map.GetCountryIndex(country);

            if (sourcePeripheralCountryIndex < 0)
            {
                Debug.Log("Countries not found " + country);
            }

            map.countries[sourcePeripheralCountryIndex].allowProvincesHighlight = false;
            map.countries[sourcePeripheralCountryIndex].allowHighlight = false;

        }

        // We want only to show names if they are Spanish provinces
        map.OnCountryEnter += Map_OnCountryEnter;

        // We init the game info from JSON file
        ProvincesSettings provincesSettings = JSONProvinceSettings.getInstance();
        Action<ProvinceSettings> action = new Action<ProvinceSettings>(initProvince);
        Array.ForEach<ProvinceSettings>(provincesSettings.provinces, action);

        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Las Palmas"), true, new Color(231f/255f, 182f/255f, 207f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Murcia"), true, new Color(97f/255f, 85f/255f, 80f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "País Vasco"), true, new Color(215f/255f, 196f/255f, 157f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Valencia"), true, new Color(164f/255f, 231f/255f,223f/255f));
    }

    private static void initProvince(ProvinceSettings provSettings)
    {
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", provSettings.province), true, new Color(provSettings.initcolor.r / 255f, provSettings.initcolor.g / 255f, provSettings.initcolor.b / 255f), null, true);
        Vector2 barLocation = map.GetCity(provSettings.city, "Spain").unity2DLocation;
        GameObject provinceBars = (GameObject)Instantiate(Resources.Load("Bar3DSimple"));
        map.AddMarker3DObject(provinceBars, barLocation, 0.5f);
        provinceBars.transform.eulerAngles = new Vector3(0, 0, 0);
        provinceBars.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.001f);
        provinceBars.transform.position = new Vector3(provinceBars.transform.position.x, provinceBars.transform.position.y-0.1f, -3);
    }


    private void Map_OnCountryEnter(int countryIndex, int regionIndex)
    {
        if (countryIndex == map.GetCountryIndex("Spain"))
        {
            map.showProvinceNames = true;
        }
        else map.showProvinceNames = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
    }

}
