﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class CheckFile
    {
        private string file_path;
        public CheckFile(string path)
        {
            file_path = path;
        }

        public bool IsFilePE()
        {
            const int blockSize = 16;
            string path = this.file_path;
            byte[] PE = { 80, 69, 00, 00 };

            //Crypting function
            byte[] buffer = new byte[blockSize];

            try
            {
                using (var f = File.OpenRead(path))
                {
                    while (true)
                    {
                        int readed;
                        int offset;
                        for (offset = 0; offset < blockSize;)
                        {
                            readed = f.Read(buffer, offset, blockSize - offset);
                            if (readed == 0) // End of file
                            {
                                return false;
                            }

                            for (int i = 0; i <= blockSize - 4; i++)
                            {
                                if (buffer[i] == PE[0])
                                {
                                    if (buffer[i + 1] == PE[1] && buffer[i + 2] == PE[2] && buffer[i + 3] == PE[3])
                                        return true;
                                }
                            }
                            offset += readed;
                            if (offset > 1024)
                                return false;
                        }
                    }
                } 
            } catch (Exception)
            {
                return false;
            }
        }

        public bool IsFileZip()
        {
            string path = this.file_path;
            try
            {
                FileInfo check = new FileInfo(path);
                if (check.Extension == ".zip")
                    return true;
                else
                    return false;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool IsFileDir()
        {
            string path = file_path;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                return dir.Exists;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
