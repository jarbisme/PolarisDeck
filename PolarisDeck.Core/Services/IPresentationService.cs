using PolarisDeck.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDeck.Core.Services
{
    public interface IPresentationService
    {
        Slide? CurrentSlide { get; }
        bool IsBlankScreen { get; }
        IReadOnlyList<Slide> ServicePlan { get; }
        int CurrentIndex { get; }

        void LoadServicePlan(ServicePlan plan);
        void GoTo(int index);
        void Next();
        void Previous();
        void SetBlank(bool blank);

        event EventHandler<Slide?> SlideChanged;
        event EventHandler<bool> BlankChanged;
    }
}
