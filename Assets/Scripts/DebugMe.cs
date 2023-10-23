using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class DebugMe : MonoBehaviour
{
    [SerializeField]private String m_ConsoleLine;
    [SerializeField]private String m_ConsoleFunction;

    //adapted from:
    //https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=net-7.0&redirectedfrom=MSDN
    //https://semt20.home.blog/2020/01/03/c-get-current-code-line-number/
    public void runtimeCheck(string message = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string function = "")
    {
        m_ConsoleFunction = function + "();";
        m_ConsoleLine += "Completed [" + line.ToString() + "] \n";
    }

}