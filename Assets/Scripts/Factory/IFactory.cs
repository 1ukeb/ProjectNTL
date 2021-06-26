namespace NTL.Factory
{ /// <summary>
  /// Represents a factory.
  /// </summary>
  /// <typeparam name="T">Type to create</typeparam>
    public interface IFactory<T>
    {
        T Create();
    }
}