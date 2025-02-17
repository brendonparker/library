﻿using System;
using System.Linq;
using QuestPDF.Drawing.SpacePlan;
using QuestPDF.Infrastructure;

namespace QuestPDF.Elements
{
    internal class SimpleRotate : ContainerElement
    {
        public int TurnCount { get; set; }
        public int NormalizedTurnCount => (TurnCount % 4 + 4) % 4;
        
        internal override ISpacePlan Measure(Size availableSpace)
        {
            if (NormalizedTurnCount == 0 || NormalizedTurnCount == 2)
                return base.Measure(availableSpace);
            
            availableSpace = new Size(availableSpace.Height, availableSpace.Width);
            var childSpace = base.Measure(availableSpace) as Size;

            if (childSpace == null)
                return new Wrap();

            var targetSpace = new Size(childSpace.Height, childSpace.Width);

            if (childSpace is FullRender)
                return new FullRender(targetSpace);
            
            if (childSpace is PartialRender)
                return new PartialRender(targetSpace);

            throw new ArgumentException();
        }
        
        internal override void Draw(Size availableSpace)
        {
            var skiaCanvas = (Canvas as Drawing.SkiaCanvasBase)?.Canvas;
            
            if (skiaCanvas == null)
                return;

            var currentMatrix = skiaCanvas.TotalMatrix;

            if (NormalizedTurnCount == 1 || NormalizedTurnCount == 2)
                skiaCanvas.Translate(availableSpace.Width, 0);
            
            if (NormalizedTurnCount == 2  || NormalizedTurnCount == 3)
                skiaCanvas.Translate(0, availableSpace.Height);

            skiaCanvas.RotateDegrees(NormalizedTurnCount * 90);
            
            if (NormalizedTurnCount == 1 || NormalizedTurnCount == 3)
                availableSpace = new Size(availableSpace.Height, availableSpace.Width);
            
            Child?.Draw(availableSpace);
            skiaCanvas.SetMatrix(currentMatrix);
        }
    }
}