using ProjecteKanbanWPF.Objects;
using System.Windows;
using System.Windows.Controls;

namespace ProjecteKanbanWPF.Windows
{
    public partial class ProjecteVisual : UserControl
    {
        public static readonly DependencyProperty ProjecteDataProperty =
            DependencyProperty.Register("ProjecteData", typeof(Projecte), typeof(ProjecteVisual), new PropertyMetadata(null));
        public Projecte ProjecteData
        {
            get => (Projecte)GetValue(ProjecteDataProperty);
            set => SetValue(ProjecteDataProperty, value);
        }

        public ProjecteVisual()
        {
            InitializeComponent();
        }

        private void EntrarProjecte_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is FinestraProjectes fp)
            {
                fp.EntrarProjecte(ProjecteData);
            }
        }

        private void EliminarProjecte_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is FinestraProjectes fp)
            {
                fp.EliminarProjecte(this);
            }
        }
    }
}