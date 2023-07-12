using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Class_Operation
{
   public class CADProperty
    {
        public float sc;
        public float prev_sc;
        public int cX, cY;
        public bool detRMouseDown;
        public System.Drawing.PointF old_Pos;
        public System.Drawing.PointF pos;
        public System.Drawing.SizeF visibleArea;
        public PointF PreviousPosition
        {
            get
            {
                return this.old_Pos;
            }
            set
            {
                this.old_Pos = value;
            }
        }
        public PointF Position
        {
            get
            {
                return this.pos;
            }
            set
            {
                this.pos = value;
            }
        }
        public int CurrentXClickPosition
        {
            get
            {
                return this.cX;
            }
        }
        public float ImageScale
        {
            get
            {
                return this.sc;
            }
            set
            {
                this.sc = value;
            }
        }
        public float ImagePreviousScale
        {
            get
            {
                return this.prev_sc;
            }
            set
            {
                this.prev_sc = value;
            }
        }
        public SizeF VisibleAreaSize
        {
            get
            {
                return this.visibleArea;
            }
            set
            {
                this.visibleArea = value;
            }
        }
        public float LeftImagePosition
        {
            get
            {
                return this.pos.X;
            }
            set
            {
                this.pos.X = value;
            }
        }
        public float TopImagePosition
        {
            get
            {
                return this.pos.Y;
            }
            set
            {
                this.pos.Y = value;
            }
        }
        public RectangleF ImageRectangleF
        {
            get
            {
                return new RectangleF(this.LeftImagePosition, this.TopImagePosition,
                                      VisibleAreaSize.Width * ImageScale, VisibleAreaSize.Height * ImageScale);
            }
        }
    }
}
