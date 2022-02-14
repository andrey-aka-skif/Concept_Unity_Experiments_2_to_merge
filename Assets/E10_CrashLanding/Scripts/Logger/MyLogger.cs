using System.IO;

namespace E10_CrashLanding
{
    public class MyLogger
    {
        //private const string FILE_PATH = "C:\\Users\\skif\\Desktop\\log.txt";
        private const string FILE_PATH = "log.txt";

        private readonly string _filePath;

        public MyLogger(string filePath = FILE_PATH)
        {
            _filePath = filePath;

            using StreamWriter w = File.AppendText(_filePath);
            w.WriteLine($"Speed\tPitch\tAltitude\tIsLanded");
        }

        public void Log(string str)
        {
            using StreamWriter w = File.AppendText(_filePath);
            w.WriteLine(str);
        }

        public void Log(float speed, float pitch, float altitude, bool isLanded)
        {
            using StreamWriter w = File.AppendText(_filePath);
            w.WriteLine($"{speed}\t{pitch}\t{altitude}\t{(isLanded ? 1 : 0)}");
        }
    }
}