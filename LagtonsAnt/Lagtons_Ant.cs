using System.Collections.Generic;

namespace LagtonsAnt
{
    public class Lagtons_Ant
    {
        private int GridSizeX { get; set; }
        private int GridSizeY { get; set; }
        public int AntLocationX { get; set; }
        public int AntLocationY { get; set; }
        private bool SoftBoundries { get; set; } = false;

        public enum Direction
        { Up, Right, Down, Left }

        public Direction CurrentDirection = Direction.Up;

        public List<List<int>> GridWorld = new List<List<int>> { };

        public Lagtons_Ant(int X, int Y, int Sx, int Sy, bool SolidWalls)
        {
            GridSizeX = X;
            GridSizeY = Y;
            AntLocationX = Sx;
            AntLocationY = Sy;
            if (SolidWalls) { SoftBoundries = false; }
            else { SoftBoundries = true; }
            BuildGridsWorld();
        }

        private void BuildGridsWorld()
        {
            for (int y = 0; y < GridSizeY; y++)
            {
                List<int> Row = new List<int> { };
                for (int x = 0; x < GridSizeX; x++)
                {
                    Row.Add(0);
                }
                GridWorld.Add(Row);
            }
        }

        public void MoveAnt()
        {
            switch (CurrentDirection)
            {
                case (Direction.Up):
                    MoveUp();
                    break;

                case (Direction.Right):
                    MoveRight();
                    break;

                case (Direction.Down):
                    MoveDown();
                    break;

                case (Direction.Left):
                    MoveLeft();
                    break;
            }
        }

        private void MoveUp()
        {
            // Move
            AntLocationY--;
                        
            if (AntLocationY < 0 && SoftBoundries == true) { AntLocationY = GridSizeY - 1; } // Ant exits top of world and enters at bottom
            if (AntLocationY < 0 && SoftBoundries == false) { CurrentDirection = Direction.Down; return; } // Ant rebounds of walls
            else
            {   
                // Update
                if (GridWorld[AntLocationY][AntLocationX] == 0)
                {
                    GridWorld[AntLocationY][AntLocationX] = 1;
                    CurrentDirection = Direction.Right;
                }
                else
                {
                    GridWorld[AntLocationY][AntLocationX] = 0;
                    CurrentDirection = Direction.Left;
                }
            }
        }

        private void MoveRight()
        {
            // Move
            AntLocationX++;
            
            if (AntLocationX == GridSizeX && SoftBoundries == true) { AntLocationX = 0; } // Ant exits right of world and enters at left
            if (AntLocationX == GridSizeX && SoftBoundries == false) { CurrentDirection = Direction.Left; return; } // Ant rebounds of walls
            else {

                // Update
                if (GridWorld[AntLocationY][AntLocationX] == 0)
                {
                    GridWorld[AntLocationY][AntLocationX] = 1;
                    CurrentDirection = Direction.Down;
                }
                else
                {
                    GridWorld[AntLocationY][AntLocationX] = 0;
                    CurrentDirection = Direction.Up;
                }
            }
        }

        private void MoveDown()
        {
            // Move
            AntLocationY++;

            if (AntLocationY == GridSizeY && SoftBoundries == true) { AntLocationY = 0; } // Ant exits bottom of world and enters at top
            if (AntLocationY == GridSizeY && SoftBoundries == false) { CurrentDirection = Direction.Up; return; } // Ant rebounds of walls
            else
            {

                // Update
                if (GridWorld[AntLocationY][AntLocationX] == 0)
                {
                    GridWorld[AntLocationY][AntLocationX] = 1;
                    CurrentDirection = Direction.Left;
                }
                else
                {
                    GridWorld[AntLocationY][AntLocationX] = 0;
                    CurrentDirection = Direction.Right;
                }
            }
        }

        private void MoveLeft()
        {
            // Move
AntLocationX--;

            if (AntLocationX < 0 && SoftBoundries == true) { AntLocationX = GridSizeY - 1; } // Ant exits left of world and enters at right
            if (AntLocationX < 0 && SoftBoundries == false) { CurrentDirection = Direction.Right; return; } // Ant rebounds of walls
            else
            {

                // Update
                if (GridWorld[AntLocationY][AntLocationX] == 0)
                {
                    GridWorld[AntLocationY][AntLocationX] = 1;
                    CurrentDirection = Direction.Up;
                }
                else
                {
                    GridWorld[AntLocationY][AntLocationX] = 0;
                    CurrentDirection = Direction.Down;
                }
            }
        }
    }
}