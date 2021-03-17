//-----------------------------------------------------------------------
// <copyright file="Program.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  This class is for Program
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>16-March-2021</CreatedDate>
    class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<FinalResult> inputesList = new List<FinalResult>();
            string line;
            bool isContinue = true;
            try
            {
                Console.WriteLine(SystemMessages.WelcomeMessage);
                Console.WriteLine(SystemMessages.DisplayOutput);

            ContinueInput:
                inputesList = new List<FinalResult>();
                Console.WriteLine(SystemMessages.SeparatorLine);
                Console.WriteLine(SystemMessages.Inputs);
                Console.WriteLine(SystemMessages.SeparatorLine);
                do
                {
                    line = Console.ReadLine();
                    inputesList.Add(new FinalResult { Input = line });
                } while (!String.IsNullOrWhiteSpace(line) && line.ToLower() != "c" && isContinue);

                ////Call function to process the inputes and provide output
                inputesList = ProcessRequest.CalculateResult(inputesList);

                ////Display Output 
                if (inputesList?.Count > 0)
                {
                    Console.WriteLine(SystemMessages.SeparatorLine);
                    Console.WriteLine(SystemMessages.OutputMessage);
                    Console.WriteLine(SystemMessages.SeparatorLine);
                    if (inputesList[0].ErrorMessage?.Length > 0)
                    {
                        Console.WriteLine(inputesList[0].ErrorMessage);
                        goto NextInputRequied;
                    }
                    else
                    {
                        if (inputesList?.Count > 2)
                        {
                            for (int i = 1; i < inputesList.Count - 1; i++)
                            {
                                Console.WriteLine(inputesList[i].ErrorMessage?.Length > 0 ? inputesList[i].ErrorMessage : inputesList[i].Output);
                            }

                            goto NextInputRequied;
                        }
                        else
                        {
                            Console.WriteLine(SystemMessages.NoInstructionFound);
                            goto NextInputRequied;
                        }
                    }
                }

            //// Ask to Continue OR Exit
            NextInputRequied:
                Console.WriteLine(SystemMessages.ContinueMessage);
                char answer = Convert.ToChar(Console.ReadLine().ToLower());
                if (answer == 'y')
                {
                    goto ContinueInput;
                }
                else if (answer == 'n')
                {
                    isContinue = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(SystemMessages.ErrorMessage);
                ErrorLog.LogError(ex);
            }
            finally
            {

            }
        }
    }
}
