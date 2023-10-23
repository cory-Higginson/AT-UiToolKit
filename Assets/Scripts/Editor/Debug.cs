using System.IO;

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour),true)]
public class EnableDebug : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        Button debugEnable = new Button();
        debugEnable.text = "Click To Enable InspectorDebug";

        debugEnable.RegisterCallback<ClickEvent>(evt =>
        {
            UnityEngine.Debug.Log(serializedObject.FindProperty("m_Script").objectReferenceValue.name);
            
            
            //string filter = "t:Object l:" + serializedObject.FindProperty("m_Script").objectReferenceValue.name;

            //var stuff = AssetDatabase.FindAssets(filter);
            var path = AssetDatabase.GetAssetPath(serializedObject.FindProperty("m_Script").objectReferenceValue);
            UnityEngine.Debug.Log(path);
            string[] lines = File.ReadAllLines(path);
            string oldword = "MonoBehaviour";
            string newword = "DebugMe";

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(oldword))
                {
                    lines[i] = lines[i].Replace(oldword, newword);
                }
            }
            File.WriteAllLines(path, lines);
            //https://docs.unity3d.com/ScriptReference/Compilation.CompilationPipeline.RequestScriptCompilation.html#:~:text=After%20the%20compilation%2C%20if%20the,changes%2C%20you%20can%20pass%20RequestScriptCompilationOptions.
            //UnityEditor.Compilation.R;
            //RequestScriptCompilation();


        });
        myInspector.Add(debugEnable);
        InspectorElement.FillDefaultInspector(myInspector, serializedObject, this);
        // Return the finished inspector UI
        //myInspector[1].visible = false;


        //UnityEngine.Debug.Log(myInspector.contentContainer.contentContainer.visible = false);

        return myInspector;
    }
}

[CustomEditor(typeof(DebugMe),true)]
public class Debug : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();


		myInspector.Add(new HelpBox("DEBUG ACTIVE ",HelpBoxMessageType.Warning));
		//myInspector.Add(new HelpBox("Console output:",HelpBoxMessageType.Info));

        var functioncode = new TextField("code ran from:");
        functioncode.value = "function();";
        //runningcode.SetEnabled(false);
        functioncode.bindingPath = "m_ConsoleFunction";
        functioncode.isReadOnly = true;
        myInspector.Add(functioncode);

        var runningcode = new TextField("ConsoleLine:");
        runningcode.value = "[Line] print(\"hello World\")";
        //runningcode.SetEnabled(false);
        runningcode.bindingPath = "m_ConsoleLine";
        runningcode.multiline = true;
        runningcode.isReadOnly = true;
        myInspector.Add(runningcode);




        InspectorElement.FillDefaultInspector(myInspector, serializedObject, this);
        // Return the finished inspector UI
        myInspector.Remove(myInspector[5]);
        myInspector.Remove(myInspector[4]);
        myInspector.Remove(myInspector[3]);
        return myInspector;
    }
}