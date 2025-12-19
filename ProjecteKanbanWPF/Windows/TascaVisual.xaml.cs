using ProjecteKanbanWPF.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjecteKanbanWPF.Windows
{
    public partial class TascaVisual : UserControl
    {
        public static readonly DependencyProperty TascaDataProperty =
            DependencyProperty.Register("TascaData", typeof(Tasca), typeof(TascaVisual), new PropertyMetadata(null));
        public Tasca TascaData
        {
            get => (Tasca)GetValue(TascaDataProperty);
            set => SetValue(TascaDataProperty, value);
        }

        public TascaVisual()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Tasca_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is DependencyObject dragSource)
            {
                DragDrop.DoDragDrop(dragSource, this, DragDropEffects.Move);
            }
        }

        private void EditarTasca_Click(object sender, RoutedEventArgs e)
        {
            FinestraEditarTasca f = new(this.TascaData)
            {
                Owner = Application.Current.MainWindow,
                TascaOriginal = this
            };

            bool? result = f.ShowDialog();

            if (result == true && f.Afegir)
            {
                MainWindow mw = (MainWindow)f.Owner;
                mw.ModificarTasca(f.TascaOriginal.TascaData, f.TascaResultat);
            }
        }
    }
}