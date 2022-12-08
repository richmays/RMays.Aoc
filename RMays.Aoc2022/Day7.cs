using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day7 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var dirStack = new Stack<Directory>();

            //var currDirName = "root";
            //var currDir = new Directory(currDirName);
            var root = new Directory("root");
            var processingLS = false;
            dirStack.Push(root);
            foreach(var line in lines)
            {
                switch (line[0])
                {
                    case '$':
                        // Command; process!
                        if (processingLS)
                        {
                            // Don't need this; we add it as we get it.
                            /*
                            var currDir = dirStack.Peek();
                            if (!currDir.ContentsKnown)
                            {
                                foreach (var dir in currDir.Subdirectories)
                                {
                                    currDir.Subdirectories.Add(dir);
                                }
                                foreach (var file in currDir.Files)
                                {
                                    currDir.Files.Add(file);
                                }
                                currDir.ContentsKnown = true;
                            }
                            */

                            // Add the built-up directory to the structure.
                            processingLS = false;
                        }
                        switch (line.Split(' ')[1])
                        {
                            case "cd":
                                switch (line.Split(' ')[2])
                                {
                                    case "..":
                                        dirStack.Pop();
                                        break;
                                    case "/":
                                        while(dirStack.Peek().Name != "root")
                                        {
                                            dirStack.Pop();
                                        }
                                        break;
                                    default:
                                        var subdirName = line.Split(' ')[2];
                                        var subdir = dirStack.Peek().Subdirectories.First(x => x.Name == subdirName);
                                        dirStack.Push(subdir);
                                        break;
                                }
                                break;
                            case "ls":
                                // We can ignore this; everything that Doesn't start with '$' is the result of an 'ls' command.
                                break;
                        }
                        break;
                    case 'd':
                        processingLS = true;
                        var currDir_Dir = dirStack.Peek();
                        var dirName = line.Split(' ')[1];
                        if (currDir_Dir.Subdirectories.Any(x => x.Name == dirName))
                        {
                            Console.WriteLine($"'ls' command was executed already; won't add this directory: {dirName}");
                        }
                        else
                        {
                            currDir_Dir.Subdirectories.Add(new Directory(dirName));
                        }
                        break;
                    default:
                        processingLS = true;
                        var currDir_File = dirStack.Peek();
                        var fileSize = long.Parse(line.Split(' ')[0]);
                        var fileName = line.Split(' ')[1];
                        if (currDir_File.Files.Any(x => x.Name == fileName))
                        {
                            Console.WriteLine($"'ls' command was executed already; won't add this file: {fileName}");
                        }
                        else
                        {
                            currDir_File.Files.Add(new D7File { Name = fileName, Size = fileSize });
                        }
                        break;
                }
            }

            // We have the tree.  Let's do stuff with it.
            if (!IsPartB)
            {
                var result = GetPartASum(root);
                return result;
            }

            // Find the directory with the smallest size that's greater than (70M - freespace).
            // Total space: 70M
            // Used space (root.GetSize()): 48.4M
            // Free space (70M - size): 21.6M
            // Need to find a dir that minimizes (30M - (70M - size)) -> 30M - 70M + size -> size - 40m
            //Console.WriteLine($"Total size: {root.GetSize()}");
            return GetPartBResult(root, root.GetSize() - 40_000_000);
        }

        public long GetPartASum(Directory dir)
        {
            long result = 0;
            if (dir.GetSize() <= 100000)
            {
                result += dir.GetSize();
            }

            foreach(var subDir in dir.Subdirectories)
            {
                result += GetPartASum(subDir);
            }

            return result;
        }

        /// <summary>
        /// Find the size of the directory with the most size less than 30 million.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public long GetPartBResult(Directory dir, long minSizeToDelete)
        {
            long result = long.MaxValue;
            foreach (var subDir in dir.Subdirectories)
            {
                var tmpResult = GetPartBResult(subDir, minSizeToDelete);
                if (tmpResult >= minSizeToDelete && tmpResult < result)
                {
                    result = tmpResult;
                }
            }

            if (dir.GetSize() >= minSizeToDelete && dir.GetSize() < result)
            {
                result = dir.GetSize();
            }

            return result;
        }

        public class Directory
        {
            public string Name { get; set; }
            public bool ContentsKnown { get; set; } = false;
            public List<Directory> Subdirectories = new List<Directory>();
            public  List<D7File> Files = new List<D7File>();
            private long size = -1;

            public Directory(string newName)
            {
                Name = newName;
                Subdirectories = new List<Directory>();
                Files = new List<D7File>();
            }

            public long GetSize()
            {
                if (size == -1)
                {
                    long currSize = 0;
                    foreach (var dir in Subdirectories)
                    {
                        currSize += dir.GetSize();
                    }

                    foreach (var file in Files)
                    {
                        currSize += file.Size;
                    }

                    size = currSize;
                }

                return size;
            }
        }

        public class D7File
        {
            public string Name { get; set; }
            public long Size { get; set; }
        }
    }
}
