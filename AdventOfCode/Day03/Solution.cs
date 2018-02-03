using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public partial class Solution
    {
        List<Position> spiralGrid;
        Func<bool> stopCondition;

        public long GetResult1(int input)
        {
            stopCondition = () => spiralGrid.Last().positionIndex == input; 
            var lastPosition = GenerateSpiralGrid(input).Last();
            return Math.Abs(lastPosition.x) + Math.Abs(lastPosition.y);
        }

        public long GetResult2(int input)
        {
            stopCondition = () => spiralGrid.Last().value > input;
            var lastPosition = GenerateSpiralGrid(input).Last();
            return lastPosition.value;
        }

        List<Position> GenerateSpiralGrid(int targetPosition)
        {
            spiralGrid = new List<Position>() { new Position(0, 0, 1, 1) };
            int stepSize = 1;
            Direction currentDirection = Direction.Right;

            while (!stopCondition())
            {
                DoStepsInDirecion(stepSize, currentDirection);
                currentDirection = GetNextDirection(currentDirection);

                DoStepsInDirecion(stepSize, currentDirection);
                currentDirection = GetNextDirection(currentDirection);

                stepSize++;
            }

            return spiralGrid;
        }

        private static Direction GetNextDirection(Direction currentDirection)
            => (Direction)(((int)currentDirection + 1) % 4);

        void DoStepsInDirecion(int stepSize, Direction currentDirection)
        {
            for (int i = 0; i < stepSize; i++)
            {
                if (stopCondition() == true)
                    return;

                var newPosition = MoveInDirection(spiralGrid.Last(), currentDirection);
                spiralGrid.Add(newPosition);
            }
        }

        Position MoveInDirection(Position currentPosition, Direction direction)
        {
            var position = new Position(currentPosition);
            position.positionIndex++;

            switch (direction)
            {
                case Direction.Right:
                    position.x++;
                    break;
                case Direction.Up:
                    position.y++;
                    break;
                case Direction.Left:
                    position.x--;
                    break;
                case Direction.Down:
                    position.y--;
                    break;
                default:
                    throw new NotSupportedException(direction.ToString());
            }

            for (int i = 0; i < spiralGrid.Count; i++)
            {
                if (Math.Abs(spiralGrid[i].x - position.x) <= 1
                    && Math.Abs(spiralGrid[i].y - position.y) <= 1)
                {
                    position.value += spiralGrid[i].value;
                }
            }

            return position;
        }

        enum Direction
        {
            Right = 0,
            Up = 1,
            Left = 2,
            Down = 3
        }
    }
}
