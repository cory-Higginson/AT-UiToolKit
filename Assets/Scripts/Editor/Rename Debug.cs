using System.IO;

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
public class EnableDebug : Editor
{

    private bool enable = false;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement myInspector = new VisualElement();
        //myInspector.schedule.Execute(_ => CreateInspectorGUI()).Every(1000);
        var path = AssetDatabase.GetAssetPath(serializedObject.FindProperty("m_Script").objectReferenceValue);
        //UnityEngine.Debug.Log(path);
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("DebugMe"))
            {
                enable = true;
                break;
            }
        }

        // Create a new VisualElement to be the root of our inspector UI
        if (enable)
        {
            // Create a new VisualElement to be the root of our inspector UI

            //myInspector.schedule.Execute(_ => CreateInspectorGUI()).Every(1000);

            // Help Box
            //
            //
            myInspector.Add(new HelpBox("DEBUG ACTIVE ", HelpBoxMessageType.Warning));
            //myInspector.Add(new HelpBox("Console output:",HelpBoxMessageType.Info));

            // Button
            //
            //
            Button debugEnable = new Button();
            debugEnable.text = "Click To Disable InspectorDebug";

            debugEnable.RegisterCallback<ClickEvent>(evt =>
            {
                //UnityEngine.Debug.Log(serializedObject.FindProperty("m_Script").objectReferenceValue.name);
                //string filter = "t:Object l:" + serializedObject.FindProperty("m_Script").objectReferenceValue.name;

                //var stuff = AssetDatabase.FindAssets(filter);
                var path = AssetDatabase.GetAssetPath(serializedObject.FindProperty("m_Script").objectReferenceValue);
                UnityEngine.Debug.Log(path);
                string[] lines = File.ReadAllLines(path);
                string oldword = "DebugMe";
                string newword = "MonoBehaviour";

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(newword))
                    {
                        break;
                    }

                    if (lines[i].Contains(oldword))
                    {
                        lines[i] = lines[i].Replace(oldword, newword);
                    }

                    if (lines[i].Contains("; runtimeCheck();"))
                    {
                        lines[i] = lines[i].Replace("; runtimeCheck();", ";");
                    }
                }

                File.WriteAllLines(path, lines);
                //https://docs.unity3d.com/ScriptReference/Compilation.CompilationPipeline.RequestScriptCompilation.html#:~:text=After%20the%20compilation%2C%20if%20the,changes%2C%20you%20can%20pass%20RequestScriptCompilationOptions.
                //UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
                //CreateInspectorGUI();
                enable = false;
                UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
                //CreateInspectorGUI();
            });
            myInspector.Add(debugEnable);



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




            //myInspector.Add(new Node());
            var scipt_propertys = new VisualElement();
            scipt_propertys.name = "propertys";
            InspectorElement.FillDefaultInspector(scipt_propertys, serializedObject, this);
            scipt_propertys.Remove(scipt_propertys[0]);
            scipt_propertys.Remove(scipt_propertys[0]);
            if (scipt_propertys.Query<PropertyField>().First() != null)
            {
                scipt_propertys.Query<PropertyField>().First().visible = false;
            }

            myInspector.Add(scipt_propertys);
            // Return the finished inspector UI
            //UnityEngine.Debug.Log(myInspector[4].name);
            //myInspector.Query<PropertyField>().First().visible = false;

            //UnityEngine.Debug.Log(myInspector.Query<TextField>().Last().name);
            return myInspector;
        }
        else
        {
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
                    if (lines[i].Contains(newword))
                    {
                        break;
                    }

                    if (lines[i].Contains(oldword))
                    {
                        lines[i] = lines[i].Replace(oldword, newword);
                    }

                    if (lines[i].Contains(';'))
                    {
                        if (!lines[i].Contains("using") &&
                            !lines[i].Contains("public") &&
                            !lines[i].Contains("private"))
                        {
                            lines[i] = lines[i].Replace(";", "; runtimeCheck();");
                        }
                    }
                }

                File.WriteAllLines(path, lines);
                //https://docs.unity3d.com/ScriptReference/Compilation.CompilationPipeline.RequestScriptCompilation.html#:~:text=After%20the%20compilation%2C%20if%20the,changes%2C%20you%20can%20pass%20RequestScriptCompilationOptions.
                //UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
                enable = true;
                UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
                //CreateInspectorGUI();
                //RequestScriptCompilation();

            });
            myInspector.Add(debugEnable);

            var scipt_propertys = new VisualElement();
            scipt_propertys.name = "propertys";
            InspectorElement.FillDefaultInspector(scipt_propertys, serializedObject, this);
            scipt_propertys[0].visible = false;

            myInspector.Add(scipt_propertys);
            //InspectorElement.FillDefaultInspector(myInspector, serializedObject, this);
            // Return the finished inspector UI
            //myInspector[1].visible = false;
            //UnityEngine.Debug.Log(myInspector.contentContainer.contentContainer.visible = false);

            return myInspector;
        }
    }
}