using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyTest.Models
{
    public class Rover
    {
        /// <summary>
        /// Generate a rover
        /// </summary>
        /// <param name="initialPoint">Initial point of rover</param>
        /// <param name="instruction">Instructions to follow for rover</param>
        public Rover(InitialPoint initialPoint, string instruction)
        {
            InitialPoint = initialPoint;
            Instruction = instruction;
        }
        public InitialPoint InitialPoint { get; set; }
        public string Instruction { get; set; }
    }
}
