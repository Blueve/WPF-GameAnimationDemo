using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_GameAnimationDemo
{
    class Explode : IDrawable
    {
        #region 动画资源
        /// <summary>
        /// 图片资源
        /// </summary>
        public static WriteableBitmap Image = BitmapFactory.ConvertToPbgra32Format(new BitmapImage(new Uri("Resources/explode.png", UriKind.Relative)));
        #endregion

        #region 动画参数
        /// <summary>
        /// 关键帧宽度
        /// </summary>
        public const int Width = 116;

        /// <summary>
        /// 关键帧高度
        /// </summary>
        public const int Height = 116;

        /// <summary>
        /// 每隔Slot帧播放一个关键帧
        /// </summary>
        public const int Slot = 3;

        /// <summary>
        /// 爆炸点横坐标
        /// </summary>
        private readonly int _x;

        /// <summary>
        /// 爆炸点纵坐标
        /// </summary>
        private readonly int _y;
        #endregion

        #region 私有字段
        /// <summary>
        /// 帧计数
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// 动画是否完结
        /// </summary>
        private bool _isAlive = true;
        #endregion

        #region 构造方法
        public Explode(int x, int y)
        {
            _x = x - Width / 2;
            _y = y - Height / 2;
        }
        #endregion

        #region 实现IDrawable
        public bool IsAlive
        {
            get { return _isAlive; }
            set {  _isAlive = value; }
        }

        public void Draw(WriteableBitmap renderTarget)
        {
            // 从图中选出当前需要绘制的帧
            var frame = _count / Slot;
            var rect = new Rect((frame % 5) * 116, (frame % 15) / 5 * 116, Width, Height);
            
            // 在画布上绘制
            renderTarget.Blit(new Rect(_x, _y, Width, Height), Image, rect, WriteableBitmapExtensions.BlendMode.Alpha);

            // 动画播放结束后，终止自己的生命周期
            if (frame == 14) _isAlive = false;

            _count++;
        }
        #endregion
    }
}
