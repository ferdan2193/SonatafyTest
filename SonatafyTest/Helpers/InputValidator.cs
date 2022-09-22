using SonatafyTest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SonatafyTest.Helpers
{
    public class InputValidator
    {
        /// <summary>
        /// /// This method will check if values x and y are typed correctly if not will return false
        /// </summary>
        /// <param name="xyValue">Exploration Limt Ex: 5 5</param>
        /// <param name="explorationLimit">Exploration Limit point Generated</param>
        /// <returns></returns>
        public static bool convertToExplorationPointLimit(string xyValue, out Point explorationLimit)
        {
            explorationLimit = new Point();
            if (string.IsNullOrEmpty(xyValue)) return false;

            string[] xyArray = xyValue.Split(" ");
            if(xyArray.Length != 2) return false;

            int x = 0, y = 0;
            if (!int.TryParse(xyArray[0], out x) || !int.TryParse(xyArray[1], out y))
            {
                return false;
            }
            explorationLimit.X = x;
            explorationLimit.Y = y;
            return true;
        }

        /// <summary>
        /// Split the initial point to check parameters
        /// </summary>
        /// <param name="initialPointValue">Initial Point not validated</param>
        /// <param name="initialPoint">Initial Point validated</param>
        /// <returns>Returns true if is valid</returns>
        public static bool initialPointValidation(string initialPointValue, out InitialPoint initialPoint)
        {
            initialPoint = new InitialPoint();
            string[] initialPointArray = initialPointValue.Split(" ");
            if (initialPointArray.Length != 3) return false;
            if (!isNumeric(initialPointArray[0]) || !isNumeric(initialPointArray[1])) return false;
            if (!validateDirection(initialPointArray[2])) return false;
            initialPoint.positionX = Convert.ToInt32(initialPointArray[0]);
            initialPoint.positionY = Convert.ToInt32(initialPointArray[1]);
            initialPoint.direction = (Direction)System.Enum.Parse(typeof(Direction), initialPointArray[2][0].ToString().ToUpper());
            return true;
        }

        /// <summary>
        /// Check if direction on any point is valid
        /// </summary>
        /// <param name="direction">String to check direction must have only one character for the direction</param>
        /// <returns>If is direction is correct returns true</returns>
        public static bool validateDirection(string direction)
        {
            if (direction.Length > 1) return false;
            string possibleDirections = "NSEW";

            return possibleDirections.Contains(direction.ToUpper());
        }

        /// <summary>
        /// Check if is numeric
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>Return true if numeric false if not</returns>
        public static bool isNumeric(string value) => int.TryParse(value, out _);

        /// <summary>
        /// Validate if instructions are right, letters not allowed will be ignored
        /// If string contains allowed letters will be used to generate right instruccions
        /// </summary>
        /// <param name="instructions">Instructions without any review</param>
        /// <param name="instructionsGenerated">Instructions generated correctly from instructions parameter</param>
        /// <returns>Returns if instruction is valid</returns>
        public static bool validateInstructions(string instructions, out string instructionsGenerated)
        {
            instructionsGenerated = string.Empty;
            if (String.IsNullOrEmpty(instructions)) return false;
            
            string possibleInstructions = "LMR";
            bool validInstructions = false;
            for (int i = 0; i < instructions.Length; i++)
            {
                if (possibleInstructions.Contains(instructions[i]))
                {
                    instructionsGenerated += instructions[i];
                    validInstructions = true;
                }
            }
            return validInstructions;
        }

    }
}
