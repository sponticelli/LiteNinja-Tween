namespace com.liteninja.tweens
{
    public class UnscaledTimer : ITimer
    {
        public float Time => UnityEngine.Time.unscaledTime;
    }
}