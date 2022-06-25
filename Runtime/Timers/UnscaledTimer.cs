namespace LiteNinja.Tweens
{
    public class UnscaledTimer : ITimer
    {
        public float Time => UnityEngine.Time.unscaledTime;
    }
}