using ProjecteKanbanWPF.Objects;
using ProjecteKanbanWPF.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjecteKanbanWPF
{
    public partial class MainWindow : Window
    {
        private Projecte proj;
        public MainWindow(Projecte projecteSeleccionat)
        {
            InitializeComponent();
            proj = new Projecte { Name = "Test" };
            Title = "Kanban - " + proj.Name;
            GenerarColumnes(proj);
        }

        private void GenerarColumnes(Projecte proj)
        {
            List<string> estats = proj.StatesList;
            for (int i = 0; i < estats.Count; i++)
            {
                TaskGrid.ColumnDefinitions.Add(new ColumnDefinition());

                Border b = new()
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.LightGray,
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(5),
                    Background = new SolidColorBrush(Color.FromRgb(240, 240, 240))
                };

                ScrollViewer s = new()
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto
                };

                StackPanel columnaPanel = new()
                {
                    Margin = new Thickness(5),
                    AllowDrop = true,
                    Tag = i,
                    Background = Brushes.Transparent
                };

                TextBlock titolColumna = new TextBlock
                {
                    Text = estats[i],
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                columnaPanel.Children.Add(titolColumna);
                columnaPanel.Drop += Columna_Drop;
                columnaPanel.DragOver += Columna_DragOver;

                b.Child = s;
                s.Content = columnaPanel;
                Grid.SetColumn(b, i);
                TaskGrid.Children.Add(b);
            }
        }

        private void Columna_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TascaVisual)))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void Columna_Drop(object sender, DragEventArgs e)
        {
            TascaVisual tascaArrossegada = (TascaVisual)e.Data.GetData(typeof(TascaVisual));
            StackPanel panellDesti = (StackPanel)sender;

            if (tascaArrossegada != null && panellDesti != null)
            {
                Panel pareAntic = (Panel)VisualTreeHelper.GetParent(tascaArrossegada);
                if (pareAntic != null && pareAntic != panellDesti)
                {
                    pareAntic.Children.Remove(tascaArrossegada);
                    panellDesti.Children.Add(tascaArrossegada);
                    tascaArrossegada.TascaData.Estat = Convert.ToInt32(panellDesti.Tag);
                }
            }
        }

        private void AfegirTascaClick(object sender, RoutedEventArgs e)
        {
            FinestraEditarTasca f = new();
            bool? result = f.ShowDialog();

            if (result == true)
            {
                if (f.Afegir)
                {
                    AfegirTasca(f.TascaResultat);
                }
            }
        }

        public void AfegirTasca(Tasca tasca)
        {
            if (TaskGrid.Children.Count > 0 && TaskGrid.Children[0] is Border b && b.Child is ScrollViewer sv && sv.Content is StackPanel sp)
            {
                tasca.Estat = 0;
                TascaVisual t = new() { TascaData = tasca };
                sp.Children.Add(t);
                proj.TaskList.Add(tasca);
            }
        }

        public void ModificarTasca(Tasca tascaOriginal, Tasca novaTasca)
        {
            proj.TaskList.Remove(tascaOriginal);
            proj.TaskList.Add(novaTasca);
        }

        public void EliminarTasca(TascaVisual tasca)
        {
            StackPanel sp = (StackPanel)tasca.Parent;
            proj.TaskList.Remove(tasca.TascaData);
            sp.Children.Remove(tasca);
        }
    }
}