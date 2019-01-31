using System;
using System.IO;
using System.Text;
using SysFileReplacer.Files;

namespace SysFileReplacerTests
{
    class TestSysFile : SysFileBase
    {
        private readonly string _fileDirectory = string.Concat(Path.GetPathRoot(Environment.SystemDirectory), "\\SysFileReplacerTestDirectory\\");

        public TestSysFile()
        {
            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }

            using (FileStream fs = File.Create(GetFullFilePath()))
            {
                var info = new UTF8Encoding(true).GetBytes("Some test text in the file.");
                fs.Write(info, 0, info.Length);
            }
        }

        public override string GetFileName()
        {
            return "SysFileReplacerTestFile.txt";
        }

        public sealed override string GetFullFilePath()
        {
            return string.Concat(_fileDirectory, GetFileName());
        }

        public void Remove()
        {
            File.Delete(GetFullFilePath());
            Directory.Delete(_fileDirectory);
        }
    }
}
