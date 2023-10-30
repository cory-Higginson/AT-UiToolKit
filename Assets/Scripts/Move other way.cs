using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveotherway : DebugMe
{
        private IEnumerator corutine;
        //Start is called before the first frame update
        [SerializeField] private Mesh m1;
        [SerializeField] private Mesh m2;
        [SerializeField] private Mesh m3;
        [SerializeField] private Mesh m4;
        void Start()
        {
            corutine = changeing(); runtimeCheck();
            StartCoroutine(corutine); runtimeCheck();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator changeing()
        {
            while (true)
            {
                gameObject.GetComponent<MeshFilter>().mesh = m1; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m2; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m3; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m4; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m1; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m2; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m3; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m4; runtimeCheck();
                yield return new WaitForSeconds(1); runtimeCheck();
                gameObject.GetComponent<MeshFilter>().mesh = m1; runtimeCheck();
                yield return new WaitForSeconds(3); runtimeCheck();
            }
        }
    }
