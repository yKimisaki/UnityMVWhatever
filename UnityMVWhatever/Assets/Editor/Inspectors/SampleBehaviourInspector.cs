using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(SampleBehaviour))]
public class SampleBehaviourInspector : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        var asset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Inspectors/SampleBehaviourInspector.uxml");
        var tree = asset.CloneTree();
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Inspectors/SampleBehaviourInspector.uss");
        tree.styleSheets.Add(styleSheet);
        return tree;
    }
}
