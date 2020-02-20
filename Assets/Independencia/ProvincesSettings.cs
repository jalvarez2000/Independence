using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[Serializable]
public class Statistics
{
    public String pib;
    public String support;
    public String xxx;
}

[Serializable]
public class InitColor
{
    public float r;
    public float g;
    public float b;
}

[Serializable]
public class ProvinceSettings
{
    public String province;
    public String city;
    public Statistics statistics;
    public InitColor initcolor;
}



[Serializable]
public class ProvincesSettings
{
    public ProvinceSettings []provinces;
}

public sealed class JSONProvinceSettings
{
    public static ProvincesSettings _instance;

    private JSONProvinceSettings()
    {
        
    }

    internal static ProvincesSettings getInstance()
    {
        if (_instance == null)
        {
            _instance = new ProvincesSettings();

            string path = "Assets/Independencia/ProvincesSettings.json";
            StreamReader reader = new StreamReader(path);
            String provinceReader = reader.ReadToEnd();
            reader.Close();
            _instance = JsonUtility.FromJson<ProvincesSettings>(provinceReader);
        }
        return _instance;
    }
}

