using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class move : MonoBehaviour
{
    private IEnumerator corutine;
    //Start is called before the first frame update
    public Transform trans;
    void Start()
    {
        corutine = Moveing();  
        StartCoroutine(corutine);  
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Moveing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.left);  


            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.left);  

            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.up);  

            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.up);  

            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.right);  
            yield return new WaitForSeconds(1); 
            trans.Translate(Vector3.right);  

            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.down);  

            yield return new WaitForSeconds(1);  
            trans.Translate(Vector3.down);  

            yield return new WaitForSeconds(3);  

        }

    }
}
