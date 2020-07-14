using System;

namespace csharp
{
    public class ConjuredItemQualityUpdater : QualityUpdater
    {
        public ConjuredItemQualityUpdater()
        {
            QualityDecrease = 2*DEFAULT_QUALITY_DECREASE;
        }
    }
}