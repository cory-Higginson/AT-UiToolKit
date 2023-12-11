using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR

public class RuntimeVisualUi : MonoBehaviour
{

    [SerializeField] private UIDocument ui;

    [SerializeField] private List<DebugMe> scripts;
    private Vector3 old;
    private Vector3 _new;
    private Vector3 change;

    Func<VisualElement> makeItem = () => new Label();
    private Camera cam;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _new = transform.position;
        cam = Camera.main;
        TryGetComponent<UIDocument>(out ui);

        foreach (var sComponent in this.GetComponents<DebugMe>())
        {
            scripts.Add(sComponent);
        }


        if (scripts.Count <= 0)
        {
            Debug.Log("NOScripts");
        }
        ui.rootVisualElement.Add(new GroupBox());
        foreach (DebugMe script in scripts)
        {
            var gbox = new GroupBox();
            var method = new TextField("code ran from: " + script.ToString());
            method.value = "function();";
            method.isReadOnly = true;

            var lines = new ListView();
            lines.selectionType = SelectionType.None;
            lines.makeItem = makeItem;
            lines.bindingPath = script.m_ConsoleLine.ToString();
            lines.showBorder = true;
            lines.showBoundCollectionSize = false;
            lines.horizontalScrollingEnabled = true;
            lines.style.maxHeight = lines.fixedItemHeight * 5;
            lines.showAlternatingRowBackgrounds = AlternatingRowBackground.All;

            gbox.Add(method);
            gbox.Add(lines);
            ui.rootVisualElement[0].Add(gbox);
        }

        var box = ui.rootVisualElement[0] as GroupBox;
        box.style.flexDirection = FlexDirection.Row;
        box.style.width = 300;
        box.style.height = 500;
        box.style.position = Position.Absolute;
        ui.rootVisualElement.visible = false;
    }

    void Start()
    {



    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ui.rootVisualElement.visible = !ui.rootVisualElement.visible;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.rootVisualElement.visible)
        {
            for (int i = 0; i < scripts.Count; i++)
            {
                var txmt = ui.rootVisualElement[0][i][0] as TextField;
                txmt.value = scripts[i].m_ConsoleFunction;
                //var lin = ui.rootVisualElement[i][1] as ListView;
                //lin.bindItem = scripts[i].m_ConsoleLine;
            }
//
        //    var b = ui.rootVisualElement[0] as GroupBox;
        //    b.style.translate = new Translate((cam.WorldToScreenPoint(change).x), (cam.WorldToScreenPoint(change).y));
        }
//
        //if (transform.hasChanged)
        //{
        //    old = _new;
        //    _new = transform.position;
        //    transform.hasChanged = false;
        //    change = old - _new;
        //}
    }
}

#endif