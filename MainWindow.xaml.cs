using System;
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

namespace WPF_GameAnimationDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Graphic _graphic;

        public MainWindow()
        {
            InitializeComponent();
            _graphic = new Graphic(ImageSurface);

            // 绑定绘制对象
            ImageSurface.Source = _graphic.RenderTarget;
            CompositionTarget.Rendering += _graphic.OnRending;
        }

        private void imageSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 鼠标按下的位置会发生爆炸
            _graphic.OnMouseClick((int)e.GetPosition(ImageSurface).X, (int)e.GetPosition(ImageSurface).Y);
        }
    }
}
