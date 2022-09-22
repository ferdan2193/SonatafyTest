using SonatafyTest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyTest
{
    public class MarsRovers
    {
        private Point explorationLimitPoint;
        private List<Rover> rovers;

        public MarsRovers(Point explorationLimitPoint, List<Rover> rovers)
        {
            this.explorationLimitPoint = explorationLimitPoint;
            this.rovers = rovers;
        }

        /// <summary>
        /// This method execute all instructions
        /// </summary>
        /// <returns>Returns lis with the final position of rovers</returns>
        public List<string> ExecuteInstructions()
        {
            List<string> listExecuted = new List<string>();
            foreach(Rover rover in rovers)
            {
                int positionX = rover.InitialPoint.positionX;
                int positionY = rover.InitialPoint.positionY;
                Direction direction = rover.InitialPoint.direction;
                for(int i = 0; i < rover.Instruction.Length; i++)
                {
                    switch (rover.Instruction[i])
                    {
                        case 'R':
                            if((int)direction == 3)
                            {
                                direction = Direction.N;
                            }
                            else
                            {
                                direction++;
                            }
                            break;
                        case 'L':
                            if ((int)direction == 0)
                            {
                                direction = Direction.W;
                            }
                            else
                            {
                                direction--;
                            }
                            break;
                        case 'M':
                            if (direction == Direction.W)
                                positionX--;

                            if (direction == Direction.N)
                                positionY++;

                            if (direction == Direction.E)
                                positionX++;

                            if (direction == Direction.S)
                                positionY--;
                            break;
                    }
                }


                listExecuted.Add(String.Format("{0} {1} {2}", positionX, positionY, direction.ToString()));
            }
            return listExecuted;
        }

    }
}
