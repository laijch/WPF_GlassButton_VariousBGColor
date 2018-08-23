using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniWindow();
            IniWrapPanel();
        }

        /// <summary>
        /// 创建各种颜色的Lable,用以展示。
        /// </summary>
        /// <param name="lblColor">要创建的Label的颜色</param>
        /// <returns></returns>
        public static Label Createlbl(Color lblColor)
        {
            Label lbl = new Label();
            lbl.Height = 30;
            lbl.Width = 100;
            SolidColorBrush scb = new SolidColorBrush(lblColor);
            lbl.Background = scb;
            return lbl;
        }

        public static Button CreateGlassButton(Color bgColor)
        {
            Button glb = new Button();
            glb.Height = 45;
            glb.Width = 45;
            Thickness myThickness = new Thickness(3);
            glb.Margin = myThickness;
            SolidColorBrush scb = new SolidColorBrush(bgColor);
            glb.Background = scb;
            Image cellImage = new Image();
            cellImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Logo128.png"));
            cellImage.Width = 35;
            cellImage.Height = 35;
            glb.Content = cellImage;
            glb.SetValue(Button.StyleProperty, Application.Current.Resources["GlassButton"]);
            return glb;
        }

        /// <summary>
        /// 初始化WrapPanel，其内容是各色标签。
        /// </summary>
        public void IniWrapPanel()
        {
            Type t = typeof(Colors);
            PropertyInfo[] pInfo = t.GetProperties();
            foreach (PropertyInfo pi in pInfo)
            {
                Color c = (Color)ColorConverter.ConvertFromString(pi.Name);
                Label lbl = Createlbl(c);
                lbl.Content = pi.Name;
                this.wp.Children.Add(lbl);
                Button glb = CreateGlassButton(c);
                this.wp.Children.Add(glb);
            }
        }

        /// <summary>
        /// 初始化窗体，以合理的尺寸显示各种颜色。
        /// </summary>
        public void IniWindow()
        {
            this.Title = "ColorPresentation";
            //this.ResizeMode = ResizeMode.NoResize;
            this.Height = 600;
            this.Width = 820;
            this.Content = wp;
        }
    }
}
