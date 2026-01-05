using System;
using UnityEngine;

namespace Match3Core
{

    public enum GemType 
    { 
        None = -1,
        Red = 0,
        Blue = 1,
        Green = 2,
        Orange = 3,
        Yellow = 4,
    }

    public struct GridPosition : IEquatable<GridPosition>
    {
        public int x;
        public int y;

        public GridPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(GridPosition other)
        {
            return x == other.x && y == other.y;
        }

        public static bool operator ==(GridPosition a, GridPosition b) => a.Equals(b);
        public static bool operator !=(GridPosition a, GridPosition b) => !a.Equals(b);

        public override bool Equals(object obj)
        {
            return obj is GridPosition grid && this.Equals(grid);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x} - {y})";
        }

        public bool IsNextTo(GridPosition other)
        {
            var dx = Mathf.Abs(x - other.x);
            var dy = Mathf.Abs(y - other.y);
            return dx + dy == 1;
        }
    }
}