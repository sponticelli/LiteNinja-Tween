namespace LiteNinja.Tweens
{
    public class UnityTimer : ITimer
    {
        public float Time => UnityEngine.Time.time;
    }
}