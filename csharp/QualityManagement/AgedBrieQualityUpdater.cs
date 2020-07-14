
using System;

namespace csharp
{
    public class AgedBrieQualityUpdater : QualityUpdater
    {
        public AgedBrieQualityUpdater()
        {
            QualityDecrease = -DEFAULT_QUALITY_DECREASE;
        }
    }
}