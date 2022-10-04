using System;
using UnityEngine;

namespace Assets.Source.Model.Utils
{
    public static class Extensions
    {
        public static T With<T>(this T instance, Action action) where T : notnull
        {
            action?.Invoke();

            return instance;
        }

        public static T With<T>(this T instance, Func<T, T> action) where T : notnull => 
            action.Invoke(instance);

        public static bool IsNull<T>(this T instance) where T : class =>
            instance == null;
    }

    public class ExtendedVector2
    {
        public static Vector2 RepeatInBox(Vector2 point, Vector2 leftTop, Vector2 rightDown)
        {
            float repeatedX = ExtendedMathf.Repeat(point.x, leftTop.x, rightDown.x);
            float repeatedY = ExtendedMathf.Repeat(point.y, rightDown.y, leftTop.y);

            return new Vector2(repeatedX, repeatedY);
        }
    }

    public static class ExtendedMathf
    {
        public static float Repeat(float t, float from, float to)
        {
            if (t < from || t > to)
                return Mathf.Sign(t) * (t - to + from);

            return t;
        }

        public static float Except(float t, float from, float to)
        {
            if (t < from || t > to)
                return t;

            float v1 = from - t;
            float v2 = to - t;

            if (Mathf.Abs(v1) > Mathf.Abs(v2))
                return t + v2;

            return t + v1;
        }
    }
}