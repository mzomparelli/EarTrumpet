using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace EarTrumpet.UI.Views
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            Trace.WriteLine("DialogWindow .ctor");
            Closed += (_, __) => Trace.WriteLine("DialogWindow Closed");

            InitializeComponent();

            ContentRendered += DialogWindow_ContentRendered;
        }

        private void DialogWindow_ContentRendered(object sender, EventArgs e)
        {
            MaxWidth = ActualWidth;
            MaxHeight = ActualHeight;
        }
    }
}
