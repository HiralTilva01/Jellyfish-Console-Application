//-----------------------------------------------------------------------
// <copyright file="FinalResult.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    /// <summary>
    ///  This class is for input and output result
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>16-March-2021</CreatedDate>
    public class FinalResult
    {
        /// <summary>
        /// Input
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Output
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// is jellyfish Lost
        /// </summary>
        public bool IsLost { get; set; }

        /// <summary>
        /// LostX Position
        /// </summary>
        public int LostX { get; set; }

        /// <summary>
        /// LostY position
        /// </summary>
        public int LostY { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
