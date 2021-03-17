//-----------------------------------------------------------------------
// <copyright file="ErrorLog.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    using System;
    using System.IO;

    /// <summary>
    ///  This class is for error log
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>17-March-2021</CreatedDate>
   public class ErrorLog
    {
        public static void LogError(Exception ex)
        {
            try
            {
                var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("Message: {0}", ex.Message);
                message += Environment.NewLine;
                message += string.Format("StackTrace: {0}", ex.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", ex.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
                message += Environment.NewLine;
                message += "=======================================================================================================================";

                string path = appPath + @"\ErrorLog\ErrorDetails.txt";
                string dir = appPath + @"\ErrorLog";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);

                }
                // check if the file does not exists..
                if (!File.Exists(path))
                {
                    // create new file
                    FileStream f = File.Create(path);
                    f.Close();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
                else
                    // write log
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
            }
            catch (Exception e)
            {

            }
        }
    }
}
