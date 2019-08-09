using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEditor;
using UnityEngine;

public abstract class MyEditorWindow : EditorWindow
{
    protected CompositeDisposable LifeTimeDisposable { get; private set; }

    protected static EditorWindow OpenWindowCore([CallerFilePath] string fileName = "")
    {
        fileName = Path.GetFileNameWithoutExtension(fileName);
        var t = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == fileName);
        if (t != null)
        {
            var window = GetWindow(t);
            window.titleContent = new GUIContent(fileName);

            return window;
        }

        Debug.LogError($"Not found type of {fileName} window, please use OpenWindowCore<T>().");

        return null;
    }

    protected static T OpenWindowCore<T>() where T : EditorWindow
    {
        var window = GetWindow<T>();
        window.titleContent = new GUIContent(typeof(T).Name);

        return window;
    }

    protected abstract void Inizialize();

    protected virtual void OnEnable()
    {
        LifeTimeDisposable?.Dispose();
        LifeTimeDisposable = new CompositeDisposable();

        Inizialize();
    }

    protected virtual void OnDisable()
    {
        LifeTimeDisposable?.Dispose();
        LifeTimeDisposable = null;
    }
}
