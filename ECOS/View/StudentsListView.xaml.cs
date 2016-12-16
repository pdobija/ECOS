using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECOS.View
{
    /// <summary>
    /// Interaction logic for StudentsListView.xaml
    /// </summary>
    public partial class StudentsListView : UserControl
    {

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            ListView.SelectedItemProperty.AddOwner(typeof(StudentsListView));

        public static readonly DependencyProperty ItemsSourceProperty =
           ListView.ItemsSourceProperty.AddOwner(typeof(StudentsListView));

        public StudentsListView()
        {
            InitializeComponent();
        }
    }
}
