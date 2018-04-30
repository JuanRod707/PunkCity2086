using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class DebugConsole
{
    public static void LogMessage(string message)
    {
        GameObject.Find("Console").GetComponent<Text>().text = message;
    }
}

