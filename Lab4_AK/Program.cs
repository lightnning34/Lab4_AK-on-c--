using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_AK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input source directory");
            string sourceDirectory = Console.ReadLine();
            Console.WriteLine("Input target directory");
            string targetDirectory = Console.ReadLine();
            Console.WriteLine("Input extension\n Example:\n .txt for txt files\n any for all files");
            string fileExtension = Console.ReadLine();
            if (fileExtension == "any")
            {
                try
                {
                    string[] files = Directory.GetFiles(sourceDirectory);

                    foreach (string file in files)
                    {
                        FileAttributes attributes = File.GetAttributes(file);
                        bool isHidden = (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                        bool isReadOnly = (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
                        bool isArchive = (attributes & FileAttributes.Archive) == FileAttributes.Archive;

                        string fileName = Path.GetFileName(file);

                        string targetPath = Path.Combine(targetDirectory, fileName);

                        File.Move(file, targetPath);

                        Console.WriteLine("File {0} was moved to {1}.", fileName, targetDirectory);

                        if (isHidden)
                        {
                            Console.WriteLine("File {0} is Hidden'.", fileName);
                        }

                        if (isReadOnly)
                        {
                            Console.WriteLine("File {0} is ReadOnly.", fileName);
                        }

                        if (isArchive)
                        {
                            Console.WriteLine("File {0} is Archive.", fileName);
                        }
                    }

                    Console.WriteLine("All files were moved.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occurred: {0}", e.Message);
                }

                Console.ReadLine();
            }
            else
            {
                try
                {
                    string[] files = Directory.GetFiles(sourceDirectory, "*" + fileExtension);

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);

                        string targetPath = Path.Combine(targetDirectory, fileName);

                        FileAttributes attributes = File.GetAttributes(file);
                        bool isHidden = (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                        bool isReadOnly = (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
                        bool isArchive = (attributes & FileAttributes.Archive) == FileAttributes.Archive;

                        File.Move(file, targetPath);

                        Console.WriteLine("File {0} moved to {1}.", fileName, targetDirectory);
                        if (isHidden)
                        {
                            Console.WriteLine("File {0} is Hidden.", fileName);
                        }

                        if (isReadOnly)
                        {
                            Console.WriteLine("File {0} is ReadOnly.", fileName);
                        }

                        if (isArchive)
                        {
                            Console.WriteLine("File {0} is Archive.", fileName);
                        }
                    }

                    Console.WriteLine("All files with extension {0} were moved.", fileExtension);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occurred: {0}", e.Message);
                }

                Console.ReadLine();
            }
            
        }
    }
}
