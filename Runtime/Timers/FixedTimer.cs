namespace com.liteninja.tweens
{
    public class FixedTimer : ITimer
    {
        public float Time => UnityEngine.Time.fixedTime;
    }
}