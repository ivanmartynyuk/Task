using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace Test_App.Models
{public
    class MyDirectory
    {
        public string Path { get; set; }
        public int[] Counts{ get; set; }
        public string[] PidDerictories { get; set; }
        public string[] Files { get; set; }
    }
public class Direct_Mod
{
    public string Value { get; set; }
}
    public class Manager_Directory
    {
        DirectoryInfo _directory_info;
        string _directory;

        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }
        int _Size_file_ten_mb;
        int _Size_file_fifty_mb;
        int _Size_file_hundred_mb;
        public void Step_To_other_Directory(string directory) 
        {
            if(directory.Contains("..."))
            {
                try
                {
                    directory = _directory_info.Parent.FullName;
                }
                catch(NullReferenceException) 
                {
                    directory = _directory_info.FullName;
                }
            }
            _directory = directory;
            DirectoryInfo temp = new DirectoryInfo(directory);

            _directory_info = temp;

        }
        public string[] GetDirectories() 
        {
            List<string> name_Dere=new List<string>();
            if(_directory_info.FullName!=_directory_info.Root.FullName)
            name_Dere.Add("...");
            foreach (var item in _directory_info.GetDirectories())
            {           name_Dere.Add(item.Name);               
            }
            return name_Dere.ToArray();
        }
        public int[] Get_Sort_Files()
        {
            int[] array_files = new int[3];
            _Size_file_ten_mb = 0;
            _Size_file_fifty_mb = 0;
            _Size_file_hundred_mb = 0;

            long size_file;
  
                foreach (FileInfo item in _directory_info.GetFiles("*", SearchOption.AllDirectories))
                {
                    
                    size_file = item.Length;
                    if (size_file <= 10485760L)
                    {
                        _Size_file_ten_mb++;
                    }
                    else if (size_file >= 10485760L && size_file <= 52428800L)
                    {
                        _Size_file_fifty_mb++;
                    }
                    else if (size_file >= 104857600)
                    {
                        _Size_file_hundred_mb++;
                    }

                }
   
            array_files[0] = _Size_file_ten_mb;
          array_files[1] = _Size_file_fifty_mb;
          array_files[2] = _Size_file_hundred_mb;

          return array_files; 
        }
            
        

        public Manager_Directory(string d) 
        {
            _directory = d;
            _directory_info = new DirectoryInfo(this._directory);
        }
        public string[] GetFiles() 
        {List<string> files_name=new List<string>();
        foreach (var item in _directory_info.GetFiles())
        {
            files_name.Add(item.Name);
        }
        return files_name.ToArray();
          
               
       
        }


    }
}