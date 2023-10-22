using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

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