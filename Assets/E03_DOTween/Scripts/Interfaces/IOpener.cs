namespace E03_DOTween
{
    public interface IOpener
    {
        bool IsOpened { get; }
        bool IsClosed { get; }
        void Open();
        void Close();
    }
}