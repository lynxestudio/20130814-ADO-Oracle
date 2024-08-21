// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="apifiedsignature">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Samples.WinOraAdo
{
    using System;
    using System.Linq;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Logger
    {
        public static void LogWriteError(string s)
        {
            using (FileStream stream = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(stream);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(s);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
