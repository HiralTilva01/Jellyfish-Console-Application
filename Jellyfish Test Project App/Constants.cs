//-----------------------------------------------------------------------
// <copyright file="Constants.cs">
// Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Jellyfish_Test_Project_App
{
    /// <summary>
    ///  This class is for Constants
    /// </summary>
    /// <CreatedBy>Hiral Tilva</CreatedBy>
    /// <CreatedDate>16-March-2021</CreatedDate>
    public static class Constants
    {
        /// <summary>
        /// North Direction
        /// </summary>
        public const char NORTH_DIRECTION = 'N';

        /// <summary>
        /// South Direction
        /// </summary>
        public const char SOUTH_DIRECTION = 'S';

        /// <summary>
        /// West Direction
        /// </summary>
        public const char WEST_DIRECTION = 'W';

        /// <summary>
        /// East Direction
        /// </summary>
        public const char EAST_DIRECTION = 'E';

        /// <summary>
        /// Forward : the jellyfish moves forward one grid point in the direction of the current orientation and maintains the same orientation. 
        /// </summary>
        public const char FORWARD_DIRECTION = 'F';

        /// <summary>
        /// Right : the jellyfish turns right 90 degrees and remains on the current grid point. 
        /// </summary>
        public const char RIGHT_MOVE = 'R';

        /// <summary>
        /// Left : the jellyfish turns left 90 degrees and remains on the current grid point. 
        /// </summary>
        public const char LEFT_MOVE = 'L';

        /// <summary>
        /// jellyfish falls off the edge of the grid 
        /// </summary>
        public const string LOST = "LOST";

        /// <summary>
        /// max value of X coordinates
        /// </summary>
        public const int MAX_X_ALLOWED = 9;

        /// <summary>
        /// max value of Y coordinates
        /// </summary>
        public const int MAX_Y_ALLOWED = 9;
    }
}
