using PolarisDeck.Core.Models;
using PolarisDeck.Core.Services;
using System;
using System.Collections.Generic;

namespace PolarisDeck.UI.Services;

public class PresentationService : IPresentationService
{
    private List<Slide> _slides = [];
    private int _currentIndex = -1;
    private bool _isBlank;

    public Slide? CurrentSlide => _currentIndex >= 0 && _currentIndex < _slides.Count
        ? _slides[_currentIndex] : null;

    public bool IsBlankScreen => _isBlank;
    public IReadOnlyList<Slide> ServicePlan => _slides;
    public int CurrentIndex => _currentIndex;

    public event EventHandler<Slide?>? SlideChanged;
    public event EventHandler<bool>? BlankChanged;

    public void LoadServicePlan(Core.Models.ServicePlan plan)
    {
        _slides = plan.Slides;
        _currentIndex = _slides.Count > 0 ? 0 : -1;
        SlideChanged?.Invoke(this, CurrentSlide);
    }

    public void GoTo(int index)
    {
        if (index < 0 || index >= _slides.Count) return;
        _currentIndex = index;
        SlideChanged?.Invoke(this, CurrentSlide);
    }

    public void Next() => GoTo(_currentIndex + 1);
    public void Previous() => GoTo(_currentIndex - 1);

    public void SetBlank(bool blank)
    {
        _isBlank = blank;
        BlankChanged?.Invoke(this, blank);
    }
}