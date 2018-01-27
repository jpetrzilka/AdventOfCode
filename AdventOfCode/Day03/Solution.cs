using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Solution
    {
        public long GetResult1(int input)
        {
            (int x, int y) = GetNextPosition(input);
            return Math.Abs(x) + Math.Abs(y);
        }

        (int x, int y) GetNextPosition(int targetPosition)
        {
            int x = 0, y = 0, stepSize = 1, position = 1;
            Direction currentDirection = Direction.Right;

            while (position <= targetPosition)
            {
                for (int i = 0; i < stepSize; i++)
                {
                    if (position == targetPosition)
                        return (x, y);

                    (x, y) = MoveInDirection(x, y, currentDirection);
                    position++;
                }
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);

                for (int i = 0; i < stepSize; i++)
                {
                    if (position == targetPosition)
                        return (x, y);

                    (x, y) = MoveInDirection(x, y, currentDirection);
                    position++;
                }
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);

                stepSize++;
            }

            return (x, y);
        }

        (int x, int y) MoveInDirection(int currentX, int currentY, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return (currentX + 1, currentY);
                case Direction.Up:
                    return (currentX, currentY + 1);
                case Direction.Left:
                    return (currentX - 1, currentY);
                case Direction.Down:
                    return (currentX, currentY - 1);
                default:
                    throw new NotSupportedException(direction.ToString());
            }
        }


        public long GetResult2(string input) => throw new NotImplementedException();

        enum Direction
        {
            Right = 0,
            Up = 1,
            Left = 2,
            Down = 3
        }
    }
}
