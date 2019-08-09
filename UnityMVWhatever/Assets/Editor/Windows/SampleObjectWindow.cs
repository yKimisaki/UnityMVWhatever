using UnityEditor;
using UnityEngine.UIElements;
using UniRx;

public class SampleObjectWindow : MyEditorWindow
{
    [MenuItem("Window/UIElements/SampleObjectWindow")]
    public static void OpenWindow()
    {
        OpenWindowCore();
    }

    private SampleObjectModel model;

    protected override void Inizialize()
    {
        model = new SampleObjectModel();

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Windows/SampleObjectWindow.uxml");
        var labelFromUXML = visualTree.CloneTree();
        rootVisualElement.Add(labelFromUXML);

        var label = labelFromUXML.Q<Label>("label");
        var slider = labelFromUXML.Q<Slider>("slider");
        slider.OnValueChanged()
            .SubscribeToText(label)
            .AddTo(LifeTimeDisposable);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Windows/SampleObjectWindow.uss");
        label.styleSheets.Add(styleSheet);

        rootVisualElement.Add(slider);
    }
}