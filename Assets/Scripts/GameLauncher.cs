using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameLauncher : MonoBehaviour
{

    // Update is called once per frame
    public void startWii(string romPath)
    {
        string path = Application.dataPath + "/../Games/Dolphin-x64/Dolphin.exe"; //+" " + Application.dataPath + "/../Games/roms/" + romPath;
        UnityEngine.Debug.Log(path +" "+ Application.dataPath + "/../Games/roms/" + romPath);
        romPath = "\"" + romPath + "\"";
        Process.Start(path, "\"" + Application.dataPath + "/../Games/roms/" + romPath + "\"");
        Application.Quit(0);
    }

    public void startN64(string romPath)
    {
        string path = Application.dataPath + "/../Games/Project64/Project64.exe";
        UnityEngine.Debug.Log(path + " " + Application.dataPath + "/../Games/roms/" + romPath);
        romPath = "\"" + romPath + "\"";
        Process.Start(path, "\"" + Application.dataPath + "/../Games/roms/" + romPath + "\"");
        Application.Quit(0);
    }
}
