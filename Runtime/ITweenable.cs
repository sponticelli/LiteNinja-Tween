namespace com.liteninja.tweens
{
    public interface ILerp<T>
    {
        T Lerp(T from, T to, float v);
    }
}