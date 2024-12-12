using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public interface IFileReader
{
    IEnumerable<string> Read();
}

public class FileReader : IFileReader
{
    public readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

    public IEnumerable<string> Read(string path = "")
        => File.ReadAllText


    string[] input = File.ReadAllLines(FilePath.Combine(AppDomain.CurrentDomain.BaseDirectory, "PuzzleInput.dat"));

}
