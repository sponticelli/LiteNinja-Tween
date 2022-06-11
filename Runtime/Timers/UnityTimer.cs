namespace com.liteninja.tweens
{
    public class UnityTimer : ITimer
    {
        public float Time => UnityEngine.Time.time;
    }
}