using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ConsoleApp
{
    class FileExample
    {
        public void writeData()
        {
            FileStream fs = new FileStream("D:/sample1.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            BinaryWriter sw = new BinaryWriter(fs);
            string UserName = Console.ReadLine();
            sw.Write(UserName);
            int weight = Convert.ToInt32(Console.ReadLine());
            sw.Write(weight);


            sw.Close();
            fs.Close();
        }

        public void readData()
        {
            FileStream fs = new FileStream("D:/sample1.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader sr = new BinaryReader(fs);
            //sr.BaseStream.Seek(10, SeekOrigin.Begin);
            string name = sr.ReadString();
            int weight = sr.ReadInt32();
            Console.WriteLine("Name : {0}, Weight: {1}",name,weight);
            sr.Close();
            fs.Close();
        }

        public void FileDetails()
        {
            FileInfo fi = new FileInfo("D:/Sample.txt");
            Console.WriteLine(fi.Name);
            Console.WriteLine("File size in bytes {0}", fi.Length);
            Console.WriteLine("File size in bytes {0}", fi.DirectoryName);
        }

        public void DirectoryDetails()
        {
            DirectoryInfo di = new DirectoryInfo("D:/Samples");
            foreach (var f in di.GetDirectories())
            {
                Console.WriteLine(f);
            }

            foreach (var f in di.GetFiles())
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("File size in bytes {0}", di.CreationTime);
            Console.WriteLine("File size in bytes {0}", di.LastAccessTime);
            di.CreateSubdirectory("Hello");
        }

        public void Serialization()
        {
            Student s = new Student();
            s.StudentId = 202;
            s.StudentName = "Pranay";
            s.Marks = 450;

            FileStream fs = new FileStream("D:/Student.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            BinaryFormatter frmtr = new BinaryFormatter();

            frmtr.Serialize(fs, s);
            fs.Close();
        }

        public void Deserialization()
        {
            Student s;
            FileStream fs = new FileStream("D:/Sample.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter frmtr = new BinaryFormatter();

            s = (Student)frmtr.Deserialize(fs);//Object
            Console.WriteLine(s.StudentId);
            Console.WriteLine(s.StudentName);
            Console.WriteLine(s.Marks);
            s.DisplayDetails();
            fs.Close();

        }
    }
}

