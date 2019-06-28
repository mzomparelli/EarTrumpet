using EarTrumpet.DataModel;
using EarTrumpet.Interop.Helpers;
using System;
using System.Windows;

namespace EarTrumpet.UI.Themes
{
    class AcrylicBrush
    {
        public static string GetBackground(DependencyObject obj) => (string)obj.GetValue(BackgroundProperty);
        public static void SetBackground(DependencyObject obj, string value) => obj.SetValue(BackgroundProperty, value);
        public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.RegisterAttached("Background", typeof(string), typeof(AcrylicBrush), new PropertyMetadata("", BackgroundChanged));
        private static void BackgroundChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)dependencyObject;
            window.SourceInitialized += (_, __) =>
            {
                ApplyAcrylicToWindow(window, (string)e.NewValue);
            };

            var strongWindow = new WeakReference(window);
            Manager.Current.ThemeChanged += () =>
            {
                var resolvedWindow = (Window)strongWindow.Target;
                if (resolvedWindow != null)
                {
                    ApplyAcrylicToWindow(resolvedWindow, (string)e.NewValue);
                }
            };
        }

        private static void ApplyAcrylicToWindow(Window window, string refValue)
        {
            if (!SystemParameters.HighContrast && 
                SystemSettings.IsTransparencyEnabled)
            {
                AccentPolicyLibrary.EnableAcrylic(window,
                    Manager.Current.ResolveRef(window, refValue),
                    Interop.User32.AccentFlags.None);
            }
            else
            {
                AccentPolicyLibrary.DisableAcrylic(window);
            }
        }
    }
}
