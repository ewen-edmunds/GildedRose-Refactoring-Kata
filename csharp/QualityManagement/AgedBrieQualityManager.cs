﻿
using System;

namespace csharp
{
    public class AgedBrieQualityManager : QualityManager
    {
        public static int AGED_BRIE_QUALITY_INCREASE = 1;
        public override void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Min(DEFAULT_MAX_QUALITY, item.Quality + (AGED_BRIE_QUALITY_INCREASE*GetQualityChangeFactor(item)));
        }
    }
}