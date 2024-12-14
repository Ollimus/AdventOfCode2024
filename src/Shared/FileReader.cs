using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public interface IFileReader
{
    IEnumerable<string> Read(string path = "", string fileName = "");
}

public class FileReader : IFileReader
{
    public string FilePath { get; init; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

    public IEnumerable<string> Read(string path = "", string fileName = "PuzzleInput.dat")
    {
        var filepath = string.IsNullOrEmpty(path) ? FilePath : path;
        return File.ReadLines(Path.Combine(filepath, "PuzzleInput.dat"));
    }
}
