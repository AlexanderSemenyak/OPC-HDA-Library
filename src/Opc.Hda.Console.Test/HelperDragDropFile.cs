using System.Collections.Generic;
using System.Windows.Forms;

namespace Opc.Hda
{
    /// <summary>
    /// Класс-помошник в перетаскивании файлов на Grid/Tree да вообще куда угодно
    /// </summary>
    public static class HelperDragDropFile
    {
        /// <summary>
        /// Проверить наличие в перетаскиваемых данных файлов
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsFilesExists(DragEventArgs e)
        {
            if (e == null)
            {
                return false;
            }

            bool filesExists = e.Data.GetDataPresent(DataFormats.FileDrop);
            if (filesExists)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Все перетаскиваемые файлы с расширениями из <paramref name="allowedExtensions"/>
        /// </summary>
        /// <param name="dragEventArgs"></param>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        public static bool IsAllFilesAllowed(this DragEventArgs dragEventArgs, IList<string> allowedExtensions)
        {
            if (allowedExtensions == null || allowedExtensions.Count == 0)
            {
                return IsFilesExists(dragEventArgs);
            }

            string[] files;
            string errorText;
            if (!GetFileHeadersFromDragEventArgs(dragEventArgs, out files, out errorText))
            {
                return false;
            }

            if (!HelperFileSystem.IsAllowedExtensions(files, allowedExtensions)) return false;

            return true;
        }

        /// <summary>
        /// Проверить наличие только одного перетаскиваемого файла
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsFilesExistsOnlyOne(this DragEventArgs e)
        {
            string[] files;
            string errorText;
            if (!GetFileHeadersFromDragEventArgs(e, out files, out errorText))
            {
                return false;
            }

            return (files != null && files.Length == 1);
        }

        /// <summary>
        /// Вернуть первый файл из перетаскиваемых
        /// </summary>
        /// <param name="e">Параметры перетаскивания</param>
        /// <returns>Первый файл из перетаскиваемых</returns>
        public static string GetFirstFileFromDragEventArgs(this DragEventArgs e)
        {
            if (!IsFilesExists(e))
            {
                return null;
            }

            string[] files;
            string errorText;
            if (!GetFilesFromDragEventArgs(e, out files, out errorText)||files == null||files.Length == 0)
            {
                return null;
            }

            return files[0];
        }


        /// <summary>
        /// Вернуть имена перетаскиваемых файлов или извлечь во временную папку файлы из IStream (см.<see cref="FileGroupDescriptor"/>)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="files"></param>
        /// <param name="errorText"></param>
        /// <returns></returns>
        public static bool GetFilesFromDragEventArgs(DragEventArgs e, out string[] files, out string errorText)
        {
            return GetFilesFromDragEventArgsInternal(e, false, out files, out errorText);
        }

        /// <summary>
        /// Разобрать перетаскиваемеы данные на предмет наличия файлов
        /// </summary>
        /// <param name="e"></param>
        /// <param name="files"></param>
        /// <param name="errorText"></param>
        /// <returns></returns>
        public static bool GetFileHeadersFromDragEventArgs(DragEventArgs e, out string[] files, out string errorText)
        {
            return GetFilesFromDragEventArgsInternal(e, true, out files, out errorText);
        }

        /// <summary>
        /// Разобрать перетаскиваемеы данные на предмет наличия файлов
        /// </summary>
        /// <param name="e"></param>
        /// <param name="files"></param>
        /// <param name="errorText"></param>
        /// <returns></returns>
        private static bool GetFilesFromDragEventArgsInternal(DragEventArgs e, bool onlyHeaders, out string[] files, out string errorText)
        {
            if (e == null)
            {
                errorText = "Не передана структура DragEventArgs.";
                files = null;
                return false;
            }

            if (!IsFilesExists(e))
            {
                errorText = "В перетаскиваемых данных нет файлов.";
                files = null;
                return false;
            }

            //// Если передали просто файлы
			files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                errorText = null;
                return true;
            }

            errorText = null;
            return true;
        }
    }
}
