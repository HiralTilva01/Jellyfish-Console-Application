//-----------------------------------------------------------------------
// <copyright file="SystemMessages.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    /// <summary>
    ///  This class is for System Display message
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>16-March-2021</CreatedDate>
    public static class SystemMessages
    {
        #region :: Common ::   
        
        public const string WelcomeMessage = "Welcome to Jellyfish task! Jellyfish are able to move according to instructions provided.";
        public const string ErrorMessage = "Error occurred while executing your request.";
        public const string DisplayOutput = "To display output Press “Enter” “C” “Enter” ";
        public const string ContinueMessage = "Do you want to Continue?(y/n):";
        public const string OutputMessage = "Output is as below:";
        public const string ValidInput = "Please Enter valid input.";
        public const string ValidStartNumber = "Please insert valid two digit integers specifying the initial coordinates of the jellyfish!";
        public const string ValidInstructionString = "An instruction in a line {1} should be word of the letters “L”, “R”, and “F” only.";
        public const string ValidFirstString = "First word in line {1} should be 2 digit integer number followed by an orientation (N, S, E, W).";
        public const string ValidFirstTwoDigit = "First word in line {1} should be 2 digit integer number.";
        public const string ValidLineInputMessage = "Input in a line {1} should consists of a sequence of jellyfish positions and instructions.";
        public const string Inputs = "Please Enter Inputs:";
        public const string NoInstructionFound = "Please Enter sequence of jellyfish positions and instructions.";
        public const string MaximumXLimitExceed = "The maximum value for first digit(X coordinate) is 9.";
        public const string MaximumYLimitExceed = "The maximum value for second digit(Y coordinate) is 9.";
        public const string SeparatorLine = "------------------------------------------------------------------------  ";

        #endregion
    }
}