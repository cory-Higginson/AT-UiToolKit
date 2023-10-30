using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class move : DebugMe
{
    private IEnumerator corutine;
    //Start is called before the first frame update
    public Transform trans;
    void Start()
    {
        corutine = Moveing(); runtimeCheck();  
        StartCoroutine(corutine); runtimeCheck();  
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Moveing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.left); runtimeCheck();

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.left); runtimeCheck();  

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.up); runtimeCheck();  

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.up); runtimeCheck();  

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.right); runtimeCheck();  
            yield return new WaitForSeconds(1); runtimeCheck(); 
            trans.Translate(Vector3.right); runtimeCheck();  

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.down); runtimeCheck();  

            yield return new WaitForSeconds(1); runtimeCheck();  
            trans.Translate(Vector3.down); runtimeCheck();  

            yield return new WaitForSeconds(3); runtimeCheck();  

        }

    }
}
