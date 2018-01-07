using QuickSortWPF;
using System.Windows;
using System.Windows.Controls;

namespace QuicksortWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        int[] testArray = new int[] { 2, 6, 9, 3, 12, 4, 1 };

        public MainForm()
        {
            InitializeComponent();
            PopulateList("Old", this.oldList);
        }

        public void PopulateList(string listType, ListView currentList)
        {
            var gridView = new GridView();
            currentList.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = listType});
            foreach (int item in testArray)
            {
                currentList.Items.Add(item);
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            SortEngine.QuickSort(testArray);
            PopulateList("New", this.newList);
        }
    }
}
