﻿namespace ConsoLovers.Console
{
   using System;
   using System.Collections.Concurrent;
   using System.Drawing;

   public sealed class ColorManagerFactory
    {
        public ColorManagerFactory()
        {
        }

        public ColorManager GetManager(ColorStore colorStore, int maxColorChanges, int initialColorChangeCountValue)
        {
            return new ColorManager(colorStore, GetColorMapper(), maxColorChanges, initialColorChangeCountValue);
        }

        public ColorManager GetManager(ConcurrentDictionary<Color, ConsoleColor> colorMap, ConcurrentDictionary<ConsoleColor, Color> consoleColorMap, int maxColorChanges, int initialColorChangeCountValue)
        {
            ColorStore colorStore = GetColorStore(colorMap, consoleColorMap);
            ColorMapper colorMapper = GetColorMapper();

            return new ColorManager(colorStore, colorMapper, maxColorChanges, initialColorChangeCountValue);
        }

        private ColorStore GetColorStore(ConcurrentDictionary<Color, ConsoleColor> colorMap, ConcurrentDictionary<ConsoleColor, Color> consoleColorMap)
        {
            return new ColorStore(colorMap, consoleColorMap);
        }

        private ColorMapper GetColorMapper()
        {
            return new ColorMapper();
        }
    }
}
