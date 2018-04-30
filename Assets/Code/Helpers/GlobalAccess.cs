using System.Linq;
using UnityEngine;

public static class GlobalAccess
{
    public static CityData GetCity()
    {
        return GameObject.Find("City").GetComponent<CityData>();
    }

    public static References GetReferences()
    {
        return GameObject.Find("References").GetComponent<References>();
    }

    public static Garage GetRandomGarage()
    {
        return GetCity().Buildings.PickOne().Garages.PickOne();
    }

}