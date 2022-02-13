namespace E09_TestTask
{
    internal interface IPoolable
    {
        Settings Settings { get; set; }
        void Activate();
        void Deactivate();
    }
}