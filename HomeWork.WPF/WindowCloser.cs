using System.Windows;

namespace HomeWork.WPF
{
    public static class WindowCloser
    {
        public static readonly DependencyProperty WindowResultProperty =
            DependencyProperty.RegisterAttached(
                "WindowResult",
                typeof(bool?),
                typeof(WindowCloser),
                new PropertyMetadata(WindowResultChanged));

        private static void WindowResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            var isHide = e.NewValue as bool?;
            if (window != null && isHide.GetValueOrDefault())
            {
                window.Hide();
            }
        }

        public static void SetWindowResult(Window target, bool? value)
        {
            target.SetValue(WindowResultProperty, value);
        }
    }
}
