namespace LiteNinja.Tweens
{
    public class FixedTimer : ITimer
    {
        public float Time => UnityEngine.Time.fixedTime;
    }
}