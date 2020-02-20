using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldMapStrategyKit;

public class Independencia : MonoBehaviour
{
    // Start is called before the first frame update
    WMSK map;
    List<string> peripheralCountries = new List<string>() { "Andorra","France", "Portugal", "Algeria", "Morocco" };
    string currentCountry = "Spain";
    Vector2 centerProvince;
    GameObject provinceBars;

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

        int sourceCurrentCountryIndex = map.GetCountryIndex(currentCountry);

        for (int sourceProvinceIndex = 0; sourceProvinceIndex < 5; sourceProvinceIndex++)
        {
            centerProvince = map.countries[sourceCurrentCountryIndex].provinces[sourceProvinceIndex].centerRect;
        }


        // We want only to show names if they are Spanish provinces
        map.OnCountryEnter += Map_OnCountryEnter;

        Vector2 madridLocation = map.GetCity("Ourense", "Spain").unity2DLocation;
        provinceBars = GameObject.Find("Bar3DSimple");
        map.AddMarker3DObject(provinceBars, madridLocation, 0.5f);
        adjustBarPosition();

        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain","Andalucía"), true, new Color(221f/255f,77f/255f,67f/255f),null,true);
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Aragón"), true, new Color(157f/255f, 132f/255f, 42f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Asturias"), true, new Color(254f/255f,132f/255f, 42f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Baleares"), true, new Color(252f/255f, 118f/255f, 106f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Cantabria"), true, new Color(200f/255f, 62f/255f, 115f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Castilla La Mancha"), true, new Color(141f/255f, 148f/255f, 64f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Castilla y León"), true, new Color(253f/255f, 214f/255f, 94f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Cataluña"), true, new Color(45f/255f, 92f/255f, 158f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Extremadura"), true, new Color(117f/255f, 92f/255f, 158f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Galicia"), true, new Color(217f/255f, 159f/255f , 60f/255f ));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "La Rioja"), true, new Color(97f/255f, 98f/255f, 71f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Las Palmas"), true, new Color(231f/255f, 182f/255f, 207f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Madrid"), true, new Color(59f/255f, 58f/255f, 80f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Murcia"), true, new Color(97f/255f, 85f/255f, 80f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Navarra"), true, new Color(242f/255f, 237f/255f, 215f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "País Vasco"), true, new Color(215f/255f, 196f/255f, 157f/255f));
        map.ToggleProvinceSurface(map.GetProvinceIndex("Spain", "Valencia"), true, new Color(164f/255f, 231f/255f,223f/255f));

        ProvincesSettings provincesSettings = JSONProvinceSettings.getInstance();

    }

    void adjustBarPosition()
    {
        provinceBars = GameObject.Find("Bar3DSimple");
        provinceBars.transform.eulerAngles = new Vector3(0, 0, 0);
        provinceBars.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.001f);
        provinceBars.transform.position = new Vector3(provinceBars.transform.position.x, provinceBars.transform.position.y, -3);
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
