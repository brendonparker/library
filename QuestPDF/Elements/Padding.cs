using System;
using QuestPDF.Drawing.SpacePlan;
using QuestPDF.Infrastructure;

namespace QuestPDF.Elements
{
    internal class Padding : ContainerElement
    {
        public float Top { get; set; }
        public float Right { get; set; }
        public float Bottom { get; set; }
        public float Left { get; set; }

        internal override ISpacePlan Measure(Size availableSpace)
        {
            if (Child == null)
                return new FullRender(Size.Zero);
            
            var internalSpace = InternalSpace(availableSpace);

            if (internalSpace.Width < 0 || internalSpace.Height < 0)
                return new Wrap();
            
            var measure = Child.Measure(internalSpace) as Size;

            if (measure == null)
                return new Wrap();

            var newSize = new Size(
                measure.Width + Left + Right,
                measure.Height + Top + Bottom);
            
            if (measure is PartialRender)
                return new PartialRender(newSize);
            
            if (measure is FullRender)
                return new FullRender(newSize);
            
            throw new NotSupportedException();
        }

        internal override void Draw(Size availableSpace)
        {
            if (Child == null)
                return;

            var internalSpace = InternalSpace(availableSpace);
            
            Canvas.Translate(new Position(Left, Top));
            Child?.Draw(internalSpace);
            Canvas.Translate(new Position(-Left, -Top));
        }

        private Size InternalSpace(Size availableSpace)
        {
            return new Size(
                availableSpace.Width - Left - Right,
                availableSpace.Height - Top - Bottom);
        }
    }
}