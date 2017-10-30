using System;
using System.Drawing;

namespace LinqTest
{
    internal class mypaint
    {
        private int v1;
        private int v2;
        private object width;
        private object height;
        private int v3;
        private int v4;

        public mypaint(int v1, int v2, object width, object height, int v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.width = width;
            this.height = height;
            this.v3 = v3;
            this.v4 = v4;
        }

        internal void SetValue(float dwAvailPhys, float dwTotalPhys)
        {
            throw new NotImplementedException();
        }

        internal void SetLoad(float v)
        {
            throw new NotImplementedException();
        }

        internal void SetOffset(int v)
        {
            throw new NotImplementedException();
        }

        internal void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        internal void Draw_percent(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}