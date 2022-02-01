namespace E03_DOTween
{
    public interface IOpenable
    {
        bool IsOpened { get; }
        bool IsClosed { get; }
        void Open();
        void Close();
    }
}