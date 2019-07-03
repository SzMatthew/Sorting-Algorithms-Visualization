using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algoritm_Vizualization
{
    class Rectangle
    {
        private int X;
        private int Y;
        private int Heigth;

        public int getHeigth() {
            return Heigth;
        }

        public void setHeigth(int Heigth) {
            this.Heigth = Heigth;
        }

        public int getX() {
            return X;
        }

        public void setX(int X) {
            this.X = X;
        }

        public int getY() {
            return Y;
        }

        public void setY(int Y) {
            this.Y = Y;
        }

        public Rectangle(int X, int Y, int Heigth)
        {
            this.X = X;
            this.Y = Y;
            this.Heigth = Heigth;
        }

        public Rectangle ShallowCopy()
        {
            return (Rectangle)this.MemberwiseClone();
        }
    }
}
