using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Fond;

namespace Opc.Hda {
    public static class HelperFileSystem {
        static readonly string baseTempDirectory = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User);


        /// <summary>
        /// ��������� ������������� ���������� � ���������
        /// </summary>
        /// <param name="processes"></param>
        /// <returns></returns>
        [NotNull]
        public static string ConcatProcessInfo(this IEnumerable<Process> processes)
        {
            if (processes == null)
            {
                return String.Empty;
            }

            var sb = new StringBuilder();

            foreach (var p in processes)
            {
                string mainModuleFileName = null;
                try
                {
                    mainModuleFileName = $"����={p.MainModule?.FileName}";
                }
                catch (Win32Exception e)
                {
                    //handled => ���� ������� ��� ������� ������������ ������� (����� ��������)
                }
                sb.AppendLine($"\t���={p.ProcessName} {mainModuleFileName}");
            }

            return sb.ToString();
        }

        /// 
        /// ������� ������� ������ � �����.
        /// 
        /// ���� �� �����.
        /// ������� ���������.
        /// ������� ��� -1 ���� ��
        /// ����� ���� �������
        public static long Seek(string file, string searchString)
        {
            using (FileStream fs =
                File.OpenRead(file))
            {
                return Seek(fs, searchString);
            }
        }





        /// <summary>
        /// ���� ��������� ������ � ������ �����.
        //��� ��������� ��������� ������.
        //
        //    ����� ��������� �����.
        //    ������ ��� ������.
        //    ��������� ������ ��� -1, ����
        //    ������ �� ����� ���� �������.

        /// </summary>
        /// <param name="fs"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static long Seek(Stream fs,
            string searchString)
        {
            char[] search = searchString.ToCharArray();
            long result = -1, position = 0, stored = -1,
                begin = fs.Position;
            int c;

            while ((c = fs.ReadByte()) != -1)
            {
                if ((char)c == search[position])
                {
                    if (stored == -1 && position > 0
                                     && (char)c == search[0])
                    {
                        stored = fs.Position;
                    }

                    if (position + 1 == search.Length)
                    {
                        result = fs.Position - search.Length;
                        fs.Position = result;
                        break;
                    }

                    position++;
                }
                else if (stored > -1)
                {
                    fs.Position = stored + 1;
                    position = 1;
                    stored = -1;
                }
                else
                {
                    position = 0;
                }
            }

            if (result == -1)
            {
                fs.Position = begin;
            }

            return result;
        }

        

        /// <summary>
        /// ����� � ����������� �� <paramref name="allowedExtensions"/> �������������
        /// </summary>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        public static bool IsFileAllowed(this string fName, IList<string> allowedExtensions)
        {
            bool validFiles = IsAllowedExtensions(new[] {fName}, allowedExtensions);
            return validFiles;
        }

        /// <summary>
        /// ���������,  ������������� �� � ������ ���������� �����������, ���� ���� ���� �� �������������� �� ���������
        /// </summary>
        /// <param name="files"></param>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        public static bool IsAllowedExtensions(this string[] files, IList<string> allowedExtensions)
        {
            if (files == null)
            {
                return false;
            }

            if (allowedExtensions == null || allowedExtensions.Count == 0)
            {
                throw new NotSupportedException("[HelperDragDropFile.IsAllowedExtensions]�� ��������������!");
            }

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if (String.IsNullOrEmpty(ext))
                {
                    return false; //// ��� ����������
                }

                ext = ext.ToLowerInvariant();
                if (!allowedExtensions.Contains(ext))
                {
                    return false; //// ���� ���� � ������������ �����������
                }
            }
            return true;
        }

        public static string CreateTempDirectory()
        {
            string tempDirectory = baseTempDirectory + @"\" + Guid.NewGuid().ToString();
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}