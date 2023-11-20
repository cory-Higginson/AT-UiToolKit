using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.CompilerServices;


public class DebugMe : MonoBehaviour
{
    [SerializeField]public List<string> m_ConsoleLine = new List<string>(1000);
    [SerializeField]public string m_ConsoleFunction;

    private string[] cachedstuff;
    //adapted from:
    //https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=net-7.0&redirectedfrom=MSDN
    //https://semt20.home.blog/2020/01/03/c-get-current-code-line-number/

    public void runtimeCheck(string message = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string function = "")
    {
        if (cachedstuff == null)
        {
            cachedstuff = File.ReadAllLines("Assets/Scripts/Editor/Cache/" + GetType().Name + "_cache.cs");
        }



        m_ConsoleFunction = function + "();";
        if (m_ConsoleLine.Count >= 1000)
        {
            m_ConsoleLine.RemoveAt(0);

        }
        m_ConsoleLine.Add("Completed " + GetType().Name + "[" + line.ToString() + "]" + cachedstuff[line + 1]);
    }

}