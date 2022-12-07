namespace Advent2022.Tests.Unit.Days;

public class Day7Tests
{
    [Fact]
    public void GetFolderSizeTest()
    {
        List<string> input = new()
        {
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d"
        };

        // Act
        int result = Day7.GetFolderSize(input);

        // Assert
        result.Should().Be(23_352_670);
    }

    [Fact]
    public void ProcesLinesTest()
    {
        string[] lines = new string[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
        };

        int result = Day7.ProcessLines(lines.Skip(1).ToList(), out _).Sum();

        result.Should().Be(48381165);
    }
}
