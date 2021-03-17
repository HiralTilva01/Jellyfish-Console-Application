//-----------------------------------------------------------------------
// <copyright file="ProcessRequest.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  This class is for processing the request
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>16-March-2021</CreatedDate>
    public static class ProcessRequest
    {
        public static List<FinalResult> CalculateResult(List<FinalResult> finalResults)
        {
            int start, maxX, maxY, initialX, initialY, nextX = 0;
            int nextY = 0;
            char initialDirection = Char.MinValue;
            string inputValue, instructionValue = string.Empty;
            bool isLost = false;
            try
            {
                //// Check if there any inputes or not
                if (finalResults?.Count > 0)
                {
                    int.TryParse(finalResults[0].Input, out start);

                    //// Check the upper right coordinate is correct or not
                    if (start > 0 && start.ToString().Length == 2)
                    {
                        maxX = Convert.ToInt32(start.ToString().Substring(0, 1));
                        maxY = Convert.ToInt32(start.ToString().Substring(1, 1));

                        //// loop throught the jellyfish instruction line by line
                        for (int i = 1; i < finalResults.Count - 1; i++)
                        {
                            inputValue = finalResults[i].Input;
                            var inputs = inputValue.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                            //// check the starting position and initial direction
                            if (inputs?.Length > 0 && inputs.Length == 2)
                            {
                                if (int.TryParse(inputs[0][0].ToString(), out initialX) && int.TryParse(inputs[0][1].ToString(), out initialY))
                                {
                                    nextX = initialX;
                                    nextY = initialY;

                                    initialDirection = inputs[0].ToString().Length == 3 ? inputs[0].ToString()[2] : Char.MinValue;
                                    if (nextX >= 0 && nextY >= 0 &&
                                        (initialDirection == Constants.NORTH_DIRECTION || initialDirection == Constants.SOUTH_DIRECTION || initialDirection == Constants.WEST_DIRECTION || initialDirection == Constants.EAST_DIRECTION))
                                    {
                                        instructionValue = inputs[1];

                                        //// loop throught the jellyfish instruction by char
                                        foreach (char charItem in instructionValue)
                                        {
                                            isLost = false;
                                            if (charItem == Constants.FORWARD_DIRECTION || charItem == Constants.RIGHT_MOVE || charItem == Constants.LEFT_MOVE)
                                            {
                                                switch (charItem)
                                                {
                                                    case Constants.FORWARD_DIRECTION:
                                                        switch (initialDirection)
                                                        {
                                                            case Constants.NORTH_DIRECTION:
                                                                if (!(nextY + 1 > maxY))
                                                                    nextY++;
                                                                else
                                                                    isLost = true;
                                                                break;
                                                            case Constants.SOUTH_DIRECTION:
                                                                if (!(nextY - 1 < 0))
                                                                    nextY--;
                                                                else
                                                                    isLost = true;
                                                                break;
                                                            case Constants.EAST_DIRECTION:
                                                                if (!(nextX + 1 > maxX))
                                                                    nextX++;
                                                                else
                                                                    isLost = true;
                                                                break;
                                                            case Constants.WEST_DIRECTION:
                                                                if (!(nextX - 1 < 0))
                                                                    nextX--;
                                                                else
                                                                    isLost = true;
                                                                break;
                                                            default:
                                                                break;
                                                        }

                                                        //If jellyfish is lost save the actual coordinates
                                                        if (isLost)
                                                        {
                                                            if (!(i > 1 && finalResults[i - 1]?.IsLost == true && finalResults[i - 1].LostX == nextX && finalResults[i - 1].LostY == nextY))
                                                            {
                                                                finalResults[i].IsLost = true;
                                                                finalResults[i].LostX = nextX;
                                                                finalResults[i].LostY = nextY;
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                    case Constants.RIGHT_MOVE:
                                                        switch (initialDirection)
                                                        {
                                                            case Constants.NORTH_DIRECTION:
                                                                initialDirection = Constants.EAST_DIRECTION;
                                                                break;
                                                            case Constants.SOUTH_DIRECTION:
                                                                initialDirection = Constants.WEST_DIRECTION;
                                                                break;
                                                            case Constants.EAST_DIRECTION:
                                                                initialDirection = Constants.SOUTH_DIRECTION;
                                                                break;
                                                            case Constants.WEST_DIRECTION:
                                                                initialDirection = Constants.NORTH_DIRECTION;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    case Constants.LEFT_MOVE:
                                                        switch (initialDirection)
                                                        {
                                                            case Constants.NORTH_DIRECTION:
                                                                initialDirection = Constants.WEST_DIRECTION;
                                                                break;
                                                            case Constants.SOUTH_DIRECTION:
                                                                initialDirection = Constants.EAST_DIRECTION;
                                                                break;
                                                            case Constants.EAST_DIRECTION:
                                                                initialDirection = Constants.NORTH_DIRECTION;
                                                                break;
                                                            case Constants.WEST_DIRECTION:
                                                                initialDirection = Constants.SOUTH_DIRECTION;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                finalResults[i].ErrorMessage = SystemMessages.ValidInstructionString.Replace("{1}", (i + 1).ToString());
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        finalResults[i].ErrorMessage = SystemMessages.ValidFirstString.Replace("{1}", (i + 1).ToString());
                                    }
                                }
                                else
                                {
                                    finalResults[i].ErrorMessage = SystemMessages.ValidFirstTwoDigit.Replace("{1}", (i + 1).ToString());
                                }
                            }
                            else
                            {
                                finalResults[i].ErrorMessage = SystemMessages.ValidLineInputMessage.Replace("{1}", (i + 1).ToString());
                            }

                            //// Add final output
                            if (finalResults[i].IsLost)
                                finalResults[i].Output = nextX.ToString() + nextY.ToString() + initialDirection.ToString() + Constants.LOST;
                            else
                                finalResults[i].Output = nextX.ToString() + nextY.ToString() + initialDirection.ToString();
                        }
                    }
                    else
                    {
                        finalResults[0].ErrorMessage = SystemMessages.ValidStartNumber;
                    }
                }
                else
                {
                    finalResults[0].ErrorMessage = SystemMessages.ValidInput;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(SystemMessages.ErrorMessage);
                ErrorLog.LogError(ex);
            }

            return finalResults;
        }
    }
}
