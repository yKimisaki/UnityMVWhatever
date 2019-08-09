using System;
using UnityEngine.UIElements;

namespace UniRx
{
    public static class UIElementsRxExtensions
    {
        public static IObservable<ChangeEvent<T>> OnValueChange<T>(this INotifyValueChanged<T> source)
        {
            return Observable.FromEvent<EventCallback<ChangeEvent<T>>, ChangeEvent<T>>(
                h => new EventCallback<ChangeEvent<T>>(h),
                h => source.RegisterValueChangedCallback(h),
                h => source.UnregisterValueChangedCallback(h));
        }

        public static IObservable<T> OnValueChanged<T>(this INotifyValueChanged<T> source)
        {
            return source.OnValueChange().Select(x => x.newValue);
        }

        public static IDisposable SubscribeToText(this IObservable<string> source, TextElement text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x);
        }

        public static IDisposable SubscribeToText<T>(this IObservable<T> source, TextElement text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x.ToString());
        }
    }
}
