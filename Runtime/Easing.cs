using UnityEngine;

namespace LiteNinja.Tweens
{
    public static class Easing
    {
        public static float QaudIn(float t)
        {
            return QuadIn(t, 1, 0, 1);
        }

        public static float QuadIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return max * t * t + min;
        }

        public static float QuadOut(float t) => QuadOut(t, 1, 0, 1);

        public static float QuadOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return -max * t * (t - 2) + min;
        }


        public static float QuadInOut(float t) => QuadInOut(t, 1, 0, 1);

        public static float QuadInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;
            if (t < 1) return max / 2 * t * t + min;

            t -= 1;
            return -max / 2 * (t * (t - 2) - 1) + min;
        }

        public static float CubicIn(float t) => CubicIn(t, 1, 0, 1);

        public static float CubicIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return max * t * t * t + min;
        }

        public static float CubicOut(float t) => CubicOut(t, 1, 0, 1);

        public static float CubicOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t = t / duration - 1;
            return max * (t * t * t + 1) + min;
        }

        public static float CubicInOut(float t) => CubicInOut(t, 1);

        public static float CubicInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;
            if (t < 1) return max / 2 * t * t * t + min;

            t -= 2;
            return max / 2 * (t * t * t + 2) + min;
        }

        public static float QuartIn(float t) => QuartIn(t, 1);

        public static float QuartIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return max * t * t * t * t + min;
        }

        public static float QuartOut(float t) => QuartOut(t, 1);

        public static float QuartOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t = t / duration - 1;
            return -max * (t * t * t * t - 1) + min;
        }

        public static float QuartInOut(float t) => QuartInOut(t, 1);

        public static float QuartInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;
            if (t < 1) return max / 2 * t * t * t * t + min;

            t -= 2;
            return -max / 2 * (t * t * t * t - 2) + min;
        }

        public static float QuintIn(float t) => QuintIn(t, 1);

        public static float QuintIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return max * t * t * t * t * t + min;
        }

        public static float QuintOut(float t) => QuintOut(t, 1);

        public static float QuintOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t = t / duration - 1;
            return max * (t * t * t * t * t + 1) + min;
        }

        public static float QuintInOut(float t) => QuintInOut(t, 1);

        public static float QuintInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;
            if (t < 1) return max / 2 * t * t * t * t * t + min;

            t -= 2;
            return max / 2 * (t * t * t * t * t + 2) + min;
        }

        public static float SineIn(float t) => SineIn(t, 1);

        public static float SineIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return -max * Mathf.Cos(t * (Mathf.PI * 90 / 180) / duration) + max + min;
        }

        public static float SineOut(float t) => SineOut(t, 1);

        public static float SineOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return max * Mathf.Sin(t * (Mathf.PI * 90 / 180) / duration) + min;
        }

        public static float SineInOut(float t) => SineInOut(t, 1);

        public static float SineInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return -max / 2 * (Mathf.Cos(t * Mathf.PI / duration) - 1) + min;
        }

        public static float ExpIn(float t) => ExpIn(t, 1);

        public static float ExpIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return t == 0.0 ? min : max * Mathf.Pow(2, 10 * (t / duration - 1)) + min;
        }

        public static float ExpOut(float t) => ExpOut(t, 1);

        public static float ExpOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return t == duration ? max + min : max * (-Mathf.Pow(2, -10 * t / duration) + 1) + min;
        }

        public static float ExpInOut(float t) => ExpInOut(t, 1);

        public static float ExpInOut(float t, float duration, float min = 0, float max = 1)
        {
            if (t == 0.0f) return min;
            if (t == duration) return max;
            max -= min;
            t /= duration / 2;

            if (t < 1) return max / 2 * Mathf.Pow(2, 10 * (t - 1)) + min;

            t -= 1;
            return max / 2 * (-Mathf.Pow(2, -10 * t) + 2) + min;
        }

        public static float CircIn(float t) => CircIn(t, 1);

        public static float CircIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;
            return -max * (Mathf.Sqrt(1 - t * t) - 1) + min;
        }

        public static float CircOut(float t) => CircOut(t, 1);

        public static float CircOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t = t / duration - 1;
            return max * Mathf.Sqrt(1 - t * t) + min;
        }

        public static float CircInOut(float t) => CircInOut(t, 1);

        public static float CircInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;
            if (t < 1) return -max / 2 * (Mathf.Sqrt(1 - t * t) - 1) + min;

            t -= 2;
            return max / 2 * (Mathf.Sqrt(1 - t * t) + 1) + min;
        }

        public static float ElasticIn(float t) => ElasticIn(t, 1);

        public static float ElasticIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;

            var s = 1.70158f;
            var p = duration * 0.3f;
            var a = max;

            switch (t)
            {
                case 0:
                    return min;
                case 1:
                    return min + max;
            }

            if (a < Mathf.Abs(max))
            {
                a = max;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(max / a);
            }

            t -= 1;
            return -(a * Mathf.Pow(2, 10 * t) * Mathf.Sin((t * duration - s) * (2 * Mathf.PI) / p)) + min;
        }

        public static float ElasticOut(float t) => ElasticOut(t, 1);

        public static float ElasticOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;

            var s = 1.70158f;
            var p = duration * 0.3f;
            ;
            var a = max;

            switch (t)
            {
                case 0:
                    return min;
                case 1:
                    return min + max;
            }

            if (a < Mathf.Abs(max))
            {
                a = max;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(max / a);
            }

            return a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * duration - s) * (2 * Mathf.PI) / p) + max + min;
        }

        public static float ElasticInOut(float t) => ElasticInOut(t, 1);

        public static float ElasticInOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration / 2;

            var s = 1.70158f;
            var p = duration * (0.3f * 1.5f);
            var a = max;

            switch (t)
            {
                case 0:
                    return min;
                case 2:
                    return min + max;
            }

            if (a < Mathf.Abs(max))
            {
                a = max;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(max / a);
            }

            if (t < 1)
            {
                return -0.5f * (a * Mathf.Pow(2, 10 * (t -= 1)) * Mathf.Sin((t * duration - s) * (2 * Mathf.PI) / p)) +
                       min;
            }

            t -= 1;
            return a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * duration - s) * (2 * Mathf.PI) / p) * 0.5f + max + min;
        }

        public static float BackIn(float t) => BackIn(t, 1);

        public static float BackIn(float t, float duration, float min = 0, float max = 1, float s = 0.5f)
        {
            max -= min;
            t /= duration;
            return max * t * t * ((s + 1) * t - s) + min;
        }

        public static float BackOut(float t) => BackOut(t, 1);

        public static float BackOut(float t, float duration, float min = 0, float max = 1, float s = 0.5f)
        {
            max -= min;
            t = t / duration - 1;
            return max * (t * t * ((s + 1) * t + s) + 1) + min;
        }

        public static float BackInOut(float t) => BackInOut(t, 1);

        public static float BackInOut(float t, float duration, float min = 0, float max = 1, float s = 0.5f)
        {
            max -= min;
            s *= 1.525f;
            t /= duration / 2;
            if (t < 1) return max / 2 * (t * t * ((s + 1) * t - s)) + min;

            t -= 2;
            return max / 2 * (t * t * ((s + 1) * t + s) + 2) + min;
        }

        public static float BounceIn(float t) => BounceIn(t, 1);

        public static float BounceIn(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            return max - BounceOut(duration - t, duration, 0, max) + min;
        }

        public static float BounceOut(float t) => BounceOut(t, 1);

        public static float BounceOut(float t, float duration, float min = 0, float max = 1)
        {
            max -= min;
            t /= duration;

            switch (t)
            {
                case < 1.0f / 2.75f:
                    return max * (7.5625f * t * t) + min;
                case < 2.0f / 2.75f:
                    t -= 1.5f / 2.75f;
                    return max * (7.5625f * t * t + 0.75f) + min;
                case < 2.5f / 2.75f:
                    t -= 2.25f / 2.75f;
                    return max * (7.5625f * t * t + 0.9375f) + min;
                default:
                    t -= 2.625f / 2.75f;
                    return max * (7.5625f * t * t + 0.984375f) + min;
            }
        }

        public static float BounceInOut(float t) => BounceInOut(t, 1);

        public static float BounceInOut(float t, float duration, float min = 0, float max = 1)
        {
            if (t < duration / 2)
            {
                return BounceIn(t * 2, duration, 0, max - min) * 0.5f + min;
            }
            else
            {
                return BounceOut(t * 2 - duration, duration, 0, max - min) * 0.5f + min + (max - min) * 0.5f;
            }
        }

        public static float Linear(float t) => Linear(t, 1);

        public static float Linear(float t, float duration, float min = 0, float max = 1)
        {
            return (max - min) * t / duration + min;
        }
    }
}