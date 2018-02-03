namespace AdventOfCode.Day03
{
    public partial class Solution
    {
        struct Position
        {
            public Position(int x, int y, int position, int value)
            {
                this.x = x;
                this.y = y;
                this.positionIndex = position;
                this.value = value;
            }

            public Position(Position position)
            {
                x = position.x;
                y = position.y;
                this.positionIndex = position.positionIndex;
                value = 0;
            }

            public int x;
            public int y;
            public int positionIndex;
            public int value;
        }
    }
}
