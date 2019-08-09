using UnityEngine;
using UnityEngine.UIElements;

public class BindableProperty<T> : IBinding
{
    public void PreUpdate()
    {
    }

    public void Release()
    {
    }

    public void Update()
    {
        Debug.Log("Nyanpasu");
    }
}
