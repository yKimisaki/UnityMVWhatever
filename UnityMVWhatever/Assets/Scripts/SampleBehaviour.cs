using UniRx;
using UnityEngine;

public enum SampleObjectType
{
    Numeric,
    Alphanumeric,
    String,
}

public class SampleBehaviour : MonoBehaviour
{
    public SampleObjectType SampleObjectType;
    public BindableProperty<int> NumericValue;
}
